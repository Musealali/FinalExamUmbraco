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
        IEnumerable<SecurityIssuePost> GetAll();

        Task<SecurityIssuePost> Create(string title, string issueDescription, CMSComponentVersion cmsComponentVersion);
    }
}
