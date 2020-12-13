using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data;
using web_platform.Data.Models;

namespace web_platform.Service
{
    public class UserFileService : IUserFile
    {
        private readonly UmbracoDbContext _umbracoDbContext;

        public UserFileService(UmbracoDbContext umbracoDbContext)
        {
            _umbracoDbContext = umbracoDbContext;
        }

        public async Task<UserFile> GetById(int id)
        {
            return await _umbracoDbContext.UserFiles.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(List<IFormFile> files, SecurityIssuePost securityIssuePost)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "userfiles");
            Directory.CreateDirectory(directoryPath);

            foreach (var file in files)
            {
                var filePath = Path.Combine(directoryPath, Path.GetRandomFileName());
                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                var userFile = new UserFile()
                {
                    FilePath = filePath,
                    SecurityIssuePost = securityIssuePost
                };

                await _umbracoDbContext.AddAsync(userFile);
            }

            await _umbracoDbContext.SaveChangesAsync();
        }
    }
}
