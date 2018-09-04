using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LeadGeneration.Data;
using LeadGeneration.Models;
using LeadGeneration.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace LeadGeneration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            // Add application services.
            services.AddTransient<EmailSender>();
            services.AddTransient<LeadGenerationService>();


            var sqlStorage = new SqlServerStorage(Configuration.GetConnectionString("DefaultConnection"));

            services.AddHangfire(x =>
            {
                x.UseStorage(sqlStorage);
                x.UseDefaultActivator();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Lead Generation API", Version = "v1" });
            });


            services.AddMvc();
        }

        public class HangfireAuthorizeFilter : IDashboardAuthorizationFilter
        {
            public bool Authorize(DashboardContext context)
            {
                bool val1 = (context.GetHttpContext().User != null) && context.GetHttpContext().User.Identity.IsAuthenticated;
                return val1;
            }
        }

        private void ConfigHangfire(IApplicationBuilder app, IHostingEnvironment env)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });

            if (env.IsDevelopment())
            {

                app.UseHangfireDashboard("/Hangfire", new DashboardOptions
                {
                    Authorization = new[] { new HangfireAuthorizeFilter() }
                });

                var options = new BackgroundJobServerOptions
                {
                    Queues = new[] { "default" },
                    WorkerCount = 1
                };

                //app.UseHangfireServer(options);

            }
            else
            {
                var options = new BackgroundJobServerOptions
                {
                    Queues = new[] { "default" },
                    WorkerCount = 8,

                };

                app.UseHangfireDashboard("/Hangfire", new DashboardOptions
                {
                    Authorization = new[] { new HangfireAuthorizeFilter() }
                });
                app.UseHangfireServer(options);
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lead Generation API");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            ConfigHangfire(app, env);

        }
    }
}