using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Again.Data.Migrations
{
    /// <inheritdoc />
    public partial class Again1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    TacgiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TacgiaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacgiaQuocTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacgiaNgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGia", x => x.TacgiaID);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    SachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SachName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SachGia = table.Column<double>(type: "float", nullable: false),
                    SachMota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SachTheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SachNSX = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SachImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TacgiaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.SachID);
                    table.ForeignKey(
                        name: "FK_Sach_TacGia_TacgiaID",
                        column: x => x.TacgiaID,
                        principalTable: "TacGia",
                        principalColumn: "TacgiaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TacgiaID",
                table: "Sach",
                column: "TacgiaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "TacGia");
        }
    }
}
