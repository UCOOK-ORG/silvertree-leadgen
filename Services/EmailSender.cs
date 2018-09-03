// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="EmailSender.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Mandrill;
using Mandrill.Model;

namespace LeadGeneration.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    /// <summary>
    ///     Class EmailSender.
    /// </summary>
    public class EmailSender
    {
        /// <summary>
        ///     Sends the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="mandrillTemplate">The mandrill template.</param>
        /// <param name="subjectLine">The subject line.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="fromEmail">From email.</param>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="Exception">Customer Email cannot be null</exception>
        public void SendEmail(string email, string mandrillTemplate, string subjectLine,
            Dictionary<string, object> variables, string fromEmail, string apiKey)
        {
            if (email == null) throw new Exception("Customer Email cannot be null");

            var api = new MandrillApi(apiKey);
            var message = new MandrillMessage
            {
                FromEmail = fromEmail
            };
            message.AddTo(email);

            message.Merge = true;
            message.MergeLanguage = MandrillMessageMergeLanguage.Handlebars;
            message.Subject = subjectLine;

            message.ReplyTo = fromEmail;

            foreach (var variable in variables) message.AddRcptMergeVars(email, variable.Key, variable.Value);

            var result = api.Messages.SendTemplateAsync(message, mandrillTemplate).Result;
        }
    }
}