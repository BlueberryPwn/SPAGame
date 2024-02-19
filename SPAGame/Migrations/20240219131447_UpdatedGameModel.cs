using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameFinished",
                table: "Games",
                newName: "GameWon");

            migrationBuilder.AddColumn<int>(
                name: "GamesCompleted",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_AccountId",
                table: "Games",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Accounts_AccountId",
                table: "Games",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Accounts_AccountId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_AccountId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GamesCompleted",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameWon",
                table: "Games",
                newName: "GameFinished");
        }
    }
}
