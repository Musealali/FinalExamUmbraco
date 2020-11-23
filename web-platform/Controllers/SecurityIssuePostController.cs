using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Models;
using System.Dynamic;

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
        public ActionResult Create(SecurityIssuePost securityIssuePost, CMSComponent cmsComponent, string componentType) // Responsible for getting the user input and storing the securityIssuePost
        {
            // Vi burde altså bare debugge vores actions i stedet for at lave en masse writelines XDXDXDXD
            CMSComponent componentToFind = null;

            switch(componentType)
            {
                case "package":
                    componentToFind = _umbracoDbContext.Package.Where(p => p.Name == cmsComponent.Name && p.Version == cmsComponent.Version).FirstOrDefault();
                    break;

                case "cms":
                    componentToFind = _umbracoDbContext.CMS.Where(c => c.Name == cmsComponent.Name && c.Version == cmsComponent.Version).FirstOrDefault();
                    break;
            }

            if(componentToFind == null) { return NotFound(); }

            securityIssuePost.CMSComponent = componentToFind;

            _umbracoDbContext.Add(securityIssuePost);
            _umbracoDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
