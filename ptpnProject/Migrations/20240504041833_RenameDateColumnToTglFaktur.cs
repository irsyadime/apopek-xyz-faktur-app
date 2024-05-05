using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptpnProject.Migrations
{
    /// <inheritdoc />
    public partial class RenameDateColumnToTglFaktur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TglFaktur",
                table: "Fakturs",
                newName: "TglFaktur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TglFaktur",
                table: "Fakturs",
                newName: "TglFaktur");
        }
    }
}
