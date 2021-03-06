﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewSec.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViewSec.Models;
using Microsoft.AspNetCore.Identity.UI;
using System.Data.SqlClient;

namespace ViewSec
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<GmmContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //TODO Identity password options aren't used
            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options => {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddDefaultTokenProviders();

            services.AddTransient<IBand, BandData>();
            services.AddTransient<IBandKleedkamersData, BandKleedkamersData>();
            services.AddTransient<IBandProductieUnits, BandProductieUnitsData>();
            services.AddTransient<ICatering, CateringData>();
            services.AddTransient<IFunction, FunctionData>();
            services.AddTransient<IKleedkamer, KleedkamerData>();
            services.AddTransient<ILogistic, LogisticData>();
            services.AddTransient<IMember, MemberData>();
            services.AddTransient<IOptreden, OptredenData>();
            services.AddTransient<IProductieUnit, ProductieUnitData>();
            services.AddTransient<ISpecial, SpecialData>();
            services.AddTransient<IStage, StageData>();
            services.AddTransient<ITent, TentData>();
            services.AddTransient<IVoorziening, VoorzieningData>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            GmmContext context, ApplicationDbContext idContext,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy(); //Removed cookie warning

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
            try
            {
                UsersInitializer.Initialize(idContext, userManager, roleManager).Wait();
            }
            catch (System.AggregateException ae)
            {
                //SqlException: Invalid object name 'AspNetRoles'
                //Identity tabbellen worden niet aangemaakt bij nieuwe database.
                //Oplossing: Update-Database
            }
        }
    }
}
