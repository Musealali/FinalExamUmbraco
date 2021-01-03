using System;
using Xunit;
using web_platform.Controllers;
using web_platform.Data;
using Microsoft.EntityFrameworkCore;
using web_platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using web_platform.Data.Models;
using web_platform.Service;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading;

namespace XUnitTestUmbraco
{
    public class Umbraco_FinalExam_UniTest : IDisposable
    {
        protected readonly SecurityIssuePostService _securityIssuePostService;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SecurityIssuePostController _securityIssuePostController;

        public Umbraco_FinalExam_UniTest()
        {
            // Setting up InMemoryDatabase
            var options = new DbContextOptionsBuilder<UmbracoDbContext>()
                    .UseInMemoryDatabase<UmbracoDbContext>(Guid.NewGuid().ToString())
                    .Options;
            
            UmbracoDbContext context = new UmbracoDbContext(options);
            context.Database.EnsureCreated();

            _securityIssuePostService = new SecurityIssuePostService(context);

            // Mocking identity
            var mockStore = new Mock<IUserStore<ApplicationUser>>();
            mockStore.Setup(x => x.FindByIdAsync("1", CancellationToken.None))
                .ReturnsAsync(new ApplicationUser()
                {
                    Email = "default@default.com",
                    UserName = "default@default.com",
                    Id = "1"
                });

            _userManager = new UserManager<ApplicationUser>(mockStore.Object, null, null, null, null, null, null, null, null);

            _securityIssuePostController = new SecurityIssuePostController(_securityIssuePostService, _userManager, null);
        }

        public void Dispose()
        {
            _securityIssuePostService.Dispose();
        }


        [Fact]
        public async Task CreateSecurityIssuePost_Service()
        {
            var user = await _userManager.FindByIdAsync("1");
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", user);
            Assert.True(securityIssuePost.Id != 0);
            Assert.True(securityIssuePost.State == State.NotVerified);
        }

        [Fact]
        public async Task UpdateSecurityIssuePost_Service()
        {
            var user = await _userManager.FindByIdAsync("1");
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", user);

            var updatedSecurityIssuePost = await _securityIssuePostService.UpdateSecurityIssuePost(securityIssuePost.Id, "updated", "updated description", "updated component", "2.0.0");

            var securityIssuePostToFind = await _securityIssuePostService.GetById(securityIssuePost.Id);

            Assert.True(
                securityIssuePostToFind.Title == updatedSecurityIssuePost.Title &&
                securityIssuePostToFind.IssueDescription == updatedSecurityIssuePost.IssueDescription &&
                securityIssuePostToFind.ComponentName == updatedSecurityIssuePost.ComponentName &&
                securityIssuePostToFind.ComponentVersion == updatedSecurityIssuePost.ComponentVersion);
        }

        [Fact]
        public async Task DeleteSecurityIssuePost_Service()
        {
            var user = await _userManager.FindByIdAsync("1");
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", user);
            Assert.True(securityIssuePost.Id != 0);

            await _securityIssuePostService.DeleteSecurityIssuePost(securityIssuePost.Id);
            var securityIssuePostToFind = await _securityIssuePostService.GetById(securityIssuePost.Id);

            Assert.Null(securityIssuePostToFind);
        }

        [Fact]
        public async Task CreateSecurityIssuePostReply_Service()
        {
            var user = await _userManager.FindByIdAsync("1");
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", user);

            var securityIssuePostReply = await _securityIssuePostService.CreateSecurityIssuePostReply("comment", securityIssuePost, user);
            Assert.True(securityIssuePostReply.Id != 0);
        }


        [Fact]
        public async Task UpdateSecurityIssuePostReply_Service()
        {
            var user = await _userManager.FindByIdAsync("1");
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", user);

            var securityIssuePostReply = await _securityIssuePostService.CreateSecurityIssuePostReply("comment", securityIssuePost, user);
            Assert.True(securityIssuePostReply.Id != 0);

            var updatedSecurityIssuePostReply = await _securityIssuePostService.Update(securityIssuePostReply.Id, "updated comment");

            var securityIssuePostReplyToFind = await _securityIssuePostService.GetSecurityIssuePostReply(securityIssuePostReply.Id);

            Assert.True(securityIssuePostReplyToFind.Content == updatedSecurityIssuePostReply.Content);
        }

