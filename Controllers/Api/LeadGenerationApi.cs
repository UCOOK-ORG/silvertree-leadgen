// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="LeadGenerationApi.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using Hangfire;
using LeadGeneration.Data;
using LeadGeneration.Models;
using LeadGeneration.Models.ApiViewModels;
using LeadGeneration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadGeneration.Controllers
{
    /// <summary>
    /// Class LeadGenerationApi.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/LeadGeneration")]
    public class LeadGenerationApi : Controller
    {
        /// <summary>
        /// The lead generation service
        /// </summary>
        private readonly LeadGenerationService _leadGenerationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadGenerationApi"/> class.
        /// </summary>
        /// <param name="leadGenerationService">The lead generation service.</param>
        public LeadGenerationApi(LeadGenerationService leadGenerationService)
        {
            _leadGenerationService = leadGenerationService;
        }

        /// <summary>
        /// Gets the campaign.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="slug">The slug.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetCampaign")]
        [ProducesResponseType(typeof(Campaign), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult GetCampaign(int? id, string slug = null)
        {
            try
            {
                var campaign = _leadGenerationService.GetCampaign(id, slug);
                return Ok(campaign);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Sends the referral email.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("SendReferralEmail")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult SendReferralEmail(SendReferralEmailViewModel data)
        {
            try
            {
                _leadGenerationService.SendReferralEmail(data.Email, data.Name, data.Surname, data.SenderId);
                return Ok(new SuccessResponse() { Message = "Referral email successfully sent" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Gets the lead.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetLead")]
        [ProducesResponseType(typeof(CampaignLead), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult GetLead(int id)
        {
            try
            {
                var lead = _leadGenerationService.GetLead(id);
                return Ok(lead);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Signs up.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("SignUp")]
        [ProducesResponseType(typeof(CampaignLead), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult SignUp(SignUpViewModel data)
        {
            try
            {
                var source = "";
                var medium = "";
                if (data.UtmViewModel != null)
                {
                    source = data.UtmViewModel.Source;
                    medium = data.UtmViewModel.Medium;
                }

                var lead = _leadGenerationService.SignUp(data.Email, data.Name, data.Surname, data.CampaignId, data.ReferralId, source, medium);
                return Ok(lead);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Signs lead in.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("SignIn")]
        [ProducesResponseType(typeof(CampaignLead), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult SignIn(SignInViewModel data)
        {
            try
            {
                var lead = _leadGenerationService.SignIn(data.Email, data.Phone, data.CampaignId);
                return Ok(lead);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = ex.Message
                });
            }
        }
    }
}