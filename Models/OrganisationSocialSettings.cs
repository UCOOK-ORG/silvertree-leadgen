// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="OrganisationSocialSettings.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class OrganisationSocialSettings.
    /// </summary>
    public class OrganisationSocialSettings
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the facebook identifier.
        /// </summary>
        /// <value>The facebook identifier.</value>
        [Display(Name = "Facebook Id")]
        public string FacebookId { get; set; }
    }
}