using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Models;

namespace web_platform.Data
{
    public class UmbracoDbContext : DbContext
    {
        public UmbracoDbContext(DbContextOptions<UmbracoDbContext> options)
            : base(options)
        {

        }

        public DbSet<SecurityIssuePost> SecurityIssuePosts {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityIssuePost>()
                .Property(s => s.IssueDescription);
        }
    }
}
