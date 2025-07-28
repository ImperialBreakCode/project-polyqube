using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Admin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feature_infos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    UserRestrictionsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature_infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "feature_restricted_users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestrictedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature_restricted_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feature_restricted_users_feature_infos_FeatureInfoId",
                        column: x => x.FeatureInfoId,
                        principalTable: "feature_infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feature_test_users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature_test_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feature_test_users_feature_infos_FeatureInfoId",
                        column: x => x.FeatureInfoId,
                        principalTable: "feature_infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feature_restricted_users_FeatureInfoId",
                table: "feature_restricted_users",
                column: "FeatureInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_feature_restricted_users_RestrictedUserId",
                table: "feature_restricted_users",
                column: "RestrictedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feature_test_users_FeatureInfoId",
                table: "feature_test_users",
                column: "FeatureInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_feature_test_users_TestUserId",
                table: "feature_test_users",
                column: "TestUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feature_restricted_users");

            migrationBuilder.DropTable(
                name: "feature_test_users");

            migrationBuilder.DropTable(
                name: "feature_infos");
        }
    }
}
