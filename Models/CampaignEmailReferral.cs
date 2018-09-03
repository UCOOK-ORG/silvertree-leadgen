// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="CampaignEmailReferral.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Newtonsoft.Json;

namespace LeadGeneration.Models
{
    /// <summary>
    /// Class CampaignEmailReferral.
    /// </summary>
    public class CampaignEmailReferral
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignEmailReferral"/> class.
        /// </summary>
        public CampaignEmailReferral()
        {
            SendDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }


        /// <summary>
        /// Gets or sets the send date.
        /// </summary>
        /// <value>The send date.</value>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the campaign lead identifier.
        /// </summary>
        /// <value>The campaign lead identifier.</value>
        public int CampaignLeadId { get; set; }

        /// <summary>
        /// Gets or sets the campaign lead.
        /// </summary>
        /// <value>The campaign lead.</value>
        [JsonIgnore]
        public CampaignLead CampaignLead { get; set; }
    }
}