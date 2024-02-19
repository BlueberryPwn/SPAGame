using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class AddGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guess1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guess2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guess3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guess4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guess5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameFinished = table.Column<bool>(type: "bit", nullable: false),
                    GameLost = table.Column<bool>(type: "bit", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
