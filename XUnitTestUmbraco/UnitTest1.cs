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
        public void TestReturnIndex()
        {
            //Arrange
            SecurityIssuePostController controller = new SecurityIssuePostController(_context);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestReturnCreateView()
        {
            //Arrange
            SecurityIssuePostController controller = new SecurityIssuePostController(_context);
            SecurityIssuePost securityIssuePost = new SecurityIssuePost();

            //Act
            ViewResult result = controller.Create(securityIssuePost) as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ControllerActionMethodCanCreateSecurityIssuePostWithCMS()
        {
            //Arrange
            string Title = "This is a security issue";
            string IssueDescription = "This is a description of the issue";
            string IssueReproduction = "This is how to reproduce the issue";
            string componentType = "cms";
            string name = "Umbraco CMS";
            string version = "1.1";
            SecurityIssuePost securityIssuePost = new SecurityIssuePost(Title, IssueDescription, IssueReproduction);

            //Act
            var result = await _controller.Create(securityIssuePost, name, version, componentType);

            //Assert
            var objectResult = Assert.IsAssignableFrom<ActionResult>(result);          
        }

        [Fact]
        public async Task ControllerActionMethodCanCreateSecurityIssuePostWithPackage()
        {
            //Arrange
            string Title = "This is a security issue";
            string IssueDescription = "This is a description of the issue";
            string IssueReproduction = "This is how to reproduce the issue";
            string componentType = "package";
            string name = "Forms";
            string version = "1.2";
            SecurityIssuePost securityIssuePost = new SecurityIssuePost(Title, IssueDescription, IssueReproduction);

            //Act
            var result = await _controller.Create(securityIssuePost, name, version, componentType);

            //Assert
            var objectResult = Assert.IsAssignableFrom<ActionResult>(result);
        }

    }
}
