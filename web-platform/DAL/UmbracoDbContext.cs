﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.DAL;
using web_platform.Models;
using ComponentVersion = web_platform.Models.ComponentVersion;

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
        public DbSet<ComponentVersion> ComponentVersion { get; set; }
        public DbSet<CMSComponentVersion> CMSComponentVersion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
