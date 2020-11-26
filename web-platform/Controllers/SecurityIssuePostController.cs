using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Models;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace web_platform.Controllers
{
    public class SecurityIssuePostController : Controller
    {
        private readonly UmbracoDbContext _umbracoDbContext;

        public SecurityIssuePostController(UmbracoDbContext umbracoDbContext)
        {
            _umbracoDbContext = umbracoDbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var securityIssuePostToFind = await _umbracoDbContext.SecurityIssuePosts
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.CMSComponent)
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.Version)
                    .Where(s => s.Id == id).FirstOrDefaultAsync();
            
            if(securityIssuePostToFind == null) { return View(NotFound()); }
            
            return View(securityIssuePostToFind);
        }
        
        [HttpGet]
        public async Task<IActionResult> ViewAllPosts()
        {
            var posts = await _umbracoDbContext.SecurityIssuePosts
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.CMSComponent)
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.Version)
                    .ToListAsync();

            return View(posts);
        }

        
        [HttpGet]
        public IActionResult Create(SecurityIssuePost securityIssuePost) // Responsible for returning the correct View, whenever a user WANTS to create a securityIssuePost
        {
            using (_umbracoDbContext)
            {
                List<CMSComponent> cms = _umbracoDbContext.CMSComponents.Where(c => c.CType == CMSComponent.ComponentType.CMS).ToList();
                ViewBag.CMS = cms;
                List<CMSComponent> packages = _umbracoDbContext.CMSComponents.Where(p => p.CType == CMSComponent.ComponentType.Package).ToList();
                ViewBag.Packages = packages;
                List<ComponentVersion> formsVersions = _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == "Forms")).ToList();
                ViewBag.FormsVersions = formsVersions;
                List<ComponentVersion> uSyncVersions = _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == "uSync")).ToList();
                ViewBag.uSyncVersions = uSyncVersions;
                List<ComponentVersion> umbracoCMSVersions = _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == "Umbraco CMS")).ToList();
                ViewBag.UmbracoCMSVersions = umbracoCMSVersions;
                List<ComponentVersion> umbracoUNOVersions = _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == "Umbraco UNO")).ToList();
                ViewBag.UmbracoUNOVersions = umbracoUNOVersions;
                List<ComponentVersion> umbracoHearthbreakVersions = _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == "Umbraco Hearthbreak")).ToList();
                ViewBag.UmbracoHearthbreakVersions = umbracoHearthbreakVersions;
                List<ComponentVersion> umbracoCloudVersions = _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == "Umbraco Cloud")).ToList();
                ViewBag.UmbracoCloudVersions = umbracoCloudVersions;
                formsVersions.Sort(delegate (ComponentVersion x, ComponentVersion y)
                {
                    if (x.VersionNumber == null && y.VersionNumber == null) return 0;
                    else if (x.VersionNumber == null) return -1;
                    else if (y.VersionNumber == null) return 1;
                    else return x.VersionNumber.CompareTo(y.VersionNumber);
                });
                uSyncVersions.Sort(delegate (ComponentVersion x, ComponentVersion y)
                {
                    if (x.VersionNumber == null && y.VersionNumber == null) return 0;
                    else if (x.VersionNumber == null) return -1;
                    else if (y.VersionNumber == null) return 1;
                    else return x.VersionNumber.CompareTo(y.VersionNumber);
                });
                umbracoCMSVersions.Sort(delegate (ComponentVersion x, ComponentVersion y)
                {
                    if (x.VersionNumber == null && y.VersionNumber == null) return 0;
                    else if (x.VersionNumber == null) return -1;
                    else if (y.VersionNumber == null) return 1;
                    else return x.VersionNumber.CompareTo(y.VersionNumber);
                });
                umbracoUNOVersions.Sort(delegate (ComponentVersion x, ComponentVersion y)
                {
                    if (x.VersionNumber == null && y.VersionNumber == null) return 0;
                    else if (x.VersionNumber == null) return -1;
                    else if (y.VersionNumber == null) return 1;
                    else return x.VersionNumber.CompareTo(y.VersionNumber);
                });
                umbracoHearthbreakVersions.Sort(delegate (ComponentVersion x, ComponentVersion y)
                {
                    if (x.VersionNumber == null && y.VersionNumber == null) return 0;
                    else if (x.VersionNumber == null) return -1;
                    else if (y.VersionNumber == null) return 1;
                    else return x.VersionNumber.CompareTo(y.VersionNumber);
                });
                umbracoCloudVersions.Sort(delegate (ComponentVersion x, ComponentVersion y)
                {
                    if (x.VersionNumber == null && y.VersionNumber == null) return 0;
                    else if (x.VersionNumber == null) return -1;
                    else if (y.VersionNumber == null) return 1;
                    else return x.VersionNumber.CompareTo(y.VersionNumber);
                });
                
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SecurityIssuePost securityIssuePost, string name, string version, string componentType) // Responsible for getting the user input and storing the securityIssuePost
        {
            if (!ModelState.IsValid) { return RedirectToAction("Index", securityIssuePost); }


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

            if (cMSComponentVersion == null) { return NotFound(); }


            securityIssuePost.CMSComponentVersion = cMSComponentVersion;

            _umbracoDbContext.Add(securityIssuePost);
            _umbracoDbContext.SaveChanges();

            return RedirectToAction("Index", "SecurityIssuePost", new { id=securityIssuePost.Id });
        }
    }

    
}
