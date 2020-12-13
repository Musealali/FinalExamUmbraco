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
        Task Create(List<IFormFile> files, SecurityIssuePost securityIssuePost);
    }
}
