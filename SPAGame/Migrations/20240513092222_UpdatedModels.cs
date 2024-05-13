using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameLost",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Guess1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Guess2",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Guess3",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Guess4",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Guess5",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GamesCompleted",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "GamesLost",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "GamesWon",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "GameWon",
                table: "Games",
                newName: "GameActive");

            migrationBuilder.AlterColumn<string>(
                name: "GameWord",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameAttempts",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameAttempts",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameActive",
                table: "Games",
                newName: "GameWon");

            migrationBuilder.AlterColumn<string>(
                name: "GameWord",
                table: "Games",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GameLost",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Guess1",
                table: "Games",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guess2",
                table: "Games",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guess3",
                table: "Games",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guess4",
                table: "Games",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guess5",
                table: "Games",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesCompleted",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesLost",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesWon",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
