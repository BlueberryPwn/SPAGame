using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameWord",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameNumber",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameNumber",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "GameWord",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
