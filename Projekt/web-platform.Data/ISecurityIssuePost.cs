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
        Task<List<SecurityIssuePost>> GetSecurityIssuePostsBySearchString(string searchString, State state);
        Task<SecurityIssuePost> CreateSecurityIssuePost(string title, string issueDescription, string componentName, string componentVersion, ApplicationUser applicationUser);
        Task<List<SecurityIssuePost>> GetSecurityIssuePostsByState(State state);
        Task DeleteSecurityIssuePost(int securityIssuePostId);
        Task<SecurityIssuePost> ChangeSecurityIssuePostStateToVerified(int securityIssuePostId);
        Task<SecurityIssuePost> UpdateSecurityIssuePost(int securityIssuePostId, string title, string issueDescription, string componentName, string componentVersion);

        State GetSecurityIssuePostStateVerified();
        State GetSecurityIssuePostStateNotVerified();

        Task<SecurityIssuePostReply> GetSecurityIssuePostReply(int securityIssuePostReplyId);
        Task<List<SecurityIssuePostReply>> GetSecurityIssuePostsReplies(int securityIssuePostId);
        Task<SecurityIssuePostReply> CreateSecurityIssuePostReply(string content, SecurityIssuePost securityIssuePost, ApplicationUser applicationUser);
        Task DeleteSecurityIssuePostReply(int securityIssuePostReplyId);
    }
}
