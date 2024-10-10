using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Again.Data.Migrations
{
    /// <inheritdoc />
    public partial class IDchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TacgiaID",
                table: "TacGia",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TacGia",
                newName: "TacgiaID");
        }
    }
}