        [Fact]
        public async Task DeleteSecurityIssuePostReply_Service()
        {
            var user = await _userManager.FindByIdAsync("1");
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", user);

            var securityIssuePostReply = await _securityIssuePostService.CreateSecurityIssuePostReply("comment", securityIssuePost, user);
            Assert.True(securityIssuePostReply.Id != 0);

            await _securityIssuePostService.DeleteSecurityIssuePostReply(securityIssuePostReply.Id);

            var securityIssuePostReplyToFind = await _securityIssuePostService.GetSecurityIssuePostReply(securityIssuePostReply.Id);
            Assert.Null(securityIssuePostReplyToFind);
        }

        [Fact]
        public async Task CreateSecurityIssuePost_Controller()
        {
            SecurityIssuePostViewModel svm = new SecurityIssuePostViewModel()
            {
                Title = "Test",
                IssueDescription = "Description",
                ComponentName = "Test component",
                ComponentVersion = "1.1.1",
            };

            RedirectToActionResult result = (RedirectToActionResult)await _securityIssuePostController.Create(svm);
            Assert.True(result.ActionName == "SpecificSecurityIssuePost" && 
                        result.ControllerName == "SecurityIssuePost" && 
                        result.RouteValues.ContainsKey("id"));

            // Mocked user doesnt work in the controller
        }

        //[Fact]
        //public async Task TestReturnIndex()
        //{
        //    //Arrange
        //    SecurityIssuePost securityIssuePost = new SecurityIssuePost("UnitTest-Test", "Testing from unit", "Rerun this test to reproduce, xd");


        //    //Act
        //    var result = await _controller.Create(securityIssuePost, "Umbraco UNO", "1.1", "cms");

        //    ViewResult viewResult = await _controller.Index(securityIssuePost.Id) as ViewResult;

        //    //Assert
        //    Assert.NotNull(viewResult);
        //    Assert.NotEqual("Microsoft.AspNetCore.Mvc.NotFoundResult", viewResult.Model.ToString());
        //}

        //[Fact]
        //public async Task TestReturnIndexNotFound()
        //{
        //    //Arrange
        //    int id = 5000;

        //    //Act


        //    ViewResult viewResult = await _controller.Index(id) as ViewResult;
        //    string response = viewResult.Model.ToString();


        //    //Assert
        //    Assert.Equal("Microsoft.AspNetCore.Mvc.NotFoundResult", response);

        //}

        //[Fact]
        //public async Task TestReturnCreateView()
        //{
        //    //Arrange
        //    SecurityIssuePost securityIssuePost = new SecurityIssuePost();

        //    //Act
        //    ViewResult result = await _controller.Create(securityIssuePost) as ViewResult;

        //    //Assert
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public async Task ControllerActionMethodCanCreateSecurityIssuePostWithCMS()
        //{
        //    //Arrange
        //    string Title = "This is a security issue";
        //    string IssueDescription = "This is a description of the issue";
        //    string IssueReproduction = "This is how to reproduce the issue";
        //    string componentType = "cms";
        //    string name = "Umbraco CMS";
        //    string version = "1.1";
        //    SecurityIssuePost securityIssuePost = new SecurityIssuePost(Title, IssueDescription, IssueReproduction);

        //    //Act
        //    var result = await _controller.Create(securityIssuePost, name, version, componentType);

        //    //Assert
        //    var objectResult = Assert.IsAssignableFrom<ActionResult>(result);
        //}

        //[Fact]
        //public async Task ControllerActionMethodCanCreateSecurityIssuePostWithPackage()
        //{
        //    //Arrange
        //    string Title = "This is a security issue";
        //    string IssueDescription = "This is a description of the issue";
        //    string IssueReproduction = "This is how to reproduce the issue";
        //    string componentType = "package";
        //    string name = "Forms";
        //    string version = "1.2";
        //    SecurityIssuePost securityIssuePost = new SecurityIssuePost(Title, IssueDescription, IssueReproduction);

        //    //Act
        //    var result = await _controller.Create(securityIssuePost, name, version, componentType);

        //    //Assert
        //    var objectResult = Assert.IsAssignableFrom<ActionResult>(result);
        //}
    }
}
