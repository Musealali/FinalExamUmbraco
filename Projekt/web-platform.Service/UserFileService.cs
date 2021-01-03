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

        public async Task<List<UserFile>> GetBySecurityIssuePostId(int securityIssuePostId)
        {
            return await _umbracoDbContext.UserFiles.Where(u => u.SecurityIssuePost.Id == securityIssuePostId).ToListAsync();
        }

        public async Task Add(List<IFormFile> files, SecurityIssuePost securityIssuePost)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "userfiles");
            Directory.CreateDirectory(directoryPath);

            if(files != null)
            {
                foreach (var file in files)
                {
                    var filePath = Path.Combine(directoryPath, Path.GetRandomFileName());
                    using (var stream = File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var userFile = new UserFile()
                    {
                        FileName = file.FileName,
                        FilePath = filePath,
                        SecurityIssuePost = securityIssuePost
                    };

                    await _umbracoDbContext.AddAsync(userFile);
                }
         
                await _umbracoDbContext.SaveChangesAsync();
            }
        }


        public async Task DeleteAll(SecurityIssuePost securityIssuePost)
        {
            var userFilesToFind = await _umbracoDbContext.UserFiles.Where((u) => u.SecurityIssuePost.Id == securityIssuePost.Id).ToListAsync();
            foreach (var userFile in userFilesToFind)
            {
                File.Delete(userFile.FilePath);
                _umbracoDbContext.UserFiles.Remove(userFile);
            }

            await _umbracoDbContext.SaveChangesAsync();
        }

        public async Task Delete(int userFileId)
        {
            var userFileToFind = await _umbracoDbContext.UserFiles.Where((u) => u.Id == userFileId).FirstOrDefaultAsync();
            if(userFileToFind != null)
            {
                File.Delete(userFileToFind.FilePath);
                _umbracoDbContext.UserFiles.Remove(userFileToFind);
                await _umbracoDbContext.SaveChangesAsync();
            }
        }
    }
}
