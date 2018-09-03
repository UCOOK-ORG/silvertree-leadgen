using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeadGeneration.Models;

namespace LeadGeneration.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationMandrillSettings> OrganisationMandrillSettings { get; set; }
        public DbSet<OrganisationSocialSettings> OrganisationSocialSettings { get; set; }
        public DbSet<OrganisationGeneralSettings> OrganisationGeneralSettings { get; set; }


        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignSettings> CampaignSettings { get; set; }
        public DbSet<CampaignContent> CampaignContent { get; set; }

        public DbSet<CampaignContentSignUp> CampaignContentSignUp { get; set; }
        public DbSet<CampaignContentStatus> CampaignContentStatus { get; set; }
        public DbSet<CampaignContentTermsAndConditions> CampaignContentTermsAndConditions { get; set; }
        public DbSet<CampaignContentSocial> CampaignContentSocial { get; set; }


        public DbSet<CampaignLead> CampaignLeads { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}