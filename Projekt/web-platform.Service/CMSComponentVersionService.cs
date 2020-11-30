using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Data.Models;

namespace web_platform.Service
{
    public class CMSComponentVersionService : ICMSComponentVersion
    {
        private readonly UmbracoDbContext _umbracoDbContext;

        public CMSComponentVersionService(UmbracoDbContext umbracoDbContext)
        {
            _umbracoDbContext = umbracoDbContext;
        }
        public async Task<CMSComponentVersion> GetCMSComponentVersion(string name, string version, string componentType)
        {
            CMSComponentVersion cmsComponentVersion = null;
            switch (componentType)
            {
                case "package":
                    cmsComponentVersion = await _umbracoDbContext.CMSComponentVersions.Where(c => c.CMSComponent.Name == name && c.Version.VersionNumber == version).FirstOrDefaultAsync();
                    break;

                case "cms":
                    cmsComponentVersion = await _umbracoDbContext.CMSComponentVersions.Where(c => c.CMSComponent.Name == name && c.Version.VersionNumber == version).FirstOrDefaultAsync();
                    break;
            }

            return cmsComponentVersion;
        }
    }
}
