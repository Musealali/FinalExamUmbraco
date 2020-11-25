using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Models;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;

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
