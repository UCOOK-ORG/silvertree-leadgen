// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="LeadGenerationService.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Hangfire;
using LeadGeneration.Data;
using LeadGeneration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LeadGeneration.Services
{
    /// <summary>
    ///     Class LeadGenerationService.
    /// </summary>
    public class LeadGenerationService
    {
        /// <summary>
        ///     The cache
        /// </summary>
        private readonly IMemoryCache _cache;

        /// <summary>
        ///     The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LeadGenerationService" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cache">The cache.</param>
        public LeadGenerationService(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        /// <summary>
        ///     Gets the campaign.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="slug">The slug.</param>
        /// <returns>Campaign.</returns>
        /// <exception cref="Exception">
        ///     Please specify a valid Campaign Id or Campaign Slug
        ///     or
        ///     Could not find matching campaign
        /// </exception>
        public Campaign GetCampaign(int? id, string slug)
        {
            if (id == null && string.IsNullOrEmpty(slug))
                throw new Exception("Please specify a valid Campaign Id or Campaign Slug");

            var lookupKey = (id != null ? id.ToString() : slug) + Configs.CampaignCacheKey;

            var existingCampaign = _cache.Get<Campaign>(lookupKey);

            if (existingCampaign != null) return existingCampaign;

            var campaignQuery = _context.Campaigns
                .Include(a => a.CampaignSettings)
                .Include(a => a.CampaignContent)
                .ThenInclude(a => a.SocialContent)
                .Include(a => a.CampaignContent)
                .ThenInclude(a => a.SignUpPage)
                .Include(a => a.CampaignContent)
                .ThenInclude(a => a.StatusPage)
                .Include(a => a.CampaignContent)
                .ThenInclude(a => a.TermsAndConditions);

            var campaign = id != null
                ? campaignQuery.FirstOrDefault(a => a.Id == id)
                : campaignQuery.LastOrDefault(a => a.Slug == slug);

            if (campaign == null) throw new Exception("Could not find matching campaign");

            _cache.Set(lookupKey, campaign, TimeSpan.FromSeconds(120));

            return campaign;
        }

        /// <summary>
        ///     Gets the lead.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CampaignLead.</returns>
        /// <exception cref="Exception">Could not find you in our database</exception>
        public CampaignLead GetLead(int id)
        {
            var lead = _context.CampaignLeads.Include(a => a.EmailReferrals).FirstOrDefault(a => a.Id == id);

            if (lead == null) throw new Exception("Could not find you in our database");

            return lead;
        }

        /// <summary>
        ///     Signs up.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="campaignId">The campaign identifier.</param>
        /// <param name="referralId">The referral identifier.</param>
        /// <param name="source">The source.</param>
        /// <param name="medium">The medium.</param>
        /// <returns>CampaignLead.</returns>
        /// <exception cref="Exception">
        ///     You have already signed up for this competition
        ///     or
        ///     Could not find matching campaign
        /// </exception>
        public CampaignLead SignUp(string email, string name, string surname, int campaignId, int? referralId,
            string source = null, string medium = null)
        {
            email = email.Trim().ToUpperInvariant();
            var existingLead =
                _context.CampaignLeads.FirstOrDefault(a => a.Email == email && a.CampaignId == campaignId);

            if (existingLead != null) throw new Exception("You have already signed up for this competition");


            var lookupKey = campaignId + Configs.CampaignSettingsKey;
            var existingCampaign = _cache.Get<Campaign>(lookupKey);

            if (existingCampaign == null)
            {
                existingCampaign = _context.Campaigns
                    .Include(a => a.CampaignSettings)
                    .Include(a => a.Organisation)
                    .ThenInclude(a => a.OrganisationMandrillSettings)
                    .Include(a => a.Organisation)
                    .ThenInclude(a => a.OrganisationGeneralSettings)
                    .FirstOrDefault(a => a.Id == campaignId);

                if (existingCampaign == null) throw new Exception("Could not find matching campaign");

                _cache.Set(lookupKey, existingCampaign, TimeSpan.FromMinutes(5));
            }

            var newLead = new CampaignLead
            {
                CampaignId = campaignId,
                Name = name,
                Surname = surname,
                Email = email,
                ReferralId = referralId,
                UtmSource = source,
                UtmCampaign = existingCampaign.Slug,
                UtmMedium = medium
            };

            _context.CampaignLeads.Add(newLead);
            _context.SaveChanges();

            if (referralId != null)
            {
                var referralLead = _context.CampaignLeads.Include(a => a.EmailReferrals)
                    .FirstOrDefault(a => a.Id == referralId);

                if (referralLead != null)
                {
                    var emailReferral = referralLead.EmailReferrals.FirstOrDefault(a => a.Email == email);
                    if (emailReferral != null)
                        emailReferral.Status = "Success";
                    else
                        referralLead.EmailReferrals.Add(new CampaignEmailReferral
                        {
                            Status = "Success",
                            Email = email,
                            Name = name,
                            Surname = surname
                        });
                    _context.CampaignLeads.Update(referralLead);
                    _context.SaveChanges();
                }
            }

            var campaignSettings = existingCampaign.CampaignSettings;
            var organisationMandrillSettings = existingCampaign.Organisation.OrganisationMandrillSettings;

            var data = new Dictionary<string, object>
            {
                {"LeadName", name},
                {"LeadSurname", surname},
                {
                    "WebsiteUrl",
                    string.Format("{0}/e/{1}", existingCampaign.Organisation.OrganisationGeneralSettings.WebsiteBaseUrl,
                        existingCampaign.Slug)
                }
            };

            BackgroundJob.Enqueue<EmailSender>(a => a.SendEmail(email,
                campaignSettings.MandrillLeadTemplate,
                campaignSettings.LeadSubjectLine,
                data,
                organisationMandrillSettings.FromEmail,
                organisationMandrillSettings.ApiKey));

            return newLead;
        }

        /// <summary>
        ///     Signs the in.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="campaignId">The campaign identifier.</param>
        /// <returns>CampaignLead.</returns>
        /// <exception cref="Exception">Could not find you in our database</exception>
        public CampaignLead SignIn(string email, string phone, int campaignId)
        {
            var lead = _context.CampaignLeads.FirstOrDefault(a => a.Email == email.Trim().ToUpperInvariant()
                                                                  && a.Phone == phone.Trim()
                                                                  && a.CampaignId == campaignId);

            if (lead == null) throw new Exception("Could not find you in our database");

            return lead;
        }


        /// <summary>
        ///     Sends the referral email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <exception cref="Exception">Could not find matching sender you in our database</exception>
        public void SendReferralEmail(string email, string name, string surname, int senderId)
        {
            email = email.ToUpperInvariant().Trim();

            var lead = _context.CampaignLeads
                .Include(a => a.EmailReferrals)
                .FirstOrDefault(a => a.Id == senderId);

            if (lead == null) throw new Exception("Could not find matching sender you in our database");

            if (lead.EmailReferrals.Any(a => a.Email == email)) throw new Exception("Referral email already sent");

            var newReferral = new CampaignEmailReferral
            {
                Email = email,
                Name = name,
                Surname = surname,
                CampaignLeadId = senderId,
                Status = "Pending"
            };

            lead.EmailReferrals.Add(newReferral);
            _context.CampaignLeads.Update(lead);
            _context.SaveChanges();

            var lookupKey = lead.CampaignId + Configs.CampaignSettingsKey;
            var existingCampaign = _cache.Get<Campaign>(lookupKey);

            if (existingCampaign == null)
            {
                existingCampaign = _context.Campaigns
                    .Include(a => a.CampaignSettings)
                    .Include(a => a.Organisation)
                    .ThenInclude(a => a.OrganisationMandrillSettings)
                    .Include(a => a.Organisation)
                    .ThenInclude(a => a.OrganisationGeneralSettings)
                    .FirstOrDefault(a => a.Id == lead.CampaignId);

                if (existingCampaign == null) throw new Exception("Could not find matching campaign");

                _cache.Set(lookupKey, existingCampaign, TimeSpan.FromMinutes(5));
            }


            var campaignSettings = existingCampaign.CampaignSettings;
            var organisationMandrillSettings = existingCampaign.Organisation.OrganisationMandrillSettings;

            var data = new Dictionary<string, object>
            {
                {"ReferrerFullName", lead.Name + " " + lead.Surname},
                {"ReferralName", name},
                {"ReferralSurname", surname},
                {
                    "ReferralUrl",
                    string.Format("{0}/r/{1}/e",
                        existingCampaign.Organisation.OrganisationGeneralSettings.WebsiteBaseUrl,
                        lead.Id)
                }
            };


            BackgroundJob.Enqueue<EmailSender>(a => a.SendEmail(email,
                campaignSettings.MandrillReferralTemplate,
                campaignSettings.ReferralSubjectLine,
                data,
                organisationMandrillSettings.FromEmail,
                organisationMandrillSettings.ApiKey));
        }
    }
}