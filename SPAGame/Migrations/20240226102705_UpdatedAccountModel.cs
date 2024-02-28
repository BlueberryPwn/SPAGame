using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAccountModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPassword",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountPasswordHash",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmedAccountPasswordHash",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPasswordHash",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ConfirmedAccountPasswordHash",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountPassword",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
