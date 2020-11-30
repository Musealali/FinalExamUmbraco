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
        public async Task<List<CMSComponent>> GetCMSComponentsByType(CMSComponent.ComponentType componentType)
        {
            return _umbracoDbContext.CMSComponents.Where(c => c.CType == componentType).ToList();
        }

        public CMSComponent.ComponentType GetComponentTypeCMS()
        {
            return CMSComponent.ComponentType.CMS;
        }

        public CMSComponent.ComponentType GetComponentTypePackage()
        {
            return CMSComponent.ComponentType.Package;
        }
    }
}
