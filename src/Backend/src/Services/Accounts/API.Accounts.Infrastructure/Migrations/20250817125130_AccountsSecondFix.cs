using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Accounts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountsSecondFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user-soft-delete-sagas",
                table: "user-soft-delete-sagas");

            migrationBuilder.RenameTable(
                name: "user-soft-delete-sagas",
                newName: "user_soft_delete_sagas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_soft_delete_sagas",
                table: "user_soft_delete_sagas",
                column: "CorrelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_soft_delete_sagas",
                table: "user_soft_delete_sagas");

            migrationBuilder.RenameTable(
                name: "user_soft_delete_sagas",
                newName: "user-soft-delete-sagas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user-soft-delete-sagas",
                table: "user-soft-delete-sagas",
                column: "CorrelationId");
        }
    }
}
