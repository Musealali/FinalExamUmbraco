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
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace XUnitTestUmbraco
{
    public class Umbraco_FinalExam_UniTest : IDisposable
    {
        protected readonly SecurityIssuePostService _securityIssuePostService;
        protected readonly UserFileService _userFileService;
        protected readonly SecurityIssuePostController _securityIssuePostController;

        protected readonly ApplicationUser _defaultUser = new ApplicationUser()
        {
            Email = "default@default.com",
            UserName = "default@default.com",
            Id = "1"
        };
        protected readonly ClaimsIdentity _defaultUserClaims = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "default@default.com"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
        });


        public Umbraco_FinalExam_UniTest()
        {
            // Setting up InMemoryDatabase
            var options = new DbContextOptionsBuilder<UmbracoDbContext>()
                    .UseInMemoryDatabase<UmbracoDbContext>(Guid.NewGuid().ToString())
                    .Options;
            
            UmbracoDbContext context = new UmbracoDbContext(options);
            context.Database.EnsureCreated();


            // Setting up custom services
            _securityIssuePostService = new SecurityIssuePostService(context);
            _userFileService = new UserFileService(context);

            Mock<IUserStore<ApplicationUser>> mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(mockUserStore.Object, null, null, null, null, null, null, null, null);


            // Setting up the securityIssuePostController
            _securityIssuePostController = new SecurityIssuePostController(_securityIssuePostService, userManager, _userFileService);
            _securityIssuePostController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(_defaultUserClaims)
                }
            };
        }

        public void Dispose()
        {
            _securityIssuePostService.Dispose();
        }


        #region CUSTOM SERVICE TESTS
        [Fact]
        public async Task Service_CreateSecurityIssuePost()
        {
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", _defaultUser);
            Assert.True(securityIssuePost.Id != 0);
            Assert.True(securityIssuePost.State == State.NotVerified);
        }

        [Fact]
        public async Task Service_UpdateSecurityIssuePost()
        {
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", _defaultUser);

            var updatedSecurityIssuePost = await _securityIssuePostService.UpdateSecurityIssuePost(securityIssuePost.Id, "updated", "updated description", "updated component", "2.0.0");

            var securityIssuePostToFind = await _securityIssuePostService.GetById(securityIssuePost.Id);

            Assert.True(
                securityIssuePostToFind.Title == updatedSecurityIssuePost.Title &&
                securityIssuePostToFind.IssueDescription == updatedSecurityIssuePost.IssueDescription &&
                securityIssuePostToFind.ComponentName == updatedSecurityIssuePost.ComponentName &&
                securityIssuePostToFind.ComponentVersion == updatedSecurityIssuePost.ComponentVersion);
        }

        [Fact]
        public async Task Service_DeleteSecurityIssuePost()
        {
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", _defaultUser);
            Assert.True(securityIssuePost.Id != 0);

            await _securityIssuePostService.DeleteSecurityIssuePost(securityIssuePost.Id);
            var securityIssuePostToFind = await _securityIssuePostService.GetById(securityIssuePost.Id);

            Assert.Null(securityIssuePostToFind);
        }

        [Fact]
        public async Task Service_CreateSecurityIssuePostReply()
        {
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", _defaultUser);

            var securityIssuePostReply = await _securityIssuePostService.CreateSecurityIssuePostReply("comment", securityIssuePost, _defaultUser);
            Assert.True(securityIssuePostReply.Id != 0);
        }


        [Fact]
        public async Task Service_UpdateSecurityIssuePostReply()
        {
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", _defaultUser);

            var securityIssuePostReply = await _securityIssuePostService.CreateSecurityIssuePostReply("comment", securityIssuePost, _defaultUser);
            Assert.True(securityIssuePostReply.Id != 0);

            var updatedSecurityIssuePostReply = await _securityIssuePostService.Update(securityIssuePostReply.Id, "updated comment");

            var securityIssuePostReplyToFind = await _securityIssuePostService.GetSecurityIssuePostReply(securityIssuePostReply.Id);

            Assert.True(securityIssuePostReplyToFind.Content == updatedSecurityIssuePostReply.Content);
        }

        [Fact]
        public async Task Service_DeleteSecurityIssuePostReply()
        {
            var securityIssuePost = await _securityIssuePostService.CreateSecurityIssuePost("test", "description", "Testcomponent", "1.1.1", _defaultUser);

            var securityIssuePostReply = await _securityIssuePostService.CreateSecurityIssuePostReply("comment", securityIssuePost, _defaultUser);
            Assert.True(securityIssuePostReply.Id != 0);

            await _securityIssuePostService.DeleteSecurityIssuePostReply(securityIssuePostReply.Id);

            var securityIssuePostReplyToFind = await _securityIssuePostService.GetSecurityIssuePostReply(securityIssuePostReply.Id);
            Assert.Null(securityIssuePostReplyToFind);
        }
        #endregion

        #region AUTHORIZE ATTRIBUTE TESTS
        [Fact]
        public async Task AuthorizeAttribute_CreateSecurityIssuePostController_Create()
        {
            var createMethods = _securityIssuePostController.GetType().GetMethods().Where(x => x.Name == "Create");
            foreach (var method in createMethods)
            {
                var attributes = method.GetCustomAttributes(typeof(AuthorizeAttribute), true);
                Assert.Equal(typeof(AuthorizeAttribute), attributes[0].GetType());
            }
        }

        [Fact]
        public async Task AuthorizeAttribute_CreateSecurityIssuePostController_CreateSecurityIssueReply()
        {
            var createMethods = _securityIssuePostController.GetType().GetMethods().Where(x => x.Name == "CreateSecurityIssueReply");
            foreach (var method in createMethods)
            {
                var attributes = method.GetCustomAttributes(typeof(AuthorizeAttribute), true);
                Assert.Equal(typeof(AuthorizeAttribute), attributes[0].GetType());
            }
        }
        #endregion

        #region ACTION RESULT TESTS
        [Fact]
        public async Task Controller_CreateSecurityIssuePost()
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
        #endregion
    }
}
