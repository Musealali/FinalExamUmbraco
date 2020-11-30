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
        private readonly ISecurityIssuePost _ISecurityIssuePostService;

        public SecurityIssuePostController(UmbracoDbContext umbracoDbContext)
        {
            _umbracoDbContext = umbracoDbContext;
        }
        
        [HttpGet]
        public IActionResult Index(int id)
        {

            var securityIssuePostToFind =  _ISecurityIssuePostService.GetById(id);

            var model = new SecurityIssuePostViewModel
            {
                securityIssuePost = securityIssuePostToFind
            };


            if (model == null) { return View(NotFound()); }
            
            return View(model);
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
        public async Task<IActionResult> Create(SecurityIssuePost securityIssuePost) // Responsible for returning the correct View, whenever a user WANTS to create a securityIssuePost
        {
           await using (_umbracoDbContext)
            {
                List<CMSComponent> cms = GetCMSComponents(CMSComponent.ComponentType.CMS);
                ViewBag.CMS = cms;
                List<CMSComponent> packages = GetCMSComponents(CMSComponent.ComponentType.Package);
                ViewBag.Packages = packages;
                List<ComponentVersion> formsVersions = GetVersions("Forms");
                ViewBag.FormsVersions = formsVersions;
                List<ComponentVersion> uSyncVersions = GetVersions("uSync");
                ViewBag.uSyncVersions = uSyncVersions;
                List<ComponentVersion> umbracoCMSVersions = GetVersions("Umbraco CMS");
                ViewBag.UmbracoCMSVersions = umbracoCMSVersions;
                List<ComponentVersion> umbracoUNOVersions = GetVersions("Umbraco UNO");
                ViewBag.UmbracoUNOVersions = umbracoUNOVersions;
                List<ComponentVersion> umbracoHearthbreakVersions = GetVersions("Umbraco Hearthbreak");
                ViewBag.UmbracoHearthbreakVersions = umbracoHearthbreakVersions;
                List<ComponentVersion> umbracoCloudVersions = GetVersions("Umbraco Cloud");
                ViewBag.UmbracoCloudVersions = umbracoCloudVersions;

                formsVersions.Sort(SortVersions);
                uSyncVersions.Sort(SortVersions);
                umbracoCMSVersions.Sort(SortVersions);
                umbracoUNOVersions.Sort(SortVersions);
                umbracoHearthbreakVersions.Sort(SortVersions);
                umbracoCloudVersions.Sort(SortVersions);
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

        public List<ComponentVersion> GetVersions (string ComponentName)
        {
            return _umbracoDbContext.ComponentVersions.Where(cv => cv.CMSComponents.Any(c => c.Name == ComponentName)).ToList();
        }
        public List<CMSComponent> GetCMSComponents(CMSComponent.ComponentType componentType)
        {
            return _umbracoDbContext.CMSComponents.Where(c => c.CType == componentType).ToList();
        }

        public int SortVersions (ComponentVersion x, ComponentVersion y)
        {
            if (x.VersionNumber == null && y.VersionNumber == null) return 0;
            else if (x.VersionNumber == null) return -1;
            else if (y.VersionNumber == null) return 1;
            else return x.VersionNumber.CompareTo(y.VersionNumber);
        }
}

    
}
