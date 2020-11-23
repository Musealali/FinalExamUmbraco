using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Models;
using Version = web_platform.Models.Version;

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
        public DbSet<Version> Versions { get; set; }
        public DbSet<CMSComponentVersion> CMSComponentVersion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityIssuePost>().ToTable("SecurityIssuePost");

            // Seeding database

            Version version11 = new Version() { VersionNumber = "1.1" };
            Version version12 = new Version() { VersionNumber = "1.2" };
            Version version13 = new Version() { VersionNumber = "1.3" };
            Version version14 = new Version() { VersionNumber = "1.4" };
            Version version21 = new Version() { VersionNumber = "2.1" };
            Version version22 = new Version() { VersionNumber = "2.2" };
            Version version23 = new Version() { VersionNumber = "2.3" };
            Version version24 = new Version() { VersionNumber = "2.4" };
            Version version31 = new Version() { VersionNumber = "3.1" };
            Version version32 = new Version() { VersionNumber = "3.2" };
            Version version33 = new Version() { VersionNumber = "3.3" };
            Version version34 = new Version() { VersionNumber = "3.4" };
            CMS umbracoUNO = new CMS() { Id = 1, Name = "Umbraco UNO" };
            CMS umbracoCloud = new CMS() { Id = 2, Name = "Umbraco Cloud" };
            CMS umbracoHearthbreak = new CMS() { Id = 3, Name = "Umbraco Hearthbreak" };
            CMS umbracoCMS = new CMS() { Id = 4, Name = "Umbraco CMS" };
            Package forms = new Package() { Id = 5, Name = "Forms" };
            Package uSync = new Package() { Id = 6, Name = "uSync" };
            modelBuilder.Entity<CMS>()
                .HasData(
                    umbracoUNO,
                    umbracoCloud,
                    umbracoHearthbreak,
                    umbracoCMS);

            modelBuilder.Entity<Package>()
                .HasData(
                    forms,
                    uSync);
            modelBuilder.Entity<Version>()
                .HasData(
                    version11,
                    version12,
                    version13,
                    version14,
                    version21,
                    version22,
                    version23,
                    version24,
                    version31,
                    version32,
                    version33,
                    version34);
            modelBuilder.Entity<CMSComponentVersion>()
               .HasData(
                   new CMSComponentVersion() { Id = 1, CMSComponent = umbracoUNO, Version = version11},
                   new CMSComponentVersion() { Id = 2, CMSComponent = umbracoUNO, Version = version13},
                   new CMSComponentVersion() { Id = 3, CMSComponent = umbracoUNO, Version = version21},
                   new CMSComponentVersion() { Id = 4, CMSComponent = umbracoUNO, Version = version24},
                   new CMSComponentVersion() { Id = 5, CMSComponent = umbracoCloud, Version = version12},
                   new CMSComponentVersion() { Id = 6, CMSComponent = umbracoCloud, Version = version22},
                   new CMSComponentVersion() { Id = 7, CMSComponent = umbracoCloud, Version = version32},
                   new CMSComponentVersion() { Id = 8, CMSComponent = umbracoHearthbreak, Version = version13 },
                   new CMSComponentVersion() { Id = 9, CMSComponent = umbracoHearthbreak, Version = version23},
                   new CMSComponentVersion() { Id = 10, CMSComponent = umbracoHearthbreak, Version = version33 },
                   new CMSComponentVersion() { Id = 11, CMSComponent = umbracoHearthbreak, Version = version34 },
                   new CMSComponentVersion() { Id = 12, CMSComponent = umbracoCMS, Version = version13},
                   new CMSComponentVersion() { Id = 13, CMSComponent = umbracoCMS, Version = version22 },
                   new CMSComponentVersion() { Id = 14, CMSComponent = umbracoCMS, Version = version31 },
                   new CMSComponentVersion() { Id = 15, CMSComponent = forms, Version = version11 },
                   new CMSComponentVersion() { Id = 16, CMSComponent = forms, Version = version22 },
                   new CMSComponentVersion() { Id = 17, CMSComponent = forms, Version = version33 },
                   new CMSComponentVersion() { Id = 18, CMSComponent = forms, Version = version34 },
                   new CMSComponentVersion() { Id = 19, CMSComponent = uSync, Version = version11 },
                   new CMSComponentVersion() { Id = 20, CMSComponent = uSync, Version = version14 },
                   new CMSComponentVersion() { Id = 21, CMSComponent = uSync, Version = version22 },
                   new CMSComponentVersion() { Id = 22, CMSComponent = uSync, Version = version33 });
        }
    }
}
