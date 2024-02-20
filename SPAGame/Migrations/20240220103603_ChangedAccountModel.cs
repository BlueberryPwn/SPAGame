using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGame.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAccountModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPasswordSalt",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountRegistrationDate",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AccountPasswordSalt",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AccountRegistrationDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
