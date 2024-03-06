﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class AddedGamesWonAndLost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesLost",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesWon",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesLost",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GamesWon",
                table: "Games");
        }
    }
}
