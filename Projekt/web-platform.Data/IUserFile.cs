using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public interface IUserFile
    {
        Task<UserFile> GetById(int id);
        Task<List<UserFile>> GetBySecurityIssuePostId(int securityIssuePostId);
        Task Add(List<IFormFile> files, SecurityIssuePost securityIssuePost);
        Task DeleteAll(SecurityIssuePost securityIssuePost);
        Task Delete(int userFileId);
    }
}
