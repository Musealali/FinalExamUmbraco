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
    public class CMSComponentService : ICMSComponent
    {
        private readonly UmbracoDbContext _umbracoDbContext;

        public CMSComponentService(UmbracoDbContext umbracoDbContext)
        {
            _umbracoDbContext = umbracoDbContext;
        }
        public async Task<List<CMSComponent>> GetCMSComponentsByType(ComponentType componentType)
        {
            return await _umbracoDbContext.CMSComponents.Where(c => c.ComponentType == componentType).ToListAsync();
        }

        public ComponentType GetComponentTypeCMS()
        {
            return ComponentType.CMS;
        }

        public ComponentType GetComponentTypePackage()
        {
            return ComponentType.Package;
        }
    }
}
