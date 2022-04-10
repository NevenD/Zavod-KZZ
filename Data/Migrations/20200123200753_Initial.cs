using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "community_types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_community_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conservation_documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValidationStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conservation_documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "official_spatial_news",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_official_spatial_news", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_measures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_measures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_plan_delivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeliveryStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_plan_delivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_plan_levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShortName = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_plan_levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_plan_revisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RevisionStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_plan_revisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_plan_status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_plan_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_planners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    WebAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_planners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spatial_projections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(maxLength: 20, nullable: true),
                    EpsgCode = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_projections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spuo_puo_documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spuo_puo_documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "local_governments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNumber = table.Column<int>(maxLength: 9, nullable: false),
                    SurfaceArea = table.Column<decimal>(maxLength: 9, nullable: true),
                    Population2001 = table.Column<long>(maxLength: 9, nullable: true),
                    Population2011 = table.Column<long>(maxLength: 9, nullable: true),
                    Population2021 = table.Column<long>(maxLength: 9, nullable: true),
                    WebSiteUrl = table.Column<string>(maxLength: 300, nullable: true),
                    IsAdministrativeCity = table.Column<bool>(nullable: false),
                    CommunityTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_governments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_local_governments_community_types_CommunityTypeID",
                        column: x => x.CommunityTypeID,
                        principalTable: "community_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "local_government_settlements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    CodeNumber = table.Column<int>(maxLength: 9, nullable: false),
                    LocalGovernmentAdministrationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_government_settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_local_government_settlements_local_governments_LocalGovernmentAdministrationID",
                        column: x => x.LocalGovernmentAdministrationID,
                        principalTable: "local_governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spatial_plan_documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    LocalGovernmentAdministrationId = table.Column<int>(nullable: false),
                    SpatialPlanLevelId = table.Column<int>(nullable: false),
                    SpatialPlanRevisionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    FullName = table.Column<string>(maxLength: 500, nullable: true),
                    RevisionName = table.Column<string>(maxLength: 500, nullable: true),
                    IspuName = table.Column<string>(maxLength: 50, nullable: false),
                    SpatialMeasureId = table.Column<int>(nullable: false),
                    SpatialPlanEnactmentDate = table.Column<DateTime>(nullable: true),
                    OfficalSpatialNewsId = table.Column<int>(nullable: false),
                    OfficialSpatialNewsNumber = table.Column<string>(nullable: false),
                    SpatialPlanPublicationDate = table.Column<DateTime>(nullable: true),
                    SpatialPlanEffectiveDate = table.Column<DateTime>(nullable: true),
                    OfficialSpatialNewsRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpatialPlanAnnouncementDevelopDate = table.Column<DateTime>(nullable: true),
                    SpatialPlanApprovalRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpatialPlannerId = table.Column<int>(nullable: false),
                    SpatialProjectionId = table.Column<int>(nullable: false),
                    SpatialPlanDeliveryId = table.Column<int>(nullable: false),
                    ConservationDocumentId = table.Column<int>(nullable: false),
                    SpuoPuoDocumentId = table.Column<int>(nullable: false),
                    SpatialPlanStatusId = table.Column<int>(nullable: false),
                    SpatialPlanDocumentationRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateArchived = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_plan_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_conservation_documents_ConservationDocumentId",
                        column: x => x.ConservationDocumentId,
                        principalTable: "conservation_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_local_governments_LocalGovernmentAdministrationId",
                        column: x => x.LocalGovernmentAdministrationId,
                        principalTable: "local_governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_official_spatial_news_OfficalSpatialNewsId",
                        column: x => x.OfficalSpatialNewsId,
                        principalTable: "official_spatial_news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_measures_SpatialMeasureId",
                        column: x => x.SpatialMeasureId,
                        principalTable: "spatial_measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_plan_delivery_SpatialPlanDeliveryId",
                        column: x => x.SpatialPlanDeliveryId,
                        principalTable: "spatial_plan_delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_plan_levels_SpatialPlanLevelId",
                        column: x => x.SpatialPlanLevelId,
                        principalTable: "spatial_plan_levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_plan_revisions_SpatialPlanRevisionId",
                        column: x => x.SpatialPlanRevisionId,
                        principalTable: "spatial_plan_revisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_plan_status_SpatialPlanStatusId",
                        column: x => x.SpatialPlanStatusId,
                        principalTable: "spatial_plan_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_planners_SpatialPlannerId",
                        column: x => x.SpatialPlannerId,
                        principalTable: "spatial_planners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spatial_projections_SpatialProjectionId",
                        column: x => x.SpatialProjectionId,
                        principalTable: "spatial_projections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spatial_plan_documents_spuo_puo_documents_SpuoPuoDocumentId",
                        column: x => x.SpuoPuoDocumentId,
                        principalTable: "spuo_puo_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "settlement_localgovernment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SettlementID = table.Column<int>(nullable: false),
                    LocalGovernmentAdministrationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settlement_localgovernment", x => new { x.Id, x.SettlementID, x.LocalGovernmentAdministrationID });
                    table.ForeignKey(
                        name: "FK_settlement_localgovernment_local_governments_LocalGovernmentAdministrationID",
                        column: x => x.LocalGovernmentAdministrationID,
                        principalTable: "local_governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_settlement_localgovernment_local_government_settlements_SettlementID",
                        column: x => x.SettlementID,
                        principalTable: "local_government_settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spatial_plan_additional_documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    UniqueFileName = table.Column<string>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    FileSize = table.Column<string>(nullable: true),
                    SpatialPlanDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spatial_plan_additional_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spatial_plan_additional_documents_spatial_plan_documents_SpatialPlanDocumentId",
                        column: x => x.SpatialPlanDocumentId,
                        principalTable: "spatial_plan_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_local_government_settlements_LocalGovernmentAdministrationID",
                table: "local_government_settlements",
                column: "LocalGovernmentAdministrationID");

            migrationBuilder.CreateIndex(
                name: "IX_local_governments_CommunityTypeID",
                table: "local_governments",
                column: "CommunityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_localgovernment_LocalGovernmentAdministrationID",
                table: "settlement_localgovernment",
                column: "LocalGovernmentAdministrationID");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_localgovernment_SettlementID",
                table: "settlement_localgovernment",
                column: "SettlementID");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_additional_documents_SpatialPlanDocumentId",
                table: "spatial_plan_additional_documents",
                column: "SpatialPlanDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_ConservationDocumentId",
                table: "spatial_plan_documents",
                column: "ConservationDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_LocalGovernmentAdministrationId",
                table: "spatial_plan_documents",
                column: "LocalGovernmentAdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_OfficalSpatialNewsId",
                table: "spatial_plan_documents",
                column: "OfficalSpatialNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialMeasureId",
                table: "spatial_plan_documents",
                column: "SpatialMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialPlanDeliveryId",
                table: "spatial_plan_documents",
                column: "SpatialPlanDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialPlanLevelId",
                table: "spatial_plan_documents",
                column: "SpatialPlanLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialPlanRevisionId",
                table: "spatial_plan_documents",
                column: "SpatialPlanRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialPlanStatusId",
                table: "spatial_plan_documents",
                column: "SpatialPlanStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialPlannerId",
                table: "spatial_plan_documents",
                column: "SpatialPlannerId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpatialProjectionId",
                table: "spatial_plan_documents",
                column: "SpatialProjectionId");

            migrationBuilder.CreateIndex(
                name: "IX_spatial_plan_documents_SpuoPuoDocumentId",
                table: "spatial_plan_documents",
                column: "SpuoPuoDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "settlement_localgovernment");

            migrationBuilder.DropTable(
                name: "spatial_plan_additional_documents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "local_government_settlements");

            migrationBuilder.DropTable(
                name: "spatial_plan_documents");

            migrationBuilder.DropTable(
                name: "conservation_documents");

            migrationBuilder.DropTable(
                name: "local_governments");

            migrationBuilder.DropTable(
                name: "official_spatial_news");

            migrationBuilder.DropTable(
                name: "spatial_measures");

            migrationBuilder.DropTable(
                name: "spatial_plan_delivery");

            migrationBuilder.DropTable(
                name: "spatial_plan_levels");

            migrationBuilder.DropTable(
                name: "spatial_plan_revisions");

            migrationBuilder.DropTable(
                name: "spatial_plan_status");

            migrationBuilder.DropTable(
                name: "spatial_planners");

            migrationBuilder.DropTable(
                name: "spatial_projections");

            migrationBuilder.DropTable(
                name: "spuo_puo_documents");

            migrationBuilder.DropTable(
                name: "community_types");
        }
    }
}
