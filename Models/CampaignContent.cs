// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="CampaignContent.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;

namespace LeadGeneration.Models
{
    /// <summary>
    ///     Class CampaignContent.
    /// </summary>
    public class CampaignContent
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        public string BackgroundImage { get; set; }

        /// <summary>
        ///     Gets the background cloudinary image.
        /// </summary>
        /// <value>The background cloudinary image.</value>
        [NotMapped]
        public CloudinaryImage BackgroundCloudinaryImage => new CloudinaryImage(BackgroundImage);

        /// <summary>
        ///     Gets or sets the footer text.
        /// </summary>
        /// <value>The footer text.</value>
        public string FooterText { get; set; }

        /// <summary>
        ///     Gets or sets the sign up page identifier.
        /// </summary>
        /// <value>The sign up page identifier.</value>
        public int SignUpPageId { get; set; }

        /// <summary>
        ///     Gets or sets the sign up page.
        /// </summary>
        /// <value>The sign up page.</value>
        public virtual CampaignContentSignUp SignUpPage { get; set; }

        /// <summary>
        ///     Gets or sets the status page identifier.
        /// </summary>
        /// <value>The status page identifier.</value>
        public int StatusPageId { get; set; }

        /// <summary>
        ///     Gets or sets the status page.
        /// </summary>
        /// <value>The status page.</value>
        public virtual CampaignContentStatus StatusPage { get; set; }

        /// <summary>
        ///     Gets or sets the terms and conditions identifier.
        /// </summary>
        /// <value>The terms and conditions identifier.</value>
        public int TermsAndConditionsId { get; set; }

        /// <summary>
        ///     Gets or sets the terms and conditions.
        /// </summary>
        /// <value>The terms and conditions.</value>
        public virtual CampaignContentTermsAndConditions TermsAndConditions { get; set; }

        /// <summary>
        ///     Gets or sets the social content identifier.
        /// </summary>
        /// <value>The social content identifier.</value>
        public int SocialContentId { get; set; }

        /// <summary>
        ///     Gets or sets the content of the social.
        /// </summary>
        /// <value>The content of the social.</value>
        public virtual CampaignContentSocial SocialContent { get; set; }
    }

    /// <summary>
    ///     Class CampaignContentSocial.
    /// </summary>
    public class CampaignContentSocial
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the facebook title.
        /// </summary>
        /// <value>The facebook title.</value>
        public string FacebookTitle { get; set; }

        /// <summary>
        ///     Gets or sets the facebook description.
        /// </summary>
        /// <value>The facebook description.</value>
        public string FacebookDescription { get; set; }

        /// <summary>
        ///     Gets the facebook cloudinary image.
        /// </summary>
        /// <value>The facebook cloudinary image.</value>
        [NotMapped]
        public CloudinaryImage FacebookCloudinaryImage => new CloudinaryImage(FacebookImage);

        /// <summary>
        ///     Gets or sets the facebook image.
        /// </summary>
        /// <value>The facebook image.</value>
        public string FacebookImage { get; set; }

        /// <summary>
        ///     Gets or sets the twitter message.
        /// </summary>
        /// <value>The twitter message.</value>
        public string TwitterMessage { get; set; }
    }


    /// <summary>
    ///     Class CampaignContentSignUp.
    /// </summary>
    public class CampaignContentSignUp
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the main text.
        /// </summary>
        /// <value>The main text.</value>
        public string MainText { get; set; }

        /// <summary>
        ///     Gets or sets the secondary text.
        /// </summary>
        /// <value>The secondary text.</value>
        public string SecondaryText { get; set; }

        /// <summary>
        ///     Gets or sets the header image.
        /// </summary>
        /// <value>The header image.</value>
        public string HeaderImage { get; set; }

        /// <summary>
        ///     Gets the header cloudinary image.
        /// </summary>
        /// <value>The header cloudinary image.</value>
        [NotMapped]
        public CloudinaryImage HeaderCloudinaryImage => new CloudinaryImage(HeaderImage);

        /// <summary>
        ///     Gets or sets the footer image.
        /// </summary>
        /// <value>The footer image.</value>
        public string FooterImage { get; set; }

        /// <summary>
        ///     Gets the footer cloudinary image.
        /// </summary>
        /// <value>The footer cloudinary image.</value>
        [NotMapped]
        public CloudinaryImage FooterCloudinaryImage => new CloudinaryImage(FooterImage);
    }

    /// <summary>
    ///     Class CampaignContentStatus.
    /// </summary>
    public class CampaignContentStatus
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the main text.
        /// </summary>
        /// <value>The main text.</value>
        public string MainText { get; set; }

        /// <summary>
        ///     Gets or sets the secondary text.
        /// </summary>
        /// <value>The secondary text.</value>
        public string SecondaryText { get; set; }

        /// <summary>
        ///     Gets the header cloudinary image.
        /// </summary>
        /// <value>The header cloudinary image.</value>
        [NotMapped]
        public CloudinaryImage HeaderCloudinaryImage => new CloudinaryImage(HeaderImage);

        /// <summary>
        ///     Gets or sets the header image.
        /// </summary>
        /// <value>The header image.</value>
        public string HeaderImage { get; set; }


        /// <summary>
        ///     Gets the footer cloudinary image.
        /// </summary>
        /// <value>The footer cloudinary image.</value>
        [NotMapped]
        public CloudinaryImage FooterCloudinaryImage => new CloudinaryImage(FooterImage);

        /// <summary>
        ///     Gets or sets the footer image.
        /// </summary>
        /// <value>The footer image.</value>
        public string FooterImage { get; set; }
    }

    /// <summary>
    ///     Class CampaignContentTermsAndConditions.
    /// </summary>
    public class CampaignContentTermsAndConditions
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
    }
}