﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_platform.Data;

namespace web_platform.Migrations
{
    [DbContext(typeof(UmbracoDbContext))]
    [Migration("20201122214010_Modified-Database-Seeding")]
    partial class ModifiedDatabaseSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CMSComponent");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CMSComponent");
                });

            modelBuilder.Entity("web_platform.Models.SecurityIssuePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CMSComponentId")
                        .HasColumnType("int");

                    b.Property<string>("IssueDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssueReproduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CMSComponentId");

                    b.ToTable("SecurityIssuePost");
                });

            modelBuilder.Entity("web_platform.Models.CMS", b =>
                {
                    b.HasBaseType("web_platform.Models.CMSComponent");

                    b.HasDiscriminator().HasValue("CMS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CMS",
                            Version = "8.9.1"
                        });
                });

            modelBuilder.Entity("web_platform.Models.Package", b =>
                {
                    b.HasBaseType("web_platform.Models.CMSComponent");

                    b.HasDiscriminator().HasValue("Package");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Forms",
                            Version = "8.6.9"
                        },
                        new
                        {
                            Id = 3,
                            Name = "uSync",
                            Version = "6.2.1"
                        });
                });

            modelBuilder.Entity("web_platform.Models.SecurityIssuePost", b =>
                {
                    b.HasOne("web_platform.Models.CMSComponent", "CMSComponent")
                        .WithMany()
                        .HasForeignKey("CMSComponentId");

                    b.Navigation("CMSComponent");
                });
#pragma warning restore 612, 618
        }
    }
}