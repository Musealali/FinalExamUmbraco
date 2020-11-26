using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Models;
using Version = web_platform.Models.ComponentVersion;

namespace web_platform.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(UmbracoDbContext context)
        {
            context.Database.EnsureCreated();
            Version version11 = new Version() { VersionNumber = "1.1" };
            Version version12 = new Version() { VersionNumber = "1.2" };
            Version version13 = new Version() { VersionNumber = "1.3" };
            Version version14 = new Version() { VersionNumber = "1.4" };
            Version version21 = new Version() { VersionNumber = "2.1" };
            Version version22 = new Version() { VersionNumber = "2.2" };
            Version version23 = new Version() { VersionNumber = "2.3" };
            Version version24 = new Version() { VersionNumber = "2.4" };
            Version version31 = new Version() { VersionNumber = "3.1" };
            Version version32 = new Version() { VersionNumber = "3.2" };
            Version version33 = new Version() { VersionNumber = "3.3" };
            Version version34 = new Version() { VersionNumber = "3.4" };
            Package forms = new Package("Forms");
            Package uSync = new Package("uSync");
            CMS umbracoUNO = new CMS() { Name = "Umbraco UNO" };
            CMS umbracoCloud = new CMS() { Name = "Umbraco Cloud" };
            CMS umbracoHearthbreak = new CMS() { Name = "Umbraco Hearthbreak" };
            CMS umbracoCMS = new CMS() { Name = "Umbraco CMS" };
            CMSComponentVersion cmsComponentVersion1 = new CMSComponentVersion() { CMSComponent = umbracoUNO, Version = version11 };
            CMSComponentVersion cmsComponentVersion2 = new CMSComponentVersion() { CMSComponent = umbracoUNO, Version = version13 };
            CMSComponentVersion cmsComponentVersion3 = new CMSComponentVersion() { CMSComponent = umbracoUNO, Version = version21 };
            CMSComponentVersion cmsComponentVersion4 = new CMSComponentVersion() { CMSComponent = umbracoUNO, Version = version24 };
            CMSComponentVersion cmsComponentVersion5 = new CMSComponentVersion() { CMSComponent = umbracoCloud, Version = version12 };
            CMSComponentVersion cmsComponentVersion6 = new CMSComponentVersion() { CMSComponent = umbracoCloud, Version = version22 };
            CMSComponentVersion cmsComponentVersion7 = new CMSComponentVersion() { CMSComponent = umbracoCloud, Version = version32 };
            CMSComponentVersion cmsComponentVersion8 = new CMSComponentVersion() { CMSComponent = umbracoHearthbreak, Version = version13 };
            CMSComponentVersion cmsComponentVersion9 = new CMSComponentVersion() { CMSComponent = umbracoHearthbreak, Version = version23 };
            CMSComponentVersion cmsComponentVersion10 = new CMSComponentVersion() { CMSComponent = umbracoHearthbreak, Version = version33 };
            CMSComponentVersion cmsComponentVersion11 = new CMSComponentVersion() { CMSComponent = umbracoHearthbreak, Version = version34 };
            CMSComponentVersion cmsComponentVersion12 = new CMSComponentVersion() { CMSComponent = umbracoCMS, Version = version13 };
            CMSComponentVersion cmsComponentVersion13 = new CMSComponentVersion() { CMSComponent = umbracoCMS, Version = version22 };
            CMSComponentVersion cmsComponentVersion14 = new CMSComponentVersion() { CMSComponent = umbracoCMS, Version = version31 };
            CMSComponentVersion cmsComponentVersion15 = new CMSComponentVersion() { CMSComponent = forms, Version = version11 };
            CMSComponentVersion cmsComponentVersion16 = new CMSComponentVersion() { CMSComponent = forms, Version = version22 };
            CMSComponentVersion cmsComponentVersion17 = new CMSComponentVersion() { CMSComponent = forms, Version = version33 };
            CMSComponentVersion cmsComponentVersion18 = new CMSComponentVersion() { CMSComponent = forms, Version = version34 };
            CMSComponentVersion cmsComponentVersion19 = new CMSComponentVersion() { CMSComponent = uSync, Version = version11 };
            CMSComponentVersion cmsComponentVersion20 = new CMSComponentVersion() { CMSComponent = uSync, Version = version14 };
            CMSComponentVersion cmsComponentVersion21 = new CMSComponentVersion() { CMSComponent = uSync, Version = version22 };
            CMSComponentVersion cmsComponentVersion22 = new CMSComponentVersion() { CMSComponent = uSync, Version = version33 };

            if (!context.CMS.Any())
            {
                context.CMS.Add(umbracoUNO);
                context.CMS.Add(umbracoCloud);
                context.CMS.Add(umbracoHearthbreak);
                context.CMS.Add(umbracoCMS);
            }

            if (!context.Package.Any())
            {
                context.Package.Add(forms);
                context.Package.Add(uSync);
            }
            
            if (!context.ComponentVersion.Any())
            {
                context.ComponentVersion.Add(version11);
                context.ComponentVersion.Add(version12);
                context.ComponentVersion.Add(version13);
                context.ComponentVersion.Add(version14);
                context.ComponentVersion.Add(version21);
                context.ComponentVersion.Add(version22);
                context.ComponentVersion.Add(version23);
                context.ComponentVersion.Add(version24);
                context.ComponentVersion.Add(version31);
                context.ComponentVersion.Add(version32);
                context.ComponentVersion.Add(version33);
                context.ComponentVersion.Add(version34);
            }

            context.SaveChanges();

            if (!context.CMSComponentVersion.Any())
            {
                context.CMSComponentVersion.Add(cmsComponentVersion1);
                context.CMSComponentVersion.Add(cmsComponentVersion2);
                context.CMSComponentVersion.Add(cmsComponentVersion3);
                context.CMSComponentVersion.Add(cmsComponentVersion4);
                context.CMSComponentVersion.Add(cmsComponentVersion5);
                context.CMSComponentVersion.Add(cmsComponentVersion6);
                context.CMSComponentVersion.Add(cmsComponentVersion7);
                context.CMSComponentVersion.Add(cmsComponentVersion8);
                context.CMSComponentVersion.Add(cmsComponentVersion9);
                context.CMSComponentVersion.Add(cmsComponentVersion10);
                context.CMSComponentVersion.Add(cmsComponentVersion11);
                context.CMSComponentVersion.Add(cmsComponentVersion12);
                context.CMSComponentVersion.Add(cmsComponentVersion13);
                context.CMSComponentVersion.Add(cmsComponentVersion14);
                context.CMSComponentVersion.Add(cmsComponentVersion15);
                context.CMSComponentVersion.Add(cmsComponentVersion16);
                context.CMSComponentVersion.Add(cmsComponentVersion17);
                context.CMSComponentVersion.Add(cmsComponentVersion18);
                context.CMSComponentVersion.Add(cmsComponentVersion19);
                context.CMSComponentVersion.Add(cmsComponentVersion20);
                context.CMSComponentVersion.Add(cmsComponentVersion21);
                context.CMSComponentVersion.Add(cmsComponentVersion22);
            }

            context.SaveChanges();

        }
     
    }
}
