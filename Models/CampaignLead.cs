// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="CampaignLead.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class CampaignLead.
    /// </summary>
    public class CampaignLead
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the referral identifier.
        /// </summary>
        /// <value>The referral identifier.</value>
        public int? ReferralId { get; set; }

        /// <summary>
        ///     Gets or sets the utm source.
        /// </summary>
        /// <value>The utm source.</value>
        public string UtmSource { get; set; }

        /// <summary>
        ///     Gets or sets the utm medium.
        /// </summary>
        /// <value>The utm medium.</value>
        public string UtmMedium { get; set; }

        /// <summary>
        ///     Gets or sets the utm campaign.
        /// </summary>
        /// <value>The utm campaign.</value>
        public string UtmCampaign { get; set; }

        /// <summary>
        ///     Gets or sets the campaign identifier.
        /// </summary>
        /// <value>The campaign identifier.</value>
        public int CampaignId { get; set; }

        /// <summary>
        ///     Gets or sets the campaign.
        /// </summary>
        /// <value>The campaign.</value>
        [JsonIgnore]
        public Campaign Campaign { get; set; }

        /// <summary>
        ///     Gets or sets the email referrals.
        /// </summary>
        /// <value>The email referrals.</value>
        public ICollection<CampaignEmailReferral> EmailReferrals { get; set; }
    }
}