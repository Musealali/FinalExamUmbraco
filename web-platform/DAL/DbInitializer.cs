using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Models;

namespace web_platform.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(UmbracoDbContext context)
        {
            context.Database.EnsureCreated();


            if (context.CMS.Any() && context.Package.Any())
            {
                return; //DB has been seeded
            }

            CMS cms = new CMS("CMS", "V8.9.1");
            Package formsPackage = new Package("Forms", "8.6.9");
            Package uSyncPackage = new Package("uSync", "6.2.1");


            context.CMS.Add(cms);
            context.Package.Add(formsPackage);
            context.Package.Add(uSyncPackage);
        }
     
    }
}
