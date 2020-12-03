﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Data.Models;

namespace web_platform.Service
{
    public class SecurityIssuePostService : ISecurityIssuePost
    {
        private readonly UmbracoDbContext _umbracoDbContext;

        public SecurityIssuePostService(UmbracoDbContext umbracoDbcontext)
        {
            _umbracoDbContext = umbracoDbcontext;
        }


        public async Task<SecurityIssuePost> CreateSecurityIssuePost(string title, string issueDescription, CMSComponentVersion cmsComponentVersion, ApplicationUser applicationUser)
        {

            SecurityIssuePost securityIssuePost = new SecurityIssuePost()
            {
                Title = title,
                IssueDescription = issueDescription,
                CMSComponentVersion = cmsComponentVersion,
                ApplicationUser = applicationUser,
                State = State.NotVerified
            };

            await _umbracoDbContext.AddAsync(securityIssuePost);
            await _umbracoDbContext.SaveChangesAsync();
            return securityIssuePost;

        }

        public async Task<SecurityIssuePostReply> CreateSecurityIssuePostReply(string content, SecurityIssuePost securityIssuePost, ApplicationUser applicationUser)
        {
            SecurityIssuePostReply securityIssuePostReply = new SecurityIssuePostReply()
            {
                ApplicationUser = applicationUser,
                SecurityIssuePost = securityIssuePost,
                Content = content
            };

            await _umbracoDbContext.AddAsync(securityIssuePostReply);
            await _umbracoDbContext.SaveChangesAsync();
            return securityIssuePostReply;

        }

        public async Task<SecurityIssuePost> GetById(int id)
        {
            var securityIssuePostToFind = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.Id == id)
                .Include(s => s.CMSComponentVersion)
                    .ThenInclude(c => c.CMSComponent)
                .Include(s => s.CMSComponentVersion)
                    .ThenInclude(c => c.Version)
                .Include(s => s.ApplicationUser)
                .Where(s => s.Id == id).FirstOrDefaultAsync();

            return securityIssuePostToFind;

        }

        public async Task<List<SecurityIssuePost>> GetSecurityIssuePostsByState(State state)
        {
            var securityIssuePosts = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.State == state)
                .Include(s => s.CMSComponentVersion)
                    .ThenInclude(c => c.CMSComponent)
                .Include(s => s.CMSComponentVersion)
                    .ThenInclude(c => c.Version)
                .Include(s => s.ApplicationUser)
                .ToListAsync();

            return securityIssuePosts;

        }
        public State GetSecurityIssuePostStateVerified()
        {
            return State.Verified;
        }

        public State GetSecurityIssuePostStateNotVerified()
        {
            return State.NotVerified;
        }


        public async Task<List<SecurityIssuePostReply>> GetSecurityIssuePostsReplies(int securityIssuePostId)
        {
            var securityIssuePostReplies = await _umbracoDbContext.SecurityIssuePostReplies.Where(s => s.SecurityIssuePost.Id == securityIssuePostId).ToListAsync();

            return securityIssuePostReplies;
        }

        

        public async Task<List<SecurityIssuePost>> GetSecurityIssuePostsBySearchString(string searchString, State state)
        {
            var securityIssuePosts = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.Title.Contains(searchString) && s.State == state)
                .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.CMSComponent)
                    .Include(s => s.CMSComponentVersion)
                        .ThenInclude(c => c.Version)
                        .ToListAsync();

            return securityIssuePosts;
        }

    }
}
