using Microsoft.EntityFrameworkCore;
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


        public async Task<SecurityIssuePost> CreateSecurityIssuePost(string title, string issueDescription, string componentName, string componentVersion, ApplicationUser applicationUser)
        {

            SecurityIssuePost securityIssuePost = new SecurityIssuePost()
            {
                Title = title,
                IssueDescription = issueDescription,
                ComponentName = componentName,
                ComponentVersion = componentVersion,
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
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync();

            return securityIssuePostToFind;

        }

        public async Task<List<SecurityIssuePost>> GetSecurityIssuePostsByState(State state)
        {
            var securityIssuePosts = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.State == state)
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


        public async Task<SecurityIssuePostReply> GetSecurityIssuePostReply(int securityIssuePostReplyId)
        {
            return await _umbracoDbContext.SecurityIssuePostReplies.Where(s => s.Id == securityIssuePostReplyId)
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SecurityIssuePostReply>> GetSecurityIssuePostsReplies(int securityIssuePostId)
        {
            var securityIssuePostReplies = await _umbracoDbContext.SecurityIssuePostReplies.Where(s => s.SecurityIssuePost.Id == securityIssuePostId).ToListAsync();

            return securityIssuePostReplies;
        }

        

        public async Task<List<SecurityIssuePost>> GetSecurityIssuePostsBySearchString(string searchString, State state)
        {
            var securityIssuePosts = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.Title.Contains(searchString) && s.State == state)
                        .ToListAsync();

            return securityIssuePosts;
        }

        public async Task<SecurityIssuePost> ChangeSecurityIssuePostStateToVerified (int securityIssuePostId)
        {
            var securityIssuePostToFind = await _umbracoDbContext.SecurityIssuePosts.Where(s => s.Id == securityIssuePostId)
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync();
            if (securityIssuePostToFind != null)
            {
                securityIssuePostToFind.State = State.Verified;
                await _umbracoDbContext.SaveChangesAsync();
            }
            return securityIssuePostToFind;
        }

        public async Task DeleteSecurityIssuePost(int securityIssuePostId)
        {
            var securityIssuePost = await _umbracoDbContext.SecurityIssuePosts.FindAsync(securityIssuePostId);
            if(securityIssuePost != null)
            {
                _umbracoDbContext.Remove(securityIssuePost);
                await _umbracoDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSecurityIssuePostReply(int securityIssuePostReplyId)
        {
            var securityIssuePostReplyToFind = await _umbracoDbContext.SecurityIssuePostReplies.Where((s) => s.Id == securityIssuePostReplyId).FirstOrDefaultAsync();
            if(securityIssuePostReplyToFind != null)
            {
                _umbracoDbContext.SecurityIssuePostReplies.Remove(securityIssuePostReplyToFind);
                await _umbracoDbContext.SaveChangesAsync();
            }
        }

        public async Task<SecurityIssuePost> UpdateSecurityIssuePost(int securityIssuePostId, string title, string issueDescription, string componentName, string componentVersion)
        {
            var securityIssuePostToFind = await _umbracoDbContext.SecurityIssuePosts.Where((s) => s.Id == securityIssuePostId).FirstOrDefaultAsync();
            if (securityIssuePostToFind != null)
            {
                securityIssuePostToFind.Title = title;
                securityIssuePostToFind.IssueDescription = issueDescription;
                securityIssuePostToFind.ComponentName = componentName;
                securityIssuePostToFind.ComponentVersion = componentVersion;
                await _umbracoDbContext.SaveChangesAsync();
            }
            return securityIssuePostToFind;
        }
    }
}
