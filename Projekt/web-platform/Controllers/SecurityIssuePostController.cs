﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ISecurityIssuePost _ISecurityIssuePostService;
        private readonly ICMSComponent _ICMSComponentService;
        private readonly IComponentVersion _IComponentVersionService;
        private readonly ICMSComponentVersion _ICMSComponentVersionService;

        public SecurityIssuePostController(ISecurityIssuePost securityIssuePostService, ICMSComponent cmsComponentService, IComponentVersion componentVersionService, ICMSComponentVersion cmsComponentVersionService)
        {
            _ISecurityIssuePostService = securityIssuePostService;
            _ICMSComponentService = cmsComponentService;
            _IComponentVersionService = componentVersionService;
            _ICMSComponentVersionService = cmsComponentVersionService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            var securityIssuePostToFind = await _ISecurityIssuePostService.GetById(id);

            var model = new SecurityIssuePostViewModel
            {
                Id = securityIssuePostToFind.Id,
                Title = securityIssuePostToFind.Title,
                IssueDescription = securityIssuePostToFind.IssueDescription,
                CMSComponentName = securityIssuePostToFind.CMSComponentVersion.CMSComponent.Name,
                CMSVersionNumber = securityIssuePostToFind.CMSComponentVersion.Version.VersionNumber,
                State = securityIssuePostToFind.State
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
                    CMSComponentName = nonVerifiedSecurityIssuePost.CMSComponentVersion.CMSComponent.Name,
                    CMSVersionNumber = nonVerifiedSecurityIssuePost.CMSComponentVersion.Version.VersionNumber,
                    State = nonVerifiedSecurityIssuePost.State
                };

                securityIssuePostViewModels.Add(model);
            }

            return View(securityIssuePostViewModels);
        }

        public async Task<IActionResult> GetVerifiedSecurityIssuePosts(string searchString)
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
                    CMSComponentName = verifiedSecurityIssuePost.CMSComponentVersion.CMSComponent.Name,
                    CMSVersionNumber = verifiedSecurityIssuePost.CMSComponentVersion.Version.VersionNumber,
                    State = verifiedSecurityIssuePost.State
                };

                securityIssuePostViewModels.Add(model);
            }

            return View(securityIssuePostViewModels);
        }



        [HttpGet]
        public async Task<IActionResult> Create() // Responsible for returning the correct View, whenever a user WANTS to create a securityIssuePost
        {
            var cms =  await _ICMSComponentService.GetCMSComponentsByType(_ICMSComponentService.GetComponentTypeCMS());
            var packages = await _ICMSComponentService.GetCMSComponentsByType(_ICMSComponentService.GetComponentTypePackage());
            var formsVersions = await _IComponentVersionService.GetComponentVersionByComponentName("Forms");
            var uSyncVersions = await _IComponentVersionService.GetComponentVersionByComponentName("uSync");
            var umbracoCMSVersions = await _IComponentVersionService.GetComponentVersionByComponentName("Umbraco CMS");
            var umbracoUNOVersions = await _IComponentVersionService.GetComponentVersionByComponentName("Umbraco UNO");
            var umbracoHeartcoreVersions = await _IComponentVersionService.GetComponentVersionByComponentName("Umbraco Heartcore");

            ViewBag.MultipleCMS = cms;
            ViewBag.Packages = packages;
            ViewBag.FormsVersions = formsVersions;
            ViewBag.USyncVersions = uSyncVersions;
            ViewBag.UmbracoCMSVersions = umbracoCMSVersions;
            ViewBag.UmbracoUNOVersions = umbracoUNOVersions;
            ViewBag.UmbracoHeartcoreVersions = umbracoHeartcoreVersions;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SecurityIssuePostViewModel securityIssuePostView) // Responsible for getting the user input and storing the securityIssuePost
        {
            if (!ModelState.IsValid) { return RedirectToAction("Index", securityIssuePostView);}

            var cmsComponentVersion = await _ICMSComponentVersionService.GetCMSComponentVersion(securityIssuePostView.CMSComponentName, securityIssuePostView.CMSVersionNumber, securityIssuePostView.ComponentType);

            if (cmsComponentVersion == null) { return NotFound(); }

            var securityIssuePost = await _ISecurityIssuePostService.CreateSecurityIssuePost(securityIssuePostView.Title, securityIssuePostView.IssueDescription, cmsComponentVersion);
            return RedirectToAction("Index", "SecurityIssuePost", new { id=securityIssuePost.Id });
        }

    } 
}
