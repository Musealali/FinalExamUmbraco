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
        public IActionResult Create()
        {
            SecurityIssuePost model = new SecurityIssuePost();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateSecurityIssuePost(SecurityIssuePost securityIssuePost)
        {
            Console.WriteLine(securityIssuePost.Title + securityIssuePost.IssueDescription + securityIssuePost.IssueReproduction);
            return Redirect("../home/index");
        }
    }
}
