// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="SignInViewModel.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LeadGeneration.Models.ApiViewModels
{
    /// <summary>
    ///     Class SignInViewModel.
    /// </summary>
    public class SignInViewModel
    {
        /// <summary>
        ///     Gets or sets the campaign identifier.
        /// </summary>
        /// <value>The campaign identifier.</value>
        public int CampaignId { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }
    }
}