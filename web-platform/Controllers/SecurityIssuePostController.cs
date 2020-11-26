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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(SecurityIssuePost securityIssuePost) // Responsible for returning the correct View, whenever a user WANTS to create a securityIssuePost
        {
            using (_umbracoDbContext)
            {
                List<CMS> cms = _umbracoDbContext.CMS.ToList();
                ViewBag.CMS = cms;

                List<Package> packages = _umbracoDbContext.Package.ToList();
                ViewBag.Packages = packages;

                List<ComponentVersion> formsVersions = new List<ComponentVersion>();
                List<ComponentVersion> uSyncVersions = new List<ComponentVersion>();
                List<ComponentVersion> umbracoCMSVersions = new List<ComponentVersion>();
                List<ComponentVersion> umbracoUNOVersions = new List<ComponentVersion>();
                List<ComponentVersion> umbracoHearthbreakVersions = new List<ComponentVersion>();
                List<ComponentVersion> umbracoCloudVersions = new List<ComponentVersion>();
                new SelectList(_umbracoDbContext.ComponentVersion.ToList(), "Id", "Name");
                var cmsComponentVersions = _umbracoDbContext.CMSComponentVersion;
                foreach (CMSComponentVersion ccv in cmsComponentVersions)
                {
                    /*var umbracoCMSVersion = new SelectList(_umbracoDbContext.ComponentVersion
                        .Where(x => x.CMSComponents.any(y => y.name == "Umbraco CMS"))).Tolist();*/

                    List<ComponentVersion> umbracoCMSVersion = _umbracoDbContext.ComponentVersion
                        .Where(x => ccv.CMSComponent.Name.Equals("Umbraco CMS") && x.Id == ccv.Version.Id).ToList();

                    List<ComponentVersion> umbracoHearthbreakVersion = _umbracoDbContext.ComponentVersion
                        .Where(x => ccv.CMSComponent.Name.Equals("Umbraco Hearthbreak") && x.Id == ccv.Version.Id).ToList();

                    List<ComponentVersion> umbracoCloudVersion = _umbracoDbContext.ComponentVersion
                        .Where(x => ccv.CMSComponent.Name.Equals("Umbraco Cloud") && x.Id == ccv.Version.Id).ToList();

                    List<ComponentVersion> umbracoUNOVersion = _umbracoDbContext.ComponentVersion
                        .Where(x => ccv.CMSComponent.Name.Equals("Umbraco UNO") && x.Id == ccv.Version.Id).ToList();

                    List<ComponentVersion> formsVersion = _umbracoDbContext.ComponentVersion
                        .Where(x => ccv.CMSComponent.Name.Equals("Forms") && x.Id == ccv.Version.Id).ToList();

                    List<ComponentVersion> uSyncVersion = _umbracoDbContext.ComponentVersion
                        .Where(x => ccv.CMSComponent.Name.Equals("uSync") && x.Id == ccv.Version.Id).ToList();

                    foreach (ComponentVersion v in umbracoCMSVersion)
                    {
                        umbracoCMSVersions.Add(v);
                    }
                    foreach (ComponentVersion v in umbracoHearthbreakVersion)
                    {
                        umbracoHearthbreakVersions.Add(v);
                    }
                    foreach (ComponentVersion v in umbracoCloudVersion)
                    {
                        umbracoCloudVersions.Add(v);
                    }
                    foreach (ComponentVersion v in umbracoUNOVersion)
                    {
                        umbracoUNOVersions.Add(v);
                    }
                    foreach (ComponentVersion v in formsVersion)
                    {
                        formsVersions.Add(v);
                    }
                    foreach (ComponentVersion v in uSyncVersion)
                    {
                        uSyncVersions.Add(v);
                    }
                }

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
                ViewBag.formsVersions = formsVersions;
                ViewBag.uSyncVersions = uSyncVersions;
                ViewBag.umbracoCMSVersions = umbracoCMSVersions;
                ViewBag.umbracoUNOVersions = umbracoUNOVersions;
                ViewBag.umbracoHearthbreakVersions = umbracoHearthbreakVersions;
                ViewBag.umbracoCloudVersions = umbracoCloudVersions;
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SecurityIssuePost securityIssuePost, string name, string version, string componentType) // Responsible for getting the user input and storing the securityIssuePost
        {
            // Vi burde altså bare debugge vores actions i stedet for at lave en masse writelines XDXDXDXD
            CMSComponentVersion cMSComponentVersion = null;

            switch (componentType)
            {
                case "package":
                    cMSComponentVersion = await _umbracoDbContext.CMSComponentVersion.Where(c => c.CMSComponent.Name == name && c.Version.VersionNumber == version).FirstOrDefaultAsync();
                    break;

                case "cms":
                    cMSComponentVersion = await _umbracoDbContext.CMSComponentVersion.Where(c => c.CMSComponent.Name == name && c.Version.VersionNumber == version).FirstOrDefaultAsync();
                    break;
            }

            if (cMSComponentVersion == null) { return NotFound(); }

            securityIssuePost.CMSComponentVersion = cMSComponentVersion;

            _umbracoDbContext.Add(securityIssuePost);
            _umbracoDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }

    
}
