using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public class UmbracoDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public UmbracoDbContext(DbContextOptions<UmbracoDbContext> options)
            : base(options)
        {

        }

        public DbSet<SecurityIssuePost> SecurityIssuePosts {get; set;}
        public DbSet<SecurityIssuePostReply> SecurityIssuePostReplies { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SecurityIssuePost>(entity =>
            {
                // When we delete a post, we want all the replies to be deleted automatically aswell
                entity
                    .HasMany(s => s.SecurityIssuePostReplies)
                    .WithOne(sreply => sreply.SecurityIssuePost)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
