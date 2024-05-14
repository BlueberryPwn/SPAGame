using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedHighscoreTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighScores_Accounts_AccountId",
                table: "HighScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HighScores",
                table: "HighScores");

            migrationBuilder.RenameTable(
                name: "HighScores",
                newName: "Highscores");

            migrationBuilder.RenameIndex(
                name: "IX_HighScores_AccountId",
                table: "Highscores",
                newName: "IX_Highscores_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Highscores",
                table: "Highscores",
                column: "HighscoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Highscores_Accounts_AccountId",
                table: "Highscores",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Highscores_Accounts_AccountId",
                table: "Highscores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Highscores",
                table: "Highscores");

            migrationBuilder.RenameTable(
                name: "Highscores",
                newName: "HighScores");

            migrationBuilder.RenameIndex(
                name: "IX_Highscores_AccountId",
                table: "HighScores",
                newName: "IX_HighScores_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HighScores",
                table: "HighScores",
                column: "HighscoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_HighScores_Accounts_AccountId",
                table: "HighScores",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
