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

        Task<SecurityIssuePost> CreateSecurityIssuePost(string title, string issueDescription, CMSComponentVersion cmsComponentVersion);

        Task<List<SecurityIssuePost>> GetSecurityIssuePostsByState(State state);

        State GetSecurityIssuePostStateVerified();

        State GetSecurityIssuePostStateNotVerified();
        Task<List<SecurityIssuePost>> GetSecurityIssuePostsBySearchString(string searchString, State state);

    }
}
