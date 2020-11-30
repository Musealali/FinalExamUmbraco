using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Data.Models;

namespace web_platform.Service
{
    public class ComponentVersionService : IComponentVersion
    {
        private readonly UmbracoDbContext _umbracoDbContext;
        public ComponentVersionService(UmbracoDbContext umbracoDbContext)
        {
            _umbracoDbContext = umbracoDbContext;
        }

        public async Task<List<ComponentVersion>> GetComponentVersionByComponentName(string componentName)
        {
            return _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == componentName)).ToList();

        }
    }
}
