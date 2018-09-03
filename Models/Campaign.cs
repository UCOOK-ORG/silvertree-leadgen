// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="Campaign.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class Campaign.
    /// </summary>
    public class Campaign
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
        ///     Gets or sets the slug.
        /// </summary>
        /// <value>The slug.</value>
        public string Slug { get; set; }

        /// <summary>
        ///     Gets or sets the organisation identifier.
        /// </summary>
        /// <value>The organisation identifier.</value>
        public int OrganisationId { get; set; }

        /// <summary>
        ///     Gets or sets the organisation.
        /// </summary>
        /// <value>The organisation.</value>
        [JsonIgnore]
        public Organisation Organisation { get; set; }

        /// <summary>
        ///     Gets or sets the campaign settings identifier.
        /// </summary>
        /// <value>The campaign settings identifier.</value>
        public int CampaignSettingsId { get; set; }

        /// <summary>
        ///     Gets or sets the campaign settings.
        /// </summary>
        /// <value>The campaign settings.</value>
        public CampaignSettings CampaignSettings { get; set; }

        /// <summary>
        ///     Gets or sets the campaign content identifier.
        /// </summary>
        /// <value>The campaign content identifier.</value>
        public int CampaignContentId { get; set; }

        /// <summary>
        ///     Gets or sets the content of the campaign.
        /// </summary>
        /// <value>The content of the campaign.</value>
        public CampaignContent CampaignContent { get; set; }

        /// <summary>
        ///     Gets or sets the leads.
        /// </summary>
        /// <value>The leads.</value>
        [JsonIgnore]
        public ICollection<CampaignLead> Leads { get; set; }
    }
}