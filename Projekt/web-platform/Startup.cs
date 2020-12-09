using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web_platform.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using web_platform.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using web_platform.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace web_platform
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            if(WebHostEnvironment.IsDevelopment())
                services.AddDbContext<UmbracoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dev")));

            if (WebHostEnvironment.IsProduction())
                services.AddDbContext<UmbracoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("prod")));

            //Add application services.
            services.AddScoped<ISecurityIssuePost, SecurityIssuePostService>();


            // Add Identity to the project with the specified custom User & Role
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<UmbracoDbContext>()
                .AddDefaultTokenProviders();

            

            // After adding identity, we configure the cookie authentication with a path to the login action
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
            {
                options.LoginPath = "/Authentication/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Add a default user and sign it in, if in development environment for testing purposes
                IdentityInitializer.InitializeDevelopment(app.ApplicationServices);
            }
            else
            {
                app.UseExceptionHandler("/SecurityIssuePost/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // This allows us to use the [Authorize] data attribute on controllers or actions, to prevent access if a user is not signed in.
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SecurityIssuePost}/{action=Index}/{id?}");
            });
        }
    }
}
