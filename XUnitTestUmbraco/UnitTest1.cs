using System;
using Xunit;
using web_platform.Controllers;
using web_platform.DAL;
using web_platform.Data;
using Microsoft.EntityFrameworkCore;
using web_platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XUnitTestUmbraco
{
    public class Umbraco_FinalExam_UniTest : IDisposable
    {
        protected readonly UmbracoDbContext _context;
        private SecurityIssuePostController _controller;

        public Umbraco_FinalExam_UniTest()
        {
            var options = new DbContextOptionsBuilder<UmbracoDbContext>()
                    .UseInMemoryDatabase<UmbracoDbContext>(Guid.NewGuid().ToString())
                    .Options;
            _context = new UmbracoDbContext(options);
            _context.Database.EnsureCreated();
            _controller = new SecurityIssuePostController(_context);
            DbInitializer.Initialize(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public async Task ControllerActionMethodCanCreateSecurityIssuePostWithCMS()
        {
            //Arrange
            string Title = "This is a security issue";
            User user = new User();
            CMS cms = new CMS("CMS", "V8.5.3");
            CMSComponent cmsComponent = cms;
            string IssueDescription = "This is a description of the issue";
            string IssueReproduction = "This is how to reproduce the issue";


            SecurityIssuePost securityIssuePost = new SecurityIssuePost(Title, user, cmsComponent, IssueDescription, IssueReproduction);

            //ACT
            //var result = await _controller.Create(securityIssuePost);

            //Assert
            //var objectResult = Assert.IsType<ViewResult>(result);
            //Assert.NotNull(objectResult.Model);

            //var model = Assert.IsType<SecurityIssuePost>(objectResult.Model);


        }
        
    }
}
