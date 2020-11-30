using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Models;
using ComponentVersion = web_platform.Models.ComponentVersion;

namespace web_platform.Data
{
    public class UmbracoDbContext : IdentityDbContext<ApplicationUser>
    {
        public UmbracoDbContext(DbContextOptions<UmbracoDbContext> options)
            : base(options)
        {

        }

        public DbSet<SecurityIssuePost> SecurityIssuePosts {get; set;}
        public DbSet<CMSComponent> CMSComponents { get; set; }
        public DbSet<ComponentVersion> ComponentVersions { get; set; }
        public DbSet<CMSComponentVersion> CMSComponentVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CMSComponent>()
                .HasMany(c => c.Versions)
                .WithMany(v => v.CMSComponents)
                .UsingEntity<CMSComponentVersion>(
                    j => j.HasOne(ccv => ccv.Version).WithMany(c => c.CMSComponentVersions),
                    j => j.HasOne(ccv => ccv.CMSComponent).WithMany(v => v.CMSComponentVersions));
            modelBuilder.Entity<ComponentVersion>()
                .HasData(
                    new ComponentVersion() { Id = 1, VersionNumber = "1.1" },
                    new ComponentVersion() { Id = 2, VersionNumber = "1.2" },
                    new ComponentVersion() { Id = 3, VersionNumber = "1.3" },
                    new ComponentVersion() { Id = 4, VersionNumber = "1.4" },
                    new ComponentVersion() { Id = 5, VersionNumber = "2.1" },
                    new ComponentVersion() { Id = 6, VersionNumber = "2.2" },
                    new ComponentVersion() { Id = 7, VersionNumber = "2.3" },
                    new ComponentVersion() { Id = 8, VersionNumber = "2.4" },
                    new ComponentVersion() { Id = 9, VersionNumber = "3.1" },
                    new ComponentVersion() { Id = 10, VersionNumber = "3.2" },
                    new ComponentVersion() { Id = 11, VersionNumber = "3.3" },
                    new ComponentVersion() { Id = 12, VersionNumber = "3.4" }

                   );
            
            modelBuilder.Entity<CMSComponent>()
                .HasData(
                    new CMSComponent { Id = 1, Name = "Forms", CType = CMSComponent.ComponentType.Package},
                    new CMSComponent { Id = 2, Name = "uSync", CType = CMSComponent.ComponentType.Package},
                    new CMSComponent { Id = 3, Name = "Umbraco UNO", CType = CMSComponent.ComponentType.CMS},
                    new CMSComponent { Id = 4, Name = "Umbraco Cloud", CType = CMSComponent.ComponentType.CMS},
                    new CMSComponent { Id = 5, Name = "Umbraco Hearthbreak", CType = CMSComponent.ComponentType.CMS},
                    new CMSComponent { Id = 6, Name = "Umbraco CMS", CType = CMSComponent.ComponentType.CMS}
                );
            modelBuilder.Entity<CMSComponentVersion>()
                .HasData(
                    new CMSComponentVersion() { Id = 1, CMSComponentId = 3, ComponentVersionId = 1 },
                    new CMSComponentVersion() { Id = 2, CMSComponentId = 3, ComponentVersionId = 3 },
                    new CMSComponentVersion() { Id = 3, CMSComponentId = 3, ComponentVersionId = 5 },
                    new CMSComponentVersion() { Id = 4, CMSComponentId = 3, ComponentVersionId = 8 },
                    new CMSComponentVersion() { Id = 5, CMSComponentId = 4, ComponentVersionId = 2 },
                    new CMSComponentVersion() { Id = 6, CMSComponentId = 4, ComponentVersionId = 6 },
                    new CMSComponentVersion() { Id = 7, CMSComponentId = 4, ComponentVersionId = 10 },
                    new CMSComponentVersion() { Id = 8, CMSComponentId = 5, ComponentVersionId = 3 },
                    new CMSComponentVersion() { Id = 9, CMSComponentId = 5, ComponentVersionId = 7 },
                    new CMSComponentVersion() { Id = 10, CMSComponentId = 5, ComponentVersionId = 11 },
                    new CMSComponentVersion() { Id = 11, CMSComponentId = 5, ComponentVersionId = 12 },
                    new CMSComponentVersion() { Id = 12, CMSComponentId = 6, ComponentVersionId = 3 },
                    new CMSComponentVersion() { Id = 13, CMSComponentId = 6, ComponentVersionId = 7 },
                    new CMSComponentVersion() { Id = 14, CMSComponentId = 6, ComponentVersionId = 9 },
                    new CMSComponentVersion() { Id = 15, CMSComponentId = 1, ComponentVersionId = 1 },
                    new CMSComponentVersion() { Id = 16, CMSComponentId = 1, ComponentVersionId = 2 },
                    new CMSComponentVersion() { Id = 17, CMSComponentId = 1, ComponentVersionId = 11 },
                    new CMSComponentVersion() { Id = 18, CMSComponentId = 1, ComponentVersionId = 12 },
                    new CMSComponentVersion() { Id = 19, CMSComponentId = 2, ComponentVersionId = 1 },
                    new CMSComponentVersion() { Id = 20, CMSComponentId = 2, ComponentVersionId = 4 },
                    new CMSComponentVersion() { Id = 21, CMSComponentId = 2, ComponentVersionId = 6 },
                    new CMSComponentVersion() { Id = 22, CMSComponentId = 2, ComponentVersionId = 11 }
                );

        }
    }
}
