// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="OrganisationMandrillSettings.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class OrganisationMandrillSettings.
    /// </summary>
    public class OrganisationMandrillSettings
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
        public string ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets from email.
        /// </summary>
        /// <value>From email.</value>
        public string FromEmail { get; set; }
    }
}