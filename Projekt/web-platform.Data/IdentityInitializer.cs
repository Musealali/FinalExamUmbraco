using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public class IdentityInitializer
    {
        public static void InitializeDevelopment(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                RoleManager<ApplicationRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                ApplicationRole adminRole = new ApplicationRole("Administrator");

                if (!roleManager.RoleExistsAsync("Administrator").Result)
                {
                    _ = roleManager.CreateAsync(adminRole).Result;
                }


                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var user = userManager.FindByEmailAsync("default@default.com").Result;
                if(user == null)
                {
                    user = new ApplicationUser() { UserName = "default@default.com", Email = "default@default.com" };
                    var createResult = userManager.CreateAsync(user, "Default1!").Result;
                }

                if(!userManager.IsInRoleAsync(user, adminRole.Name).Result)
                {
                    var roleAddResult = userManager.AddToRoleAsync(user, adminRole.Name).Result;
                }
            }
        }
    }
}
