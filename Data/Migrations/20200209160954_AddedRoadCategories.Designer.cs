﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZAVOD_KZZ.Data;

namespace ZAVOD_KZZ.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200209160954_AddedRoadCategories")]
    partial class AddedRoadCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.CommunityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("community_types");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.ConservationDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ValidationStatus")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("conservation_documents");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.LocalGovernmentAdministration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeNumber")
                        .HasMaxLength(9);

                    b.Property<int>("CommunityTypeID");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdministrativeCity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<long?>("Population2001")
                        .HasMaxLength(9);

                    b.Property<long?>("Population2011")
                        .HasMaxLength(9);

                    b.Property<long?>("Population2021")
                        .HasMaxLength(9);

                    b.Property<decimal?>("SurfaceArea")
                        .HasMaxLength(9);

                    b.Property<string>("WebSiteUrl")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("CommunityTypeID");

                    b.ToTable("local_governments");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.LocalGovernmentSettlement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeNumber")
                        .HasMaxLength(9);

                    b.Property<int>("LocalGovernmentAdministrationID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("LocalGovernmentAdministrationID");

                    b.ToTable("local_government_settlements");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.ManyToMany.SettlementLocalGovernment", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("SettlementID");

                    b.Property<int>("LocalGovernmentAdministrationID");

                    b.HasKey("Id", "SettlementID", "LocalGovernmentAdministrationID");

                    b.HasIndex("LocalGovernmentAdministrationID");

                    b.HasIndex("SettlementID");

                    b.ToTable("settlement_localgovernment");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.OfficalSpatialNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ShortName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("official_spatial_news");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.RoadCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("road_categories");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("spatial_measures");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanAdditionalDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAdded");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("FileExtension");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<double>("FileSizeInMb");

                    b.Property<int>("SpatialPlanDocumentId");

                    b.Property<string>("UniqueFileName");

                    b.HasKey("Id");

                    b.HasIndex("SpatialPlanDocumentId");

                    b.ToTable("spatial_plan_additional_documents");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryStatus")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("spatial_plan_delivery");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConservationDocumentId");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<DateTime?>("DateArchived");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("FullName")
                        .HasMaxLength(500);

                    b.Property<string>("IspuName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("LocalGovernmentAdministrationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("OfficalSpatialNewsId");

                    b.Property<string>("OfficialSpatialNewsNumber")
                        .IsRequired();

                    b.Property<string>("OfficialSpatialNewsNumberUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficialSpatialNewsRemark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RevisionName")
                        .HasMaxLength(500);

                    b.Property<int>("SpatialMeasureId");

                    b.Property<DateTime?>("SpatialPlanAnnouncementDevelopDate");

                    b.Property<string>("SpatialPlanApprovalRemark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpatialPlanDeliveryId");

                    b.Property<string>("SpatialPlanDocumentationRemark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SpatialPlanEffectiveDate");

                    b.Property<DateTime?>("SpatialPlanEnactmentDate");

                    b.Property<int>("SpatialPlanLevelId");

                    b.Property<DateTime?>("SpatialPlanPublicationDate");

                    b.Property<int>("SpatialPlanRevisionId");

                    b.Property<int>("SpatialPlanStatusId");

                    b.Property<int>("SpatialPlannerId");

                    b.Property<int>("SpatialProjectionId");

                    b.Property<int>("SpuoPuoDocumentId");

                    b.HasKey("Id");

                    b.HasIndex("ConservationDocumentId");

                    b.HasIndex("LocalGovernmentAdministrationId");

                    b.HasIndex("OfficalSpatialNewsId");

                    b.HasIndex("SpatialMeasureId");

                    b.HasIndex("SpatialPlanDeliveryId");

                    b.HasIndex("SpatialPlanLevelId");

                    b.HasIndex("SpatialPlanRevisionId");

                    b.HasIndex("SpatialPlanStatusId");

                    b.HasIndex("SpatialPlannerId");

                    b.HasIndex("SpatialProjectionId");

                    b.HasIndex("SpuoPuoDocumentId");

                    b.ToTable("spatial_plan_documents");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("spatial_plan_levels");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanRevision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RevisionStatus")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("spatial_plan_revisions");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("spatial_plan_status");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("WebAdress");

                    b.HasKey("Id");

                    b.ToTable("spatial_planners");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialProjection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionOverview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EpsgCode")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ShortName")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("spatial_projections");
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpuoPuoDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("spuo_puo_documents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.LocalGovernmentAdministration", b =>
                {
                    b.HasOne("ZAVOD_KZZ.Core.Models.CommunityType", "CommunityType")
                        .WithMany()
                        .HasForeignKey("CommunityTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.LocalGovernmentSettlement", b =>
                {
                    b.HasOne("ZAVOD_KZZ.Core.Models.LocalGovernmentAdministration", "LocalGovernmentAdministrations")
                        .WithMany()
                        .HasForeignKey("LocalGovernmentAdministrationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.ManyToMany.SettlementLocalGovernment", b =>
                {
                    b.HasOne("ZAVOD_KZZ.Core.Models.LocalGovernmentAdministration", "LocalGovernment")
                        .WithMany("SettlementLocalGovernments")
                        .HasForeignKey("LocalGovernmentAdministrationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ZAVOD_KZZ.Core.Models.LocalGovernmentSettlement", "Settlement")
                        .WithMany("SettlementLocalGovernments")
                        .HasForeignKey("SettlementID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanAdditionalDocument", b =>
                {
                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialPlanDocument", "SpatialPlanDocument")
                        .WithMany("SpatialPlanAdditionalDocuments")
                        .HasForeignKey("SpatialPlanDocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZAVOD_KZZ.Core.Models.SpatialPlanDocument", b =>
                {
                    b.HasOne("ZAVOD_KZZ.Core.Models.ConservationDocument", "ConservationDocument")
                        .WithMany()
                        .HasForeignKey("ConservationDocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.LocalGovernmentAdministration", "LocalGovernmentAdministration")
                        .WithMany()
                        .HasForeignKey("LocalGovernmentAdministrationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.OfficalSpatialNews", "OfficalSpatialNews")
                        .WithMany()
                        .HasForeignKey("OfficalSpatialNewsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialMeasure", "SpatialMeasure")
                        .WithMany()
                        .HasForeignKey("SpatialMeasureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialPlanDelivery", "SpatialPlanDelivery")
                        .WithMany()
                        .HasForeignKey("SpatialPlanDeliveryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialPlanLevel", "SpatialPlanLevel")
                        .WithMany()
                        .HasForeignKey("SpatialPlanLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialPlanRevision", "SpatialPlanRevision")
                        .WithMany()
                        .HasForeignKey("SpatialPlanRevisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialPlanStatus", "SpatialPlanStatus")
                        .WithMany()
                        .HasForeignKey("SpatialPlanStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialPlanner", "SpatialPlanner")
                        .WithMany("SpatialPlanDocuments")
                        .HasForeignKey("SpatialPlannerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpatialProjection", "SpatialProjection")
                        .WithMany()
                        .HasForeignKey("SpatialProjectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZAVOD_KZZ.Core.Models.SpuoPuoDocument", "SpuoPuoDocument")
                        .WithMany()
                        .HasForeignKey("SpuoPuoDocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
