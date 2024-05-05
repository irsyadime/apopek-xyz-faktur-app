using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptpnProject.Migrations
{
    /// <inheritdoc />
    public partial class addDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TglFaktur",
                table: "Fakturs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "Fakturs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TglFaktur",
                table: "Fakturs");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Fakturs");
        }
    }
}
