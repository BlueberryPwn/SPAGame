using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class RemovedConfirmedPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPasswordHash",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ConfirmedAccountPasswordHash",
                table: "Accounts",
                newName: "AccountPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountPassword",
                table: "Accounts",
                newName: "ConfirmedAccountPasswordHash");

            migrationBuilder.AddColumn<string>(
                name: "AccountPasswordHash",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
