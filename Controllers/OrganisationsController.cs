// ***********************************************************************
// Assembly         : LeadGeneration
// Author           : Enrico
// Created          : 08-29-2018
//
// Last Modified By : Enrico
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="OrganisationsController.cs" company="LeadGeneration">
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
    /// Class OrganisationsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class OrganisationsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationsController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public OrganisationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Organisations
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) return RedirectToAction("Login", "Account");

            var applicationDbContext = _context.Organisations
                .Include(o => o.OrganisationGeneralSettings)
                .Include(o => o.OrganisationMandrillSettings)
                .Include(o => o.OrganisationSocialSettings);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Organisations/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified organisation.
        /// </summary>
        /// <param name="organisation">The organisation.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(organisation);
        }

        // GET: Organisations/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var organisation = await _context.Organisations
                .Include(o => o.OrganisationGeneralSettings)
                .Include(o => o.OrganisationMandrillSettings)
                .Include(o => o.OrganisationSocialSettings)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (organisation == null) return NotFound();

            return View(organisation);
        }

        // POST: Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="organisation">The organisation.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Organisation organisation)
        {
            if (id != organisation.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisationExists(organisation.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(organisation);
        }

        // GET: Organisations/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var organisation = await _context.Organisations
                .Include(o => o.OrganisationGeneralSettings)
                .Include(o => o.OrganisationMandrillSettings)
                .Include(o => o.OrganisationSocialSettings)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (organisation == null) return NotFound();

            return View(organisation);
        }

        // POST: Organisations/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisation = await _context.Organisations.SingleOrDefaultAsync(m => m.Id == id);
            _context.Organisations.Remove(organisation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Organisations the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool OrganisationExists(int id)
        {
            return _context.Organisations.Any(e => e.Id == id);
        }
    }
}