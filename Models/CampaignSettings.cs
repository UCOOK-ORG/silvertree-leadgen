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
        public string LeadSubjectLine { get; set; }

        /// <summary>
        ///     Gets or sets the mandrill lead template.
        /// </summary>
        /// <value>The mandrill lead template.</value>
        public string MandrillLeadTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the mandrill referral template.
        /// </summary>
        /// <value>The mandrill referral template.</value>
        public string MandrillReferralTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the referral subject line.
        /// </summary>
        /// <value>The referral subject line.</value>
        public string ReferralSubjectLine { get; set; }

        /// <summary>
        ///     Gets or sets the campaign start date.
        /// </summary>
        /// <value>The campaign start date.</value>
        public DateTime CampaignStartDate { get; set; }

        /// <summary>
        ///     Gets or sets the campaign end date.
        /// </summary>
        /// <value>The campaign end date.</value>
        public DateTime CampaignEndDate { get; set; }
    }
}