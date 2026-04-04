using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Chats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChatsInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGroupChat = table.Column<bool>(type: "bit", nullable: false),
                    AIEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chat_agent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_agent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chat_feature",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    UserRestrictionsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "internal_outbox",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_internal_outbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_profile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockedOut = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blocked_profile",
                columns: table => new
                {
                    BlockedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlockedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blocked_profile", x => new { x.BlockedById, x.BlockedUserId });
                    table.ForeignKey(
                        name: "FK_blocked_profile_user_profile_BlockedById",
                        column: x => x.BlockedById,
                        principalTable: "user_profile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blocked_profile_user_profile_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "user_profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "feature_restricted_user",
                columns: table => new
                {
                    ChatFeatureId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestrictedProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature_restricted_user", x => new { x.RestrictedProfileId, x.ChatFeatureId });
                    table.ForeignKey(
                        name: "FK_feature_restricted_user_chat_feature_ChatFeatureId",
                        column: x => x.ChatFeatureId,
                        principalTable: "chat_feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feature_restricted_user_user_profile_RestrictedProfileId",
                        column: x => x.RestrictedProfileId,
                        principalTable: "user_profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feature_test_user",
                columns: table => new
                {
                    ChatFeatureId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature_test_user", x => new { x.TestProfileId, x.ChatFeatureId });
                    table.ForeignKey(
                        name: "FK_feature_test_user_chat_feature_ChatFeatureId",
                        column: x => x.ChatFeatureId,
                        principalTable: "chat_feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feature_test_user_user_profile_TestProfileId",
                        column: x => x.TestProfileId,
                        principalTable: "user_profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatAgentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_participant_chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participant_chat_agent_ChatAgentId",
                        column: x => x.ChatAgentId,
                        principalTable: "chat_agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_participant_user_profile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "user_profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TextContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_message_chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_message_participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blocked_profile_BlockedUserId",
                table: "blocked_profile",
                column: "BlockedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_chat_agent_AgentUsername",
                table: "chat_agent",
                column: "AgentUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chat_feature_FeatureName",
                table: "chat_feature",
                column: "FeatureName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feature_restricted_user_ChatFeatureId",
                table: "feature_restricted_user",
                column: "ChatFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_feature_test_user_ChatFeatureId",
                table: "feature_test_user",
                column: "ChatFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_message_ChatId",
                table: "message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_message_ParticipantId",
                table: "message",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_participant_ChatAgentId",
                table: "participant",
                column: "ChatAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_participant_ChatId",
                table: "participant",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_participant_UserProfileId",
                table: "participant",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_user_profile_UserId",
                table: "user_profile",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blocked_profile");

            migrationBuilder.DropTable(
                name: "feature_restricted_user");

            migrationBuilder.DropTable(
                name: "feature_test_user");

            migrationBuilder.DropTable(
                name: "internal_outbox");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "chat_feature");

            migrationBuilder.DropTable(
                name: "participant");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "chat_agent");

            migrationBuilder.DropTable(
                name: "user_profile");
        }
    }
}
