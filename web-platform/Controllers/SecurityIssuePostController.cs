using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;

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

        [HttpPost]
        public async Task<IActionResult> CreateSecurityIssuePost()
        {
            //TODO
            return View();
        }
    }
}
