using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public interface ISecurityIssuePost
    {
        SecurityIssuePost GetById(int id);
        IEnumerable<SecurityIssuePost> GetAll();

        Task Create(SecurityIssuePost securityIssuePost);
    }
}
