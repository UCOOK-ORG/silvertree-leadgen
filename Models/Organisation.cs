// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="Organisation.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class Organisation.
    /// </summary>
    public class Organisation
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
        ///     Gets or sets the organisation general settings identifier.
        /// </summary>
        /// <value>The organisation general settings identifier.</value>
        public int OrganisationGeneralSettingsId { get; set; }

        /// <summary>
        ///     Gets or sets the organisation general settings.
        /// </summary>
        /// <value>The organisation general settings.</value>
        public virtual OrganisationGeneralSettings OrganisationGeneralSettings { get; set; }

        /// <summary>
        ///     Gets or sets the organisation mandrill settings identifier.
        /// </summary>
        /// <value>The organisation mandrill settings identifier.</value>
        public int OrganisationMandrillSettingsId { get; set; }

        /// <summary>
        ///     Gets or sets the organisation mandrill settings.
        /// </summary>
        /// <value>The organisation mandrill settings.</value>
        public virtual OrganisationMandrillSettings OrganisationMandrillSettings { get; set; }

        /// <summary>
        ///     Gets or sets the organisation social settings identifier.
        /// </summary>
        /// <value>The organisation social settings identifier.</value>
        public int OrganisationSocialSettingsId { get; set; }

        /// <summary>
        ///     Gets or sets the organisation social settings.
        /// </summary>
        /// <value>The organisation social settings.</value>
        public virtual OrganisationSocialSettings OrganisationSocialSettings { get; set; }

        /// <summary>
        ///     Gets or sets the campaigns.
        /// </summary>
        /// <value>The campaigns.</value>
        [JsonIgnore]
        public ICollection<Campaign> Campaigns { get; set; }
    }
}