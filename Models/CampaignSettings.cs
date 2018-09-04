// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="CampaignSettings.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class CampaignSettings.
    /// </summary>
    public class CampaignSettings
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the lead subject line.
        /// </summary>
        /// <value>The lead subject line.</value>
        [Display(Name = "Lead SubjectLine")]
        public string LeadSubjectLine { get; set; }

        /// <summary>
        ///     Gets or sets the mandrill lead template.
        /// </summary>
        /// <value>The mandrill lead template.</value>
        [Display(Name = "Mandrill Lead Template (entry): Tags ({{LeadName}}, {{LeadSurname}}, {{WebsiteUrl}})")]
        public string MandrillLeadTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the mandrill referral template.
        /// </summary>
        /// <value>The mandrill referral template.</value>
        [Display(Name = "Mandrill Referral Template: Tags ({{ReferrerFullName}}, {{ReferralName}}, {{ReferralSurname}}, {{ReferralUrl}})")]
        public string MandrillReferralTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the referral subject line.
        /// </summary>
        /// <value>The referral subject line.</value>
        [Display(Name = "Referral Subject Line")]
        public string ReferralSubjectLine { get; set; }

        /// <summary>
        ///     Gets or sets the campaign start date.
        /// </summary>
        /// <value>The campaign start date.</value>
        [Display(Name = "Campaign Start Date")]
        public DateTime CampaignStartDate { get; set; }

        /// <summary>
        ///     Gets or sets the campaign end date.
        /// </summary>
        /// <value>The campaign end date.</value>
        [Display(Name = "Campaign End Date")]
        public DateTime CampaignEndDate { get; set; }
    }
}