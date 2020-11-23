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
        public DbSet<CMS> CMS { get; set; }
        public DbSet<Package> Package { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityIssuePost>().ToTable("SecurityIssuePost");

            // Seeding database
            modelBuilder.Entity<CMS>()
                .HasData(
                    new CMS() { Id = 1, Name = "CMS", Version = "8.9.1" });

            modelBuilder.Entity<Package>()
                .HasData(
                    new Package() { Id = 2, Name = "Forms", Version = "8.6.9" },
                    new Package() { Id = 3, Name = "uSync", Version = "6.2.1" });
        }
    }
}
