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
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var user = new ApplicationUser() { UserName = "default@default.com", Email = "default@default.com" };
                var createResult = userManager.CreateAsync(user, "Default1!").Result;
            }
        }
    }
}
