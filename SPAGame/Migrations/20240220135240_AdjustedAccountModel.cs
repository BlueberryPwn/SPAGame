using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedAccountModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPasswordHash",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountPassword",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPassword",
                table: "Accounts");

            migrationBuilder.AddColumn<byte[]>(
                name: "AccountPasswordHash",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
