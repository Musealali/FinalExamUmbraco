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
        public async Task<IActionResult> Create(SecurityIssuePost securityIssuePost)
        {
            var resultForSubmission = _umbracoDbContext.AddAsync(securityIssuePost);
            await _umbracoDbContext.SaveChangesAsync();
            return View("Index", securityIssuePost);
        }
        [HttpPost]
        public ActionResult CreateSecurityIssuePost(SecurityIssuePost securityIssuePost, string name, string version, string componentType)
        {
            Console.WriteLine(securityIssuePost.Title);
            Console.WriteLine(securityIssuePost.IssueDescription);
            Console.WriteLine(securityIssuePost.IssueReproduction);
            if (componentType.Equals("package"))
            {
                Package package = new Package(version, name);
                securityIssuePost.Component = package;
            }
            if (componentType.Equals("cms"))
            {
                CMS cms = new CMS(version, name);
                securityIssuePost.Component = cms;
            }
            Console.WriteLine(securityIssuePost.Component.Name);
            Console.WriteLine(securityIssuePost.Component.Version);
            return Redirect("../home/index");
        }
    }
}
