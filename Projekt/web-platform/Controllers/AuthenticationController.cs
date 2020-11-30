using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_platform.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {

            return Ok();
        }


        [HttpGet]
        public IActionResult RegisterView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {

            return Ok();
        }
    }
}
