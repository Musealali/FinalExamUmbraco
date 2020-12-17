using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data.Models;
using web_platform.Models;

namespace web_platform.Data
{
    public interface ISecurityIssuePost
    {
        Task<SecurityIssuePost> GetById(int id);

        Task<SecurityIssuePost> CreateSecurityIssuePost(string title, string issueDescription, string componentName, string componentVersion, ApplicationUser applicationUser);
        Task<SecurityIssuePostReply> CreateSecurityIssuePostReply(string content, SecurityIssuePost securityIssuePost, ApplicationUser applicationUser);

        Task<List<SecurityIssuePost>> GetSecurityIssuePostsByState(State state);
        Task<List<SecurityIssuePostReply>> GetSecurityIssuePostsReplies(int securityIssuePostId);

        State GetSecurityIssuePostStateVerified();

        State GetSecurityIssuePostStateNotVerified();
        Task<List<SecurityIssuePost>> GetSecurityIssuePostsBySearchString(string searchString, State state);
        Task<SecurityIssuePost> ChangeSecurityIssuePostStateToVerified(int securityIssuePostId);
        Task DeleteSecurityIssuePost(int securityIssuePostId);

    }
}
