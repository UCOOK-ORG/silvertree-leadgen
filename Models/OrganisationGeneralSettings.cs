// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="OrganisationGeneralSettings.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class OrganisationGeneralSettings.
    /// </summary>
    public class OrganisationGeneralSettings
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the website base URL.
        /// </summary>
        /// <value>The website base URL.</value>
        public string WebsiteBaseUrl { get; set; }

        /// <summary>
        ///     Gets or sets the google tag manager identifier.
        /// </summary>
        /// <value>The google tag manager identifier.</value>
        public string GoogleTagManagerId { get; set; }
    }
}