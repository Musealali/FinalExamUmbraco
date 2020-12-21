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
using Microsoft.AspNetCore.Identity;
using web_platform.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace web_platform.Controllers
{
    public class SecurityIssuePostController : Controller
    {
        private readonly ISecurityIssuePost _ISecurityIssuePostService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SecurityIssuePostController(ISecurityIssuePost securityIssuePostService, UserManager<ApplicationUser> userManager)
        {
            _ISecurityIssuePostService = securityIssuePostService;
            _userManager = userManager;

        }
        
        [HttpGet]
        public async Task<IActionResult> SpecificSecurityIssuePost(int id)
        {

            var securityIssuePostToFind = await _ISecurityIssuePostService.GetById(id);
            var securityIssuePostReplies = await _ISecurityIssuePostService.GetSecurityIssuePostsReplies(id);

            var securityRepliesModels = new List<SecurityIssuePostReplyViewModel>();

            foreach (SecurityIssuePostReply securityIssuePostReply in securityIssuePostReplies)
            {
                SecurityIssuePostReplyViewModel securityIssuePostReplyViewModel = new SecurityIssuePostReplyViewModel
                {
                    Id = securityIssuePostReply.Id,
                    Content = securityIssuePostReply.Content,
                    ApplicationUser = securityIssuePostReply.ApplicationUser
                };

                securityRepliesModels.Add(securityIssuePostReplyViewModel);
            }

            var model = new SecurityIssuePostViewModel
            {
                Id = securityIssuePostToFind.Id,
                Title = securityIssuePostToFind.Title,
                IssueDescription = securityIssuePostToFind.IssueDescription,
                ComponentName = securityIssuePostToFind.ComponentName,
                ComponentVersion = securityIssuePostToFind.ComponentVersion,
                State = securityIssuePostToFind.State,
                SecurityIssuePostReplies = securityRepliesModels,
                ApplicationUser = securityIssuePostToFind.ApplicationUser
            };

            if (model == null) { return View(NotFound()); }
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetNonVerifiedSecurityIssuePosts(string searchString)
        {
            dynamic nonVerifiedSecurityIssuePosts;

            if (!string.IsNullOrEmpty(searchString))
            {
                nonVerifiedSecurityIssuePosts = await _ISecurityIssuePostService.GetSecurityIssuePostsBySearchString(searchString, _ISecurityIssuePostService.GetSecurityIssuePostStateNotVerified());
            } else
            {
                nonVerifiedSecurityIssuePosts = await _ISecurityIssuePostService.GetSecurityIssuePostsByState(_ISecurityIssuePostService.GetSecurityIssuePostStateNotVerified());
            }

            List<SecurityIssuePostViewModel> securityIssuePostViewModels = new List<SecurityIssuePostViewModel>();

            foreach (var nonVerifiedSecurityIssuePost in nonVerifiedSecurityIssuePosts)
            {
                var model = new SecurityIssuePostViewModel
                {
                    Id = nonVerifiedSecurityIssuePost.Id,
                    Title = nonVerifiedSecurityIssuePost.Title,
                    IssueDescription = nonVerifiedSecurityIssuePost.IssueDescription,
                    ComponentName = nonVerifiedSecurityIssuePost.ComponentName,
                    ComponentVersion = nonVerifiedSecurityIssuePost.ComponentVersion,
                    State = nonVerifiedSecurityIssuePost.State
                };

                securityIssuePostViewModels.Add(model);
            }

            return View(securityIssuePostViewModels);
        }

        public async Task<IActionResult> Index(string searchString)
        {

            dynamic verifiedSecurityIssuePosts;

            if (!string.IsNullOrEmpty(searchString))
            {
                verifiedSecurityIssuePosts = await _ISecurityIssuePostService.GetSecurityIssuePostsBySearchString(searchString, _ISecurityIssuePostService.GetSecurityIssuePostStateVerified());
            }
            else
            {
                verifiedSecurityIssuePosts = await _ISecurityIssuePostService.GetSecurityIssuePostsByState(_ISecurityIssuePostService.GetSecurityIssuePostStateVerified());
            }

            List<SecurityIssuePostViewModel> securityIssuePostViewModels = new List<SecurityIssuePostViewModel>();

            foreach (var verifiedSecurityIssuePost in verifiedSecurityIssuePosts)
            {
                var model = new SecurityIssuePostViewModel
                {
                    Id = verifiedSecurityIssuePost.Id,
                    Title = verifiedSecurityIssuePost.Title,
                    IssueDescription = verifiedSecurityIssuePost.IssueDescription,
                    ComponentName = verifiedSecurityIssuePost.ComponentName,
                    ComponentVersion = verifiedSecurityIssuePost.ComponentVersion,
                    State = verifiedSecurityIssuePost.State
                };

                securityIssuePostViewModels.Add(model);
            }

            return View(securityIssuePostViewModels);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create() // Responsible for returning the correct View, whenever a user WANTS to create a securityIssuePost
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SecurityIssuePostViewModel securityIssuePostView) // Responsible for getting the user input and storing the securityIssuePost
        {
            if (!ModelState.IsValid) { return RedirectToAction("Index", securityIssuePostView);}

            var applicationUser = await _userManager.GetUserAsync(User);
            var securityIssuePost = await _ISecurityIssuePostService.CreateSecurityIssuePost(securityIssuePostView.Title, securityIssuePostView.IssueDescription, securityIssuePostView.ComponentName, securityIssuePostView.ComponentVersion, applicationUser);
            return RedirectToAction("SpecificSecurityIssuePost", "SecurityIssuePost", new { id=securityIssuePost.Id });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateSecurityIssueReply(int securityIssuePostId, string content) 
        {
            var securityIssuePost = await _ISecurityIssuePostService.GetById(securityIssuePostId);
            var applicationUser = await _userManager.GetUserAsync(User);
            var securityIssuePostReply = await _ISecurityIssuePostService.CreateSecurityIssuePostReply(content, securityIssuePost, applicationUser);
            return RedirectToAction("SpecificSecurityIssuePost", "SecurityIssuePost", new { id = securityIssuePostId });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSecurityIssuePostReply(int securityIssuePostId, int securityIssuePostReplyId)
        {
            var securityIssuePostReplyToFind = await _ISecurityIssuePostService.GetSecurityIssuePostReply(securityIssuePostReplyId);

            if(securityIssuePostReplyToFind.ApplicationUser.Id != _userManager.GetUserId(User)) { return Unauthorized(); }

            await _ISecurityIssuePostService.DeleteSecurityIssuePostReply(securityIssuePostReplyId);
            return RedirectToAction("SpecificSecurityIssuePost", new { id = securityIssuePostId });
        }

        [HttpPost]
        public async Task<ActionResult> ChangeSecurityIssuePostStateToVerified (int securityIssuePostId)
        {
            var securityIssuePost = await _ISecurityIssuePostService.ChangeSecurityIssuePostStateToVerified(securityIssuePostId);
            return RedirectToAction("SpecificSecurityIssuePost", "SecurityIssuePost", new { id = securityIssuePost.Id });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteSecurityIssuePost(int securityIssuePostId)
        {
            var securityIssuePostToFind = await _ISecurityIssuePostService.GetById(securityIssuePostId);

            // We need to ensure that any manual requests to this endpoint are still validated against the current user in case the UI gets bypassed
            if (_userManager.GetUserId(User) != securityIssuePostToFind.ApplicationUser.Id || !User.IsInRole("Administrator")) { return Unauthorized(); }

            await _ISecurityIssuePostService.DeleteSecurityIssuePost(securityIssuePostId);
            return RedirectToAction("Index");
        }



    } 
}
