// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="SignUpViewModel.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LeadGeneration.Models.ApiViewModels
{
    /// <summary>
    ///     Class SignUpViewModel.
    /// </summary>
    public class SignUpViewModel
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
        ///     Gets or sets the referral identifier.
        /// </summary>
        /// <value>The referral identifier.</value>
        public int? ReferralId { get; set; }

        /// <summary>
        ///     Gets or sets the utm view model.
        /// </summary>
        /// <value>The utm view model.</value>
        public UtmViewModel UtmViewModel { get; set; }
    }

    /// <summary>
    ///     Class UtmViewModel.
    /// </summary>
    public class UtmViewModel
    {
        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; }

        /// <summary>
        ///     Gets or sets the medium.
        /// </summary>
        /// <value>The medium.</value>
        public string Medium { get; set; }

        /// <summary>
        ///     Gets or sets the campaign.
        /// </summary>
        /// <value>The campaign.</value>
        public string Campaign { get; set; }
    }
}