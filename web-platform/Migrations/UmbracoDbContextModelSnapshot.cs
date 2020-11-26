﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_platform.Data;

namespace web_platform.Migrations
{
    [DbContext(typeof(UmbracoDbContext))]
    partial class UmbracoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("web_platform.Models.CMSComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CMSComponent");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CMSComponent");
                });

            modelBuilder.Entity("web_platform.Models.CMSComponentVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CMSComponentId")
                        .HasColumnType("int");

                    b.Property<int?>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CMSComponentId");

                    b.HasIndex("VersionId");

                    b.ToTable("CMSComponentVersion");
                });

            modelBuilder.Entity("web_platform.Models.ComponenetVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("VersionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComponentVersion");
                });

            modelBuilder.Entity("web_platform.Models.SecurityIssuePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CMSComponentVersionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssueDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssueReproduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CMSComponentVersionId");

                    b.ToTable("SecurityIssuePosts");
                });

            modelBuilder.Entity("web_platform.Models.CMS", b =>
                {
                    b.HasBaseType("web_platform.Models.CMSComponent");

                    b.HasDiscriminator().HasValue("CMS");
                });

            modelBuilder.Entity("web_platform.Models.Package", b =>
                {
                    b.HasBaseType("web_platform.Models.CMSComponent");

                    b.HasDiscriminator().HasValue("Package");
                });

            modelBuilder.Entity("web_platform.Models.CMSComponentVersion", b =>
                {
                    b.HasOne("web_platform.Models.CMSComponent", "CMSComponent")
                        .WithMany()
                        .HasForeignKey("CMSComponentId");

                    b.HasOne("web_platform.Models.ComponenetVersion", "Version")
                        .WithMany()
                        .HasForeignKey("VersionId");

                    b.Navigation("CMSComponent");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("web_platform.Models.SecurityIssuePost", b =>
                {
                    b.HasOne("web_platform.Models.CMSComponentVersion", "CMSComponentVersion")
                        .WithMany()
                        .HasForeignKey("CMSComponentVersionId");

                    b.Navigation("CMSComponentVersion");
                });
#pragma warning restore 612, 618
        }
    }
}
