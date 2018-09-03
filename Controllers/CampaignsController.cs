// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="CampaignsController.cs" company="LeadGeneration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using LeadGeneration.Data;
using LeadGeneration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadGeneration.Controllers
{
    /// <summary>
    ///     Class CampaignsController.
    ///     Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CampaignsController : Controller
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CampaignsController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public CampaignsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Campaigns
        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) return RedirectToAction("Login", "Account");
            var applicationDbContext = _context.Campaigns
                .Include(c => c.CampaignContent)
                .Include(c => c.CampaignSettings).Where(a => a.OrganisationId == user.OrganisationId);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Campaigns/Create
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        ///     Creates the specified campaign.
        /// </summary>
        /// <param name="campaign">The campaign.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campaign campaign)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                campaign.OrganisationId = user.OrganisationId;
                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var campaign = await _context.Campaigns
                .Include(c => c.CampaignContent)
                .ThenInclude(a => a.SignUpPage)
                .Include(c => c.CampaignContent)
                .ThenInclude(a => a.StatusPage)
                .Include(c => c.CampaignContent)
                .ThenInclude(a => a.SocialContent)
                .Include(c => c.CampaignContent)
                .ThenInclude(a => a.TermsAndConditions)
                .Include(c => c.CampaignContent)
                .Include(c => c.CampaignSettings)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (campaign == null) return NotFound();

            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="campaign">The campaign.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Campaign campaign)
        {
            if (id != campaign.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var campaign = await _context.Campaigns
                .Include(c => c.CampaignContent)
                .Include(c => c.CampaignSettings)
                .Include(c => c.Organisation)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (campaign == null) return NotFound();

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        /// <summary>
        ///     Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaign = await _context.Campaigns.SingleOrDefaultAsync(m => m.Id == id);
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        ///     Campaigns the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CampaignExists(int id)
        {
            return _context.Campaigns.Any(e => e.Id == id);
        }
    }
}