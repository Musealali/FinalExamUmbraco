using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_platform.Data.Models;
using web_platform.Models;

namespace web_platform.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Take input data and check if user exists and information matches. Sign them in and return
        /// </summary>
        /// <param name="avm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationViewModel avm)
        {
            if(!ModelState.IsValid) { return View(avm); }

            var user = await _userManager.FindByEmailAsync(avm.Email);

            if(user == null) { ModelState.AddModelError("", "Incorrect information"); }

            await _signInManager.SignInAsync(user, true);

            var referer = Request.Path;

            return RedirectToAction("Index", "SecurityIssuePost");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// Takes input data and create a new user. Sign them in and return
        /// </summary>
        /// <param name="avm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(AuthenticationViewModel avm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = avm.Email, Email = avm.Email };
                var createResult = await _userManager.CreateAsync(user, avm.Password);
                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "SecurityIssuePost");
                }
            }

            return View(avm);
        }


        /// <summary>
        /// Sign current user out
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "SecurityIssuePost");
        }
    }
}
