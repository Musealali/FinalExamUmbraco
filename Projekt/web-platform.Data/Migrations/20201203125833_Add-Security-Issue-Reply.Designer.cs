﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_platform.Data;

namespace web_platform.Data.Migrations
{
    [DbContext(typeof(UmbracoDbContext))]
    [Migration("20201203125833_Add-Security-Issue-Reply")]
    partial class AddSecurityIssueReply
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("web_platform.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("web_platform.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("web_platform.Data.Models.CMSComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ComponentType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CMSComponents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ComponentType = 1,
                            Name = "Forms"
                        },
                        new
                        {
                            Id = 2,
                            ComponentType = 1,
                            Name = "uSync"
                        },
                        new
                        {
                            Id = 3,
                            ComponentType = 1,
                            Name = "Umbraco UNO"
                        },
                        new
                        {
                            Id = 4,
                            ComponentType = 1,
                            Name = "Umbraco Heartcore"
                        },
                        new
                        {
                            Id = 5,
                            ComponentType = 0,
                            Name = "Umbraco CMS"
                        });
                });

            modelBuilder.Entity("web_platform.Data.Models.CMSComponentVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CMSComponentId")
                        .HasColumnType("int");

                    b.Property<int>("ComponentVersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CMSComponentId");

                    b.HasIndex("ComponentVersionId");

                    b.ToTable("CMSComponentVersions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CMSComponentId = 3,
                            ComponentVersionId = 1
                        },
                        new
                        {
                            Id = 2,
                            CMSComponentId = 3,
                            ComponentVersionId = 3
                        },
                        new
                        {
                            Id = 3,
                            CMSComponentId = 3,
                            ComponentVersionId = 5
                        },
                        new
                        {
                            Id = 4,
                            CMSComponentId = 3,
                            ComponentVersionId = 8
                        },
                        new
                        {
                            Id = 5,
                            CMSComponentId = 4,
                            ComponentVersionId = 3
                        },
                        new
                        {
                            Id = 6,
                            CMSComponentId = 4,
                            ComponentVersionId = 7
                        },
                        new
                        {
                            Id = 7,
                            CMSComponentId = 4,
                            ComponentVersionId = 11
                        },
                        new
                        {
                            Id = 8,
                            CMSComponentId = 4,
                            ComponentVersionId = 12
                        },
                        new
                        {
                            Id = 9,
                            CMSComponentId = 5,
                            ComponentVersionId = 3
                        },
                        new
                        {
                            Id = 10,
                            CMSComponentId = 5,
                            ComponentVersionId = 7
                        },
                        new
                        {
                            Id = 11,
                            CMSComponentId = 5,
                            ComponentVersionId = 9
                        },
                        new
                        {
                            Id = 12,
                            CMSComponentId = 1,
                            ComponentVersionId = 1
                        },
                        new
                        {
                            Id = 13,
                            CMSComponentId = 1,
                            ComponentVersionId = 2
                        },
                        new
                        {
                            Id = 14,
                            CMSComponentId = 1,
                            ComponentVersionId = 11
                        },
                        new
                        {
                            Id = 15,
                            CMSComponentId = 1,
                            ComponentVersionId = 12
                        },
                        new
                        {
                            Id = 16,
                            CMSComponentId = 2,
                            ComponentVersionId = 1
                        },
                        new
                        {
                            Id = 17,
                            CMSComponentId = 2,
                            ComponentVersionId = 4
                        },
                        new
                        {
                            Id = 18,
                            CMSComponentId = 2,
                            ComponentVersionId = 6
                        },
                        new
                        {
                            Id = 19,
                            CMSComponentId = 2,
                            ComponentVersionId = 11
                        });
                });

            modelBuilder.Entity("web_platform.Data.Models.ComponentVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("VersionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComponentVersions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            VersionNumber = "1.1"
                        },
                        new
                        {
                            Id = 2,
                            VersionNumber = "1.2"
                        },
                        new
                        {
                            Id = 3,
                            VersionNumber = "1.3"
                        },
                        new
                        {
                            Id = 4,
                            VersionNumber = "1.4"
                        },
                        new
                        {
                            Id = 5,
                            VersionNumber = "2.1"
                        },
                        new
                        {
                            Id = 6,
                            VersionNumber = "2.2"
                        },
                        new
                        {
                            Id = 7,
                            VersionNumber = "2.3"
                        },
                        new
                        {
                            Id = 8,
                            VersionNumber = "2.4"
                        },
                        new
                        {
                            Id = 9,
                            VersionNumber = "3.1"
                        },
                        new
                        {
                            Id = 10,
                            VersionNumber = "3.2"
                        },
                        new
                        {
                            Id = 11,
                            VersionNumber = "3.3"
                        },
                        new
                        {
                            Id = 12,
                            VersionNumber = "3.4"
                        });
                });

            modelBuilder.Entity("web_platform.Data.Models.SecurityIssuePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CMSComponentVersionId")
                        .HasColumnType("int");

                    b.Property<string>("IssueDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CMSComponentVersionId");

                    b.ToTable("SecurityIssuePosts");
                });

            modelBuilder.Entity("web_platform.Data.Models.SecurityIssuePostReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SecurityIssuePostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("SecurityIssuePostId");

                    b.ToTable("SecurityIssuePostReplies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_platform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web_platform.Data.Models.CMSComponentVersion", b =>
                {
                    b.HasOne("web_platform.Data.Models.CMSComponent", "CMSComponent")
                        .WithMany("CMSComponentVersions")
                        .HasForeignKey("CMSComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_platform.Data.Models.ComponentVersion", "Version")
                        .WithMany("CMSComponentVersions")
                        .HasForeignKey("ComponentVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CMSComponent");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("web_platform.Data.Models.SecurityIssuePost", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("web_platform.Data.Models.CMSComponentVersion", "CMSComponentVersion")
                        .WithMany()
                        .HasForeignKey("CMSComponentVersionId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("CMSComponentVersion");
                });

            modelBuilder.Entity("web_platform.Data.Models.SecurityIssuePostReply", b =>
                {
                    b.HasOne("web_platform.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("web_platform.Data.Models.SecurityIssuePost", "SecurityIssuePost")
                        .WithMany("SecurityIssuePostReplies")
                        .HasForeignKey("SecurityIssuePostId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("SecurityIssuePost");
                });

            modelBuilder.Entity("web_platform.Data.Models.CMSComponent", b =>
                {
                    b.Navigation("CMSComponentVersions");
                });

            modelBuilder.Entity("web_platform.Data.Models.ComponentVersion", b =>
                {
                    b.Navigation("CMSComponentVersions");
                });

            modelBuilder.Entity("web_platform.Data.Models.SecurityIssuePost", b =>
                {
                    b.Navigation("SecurityIssuePostReplies");
                });
#pragma warning restore 612, 618
        }
    }
}
