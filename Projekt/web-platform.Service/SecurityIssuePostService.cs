using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Data.Models;

namespace web_platform.Service
{
    public class SecurityIssuePostService : ISecurityIssuePost
    {
        private readonly UmbracoDbContext _umbracoDbContext;

        public SecurityIssuePostService(UmbracoDbContext umbracoDbcontext)
        {
            _umbracoDbContext = umbracoDbcontext;
        }


        public Task Create(SecurityIssuePost securityIssuePost)
        {
            CMSComponentVersion cMSComponentVersion = null;
            switch (componentType)
            {
                case "package":
                    cMSComponentVersion = await _umbracoDbContext.CMSComponentVersions.Where(c => c.CMSComponent.Name == name && c.Version.VersionNumber == version).FirstOrDefaultAsync();
                    break;

                case "cms":
                    cMSComponentVersion = await _umbracoDbContext.CMSComponentVersions.Where(c => c.CMSComponent.Name == name && c.Version.VersionNumber == version).FirstOrDefaultAsync();
                    break;
            }
        }

        public IEnumerable<SecurityIssuePost> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SecurityIssuePost> GetById(int id)
        {
            var securityIssuePostToFind = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.Id == id)
                .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.CMSComponent)
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.Version)
                    .Where(s => s.Id == id).FirstOrDefaultAsync();

            return securityIssuePostToFind;

        }
    }
}
