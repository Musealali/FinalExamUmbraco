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
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var securityIssuePostToFind = await _umbracoDbContext.SecurityIssuePosts
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.CMSComponent)
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.Version)
                    .Where(s => s.Id == id).FirstOrDefaultAsync();
            
            if(securityIssuePostToFind == null) { return NotFound(); }
            
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

            return RedirectToAction("Index", "SecurityIssuePost", new { id=securityIssuePost.Id });
        }
    }
}
