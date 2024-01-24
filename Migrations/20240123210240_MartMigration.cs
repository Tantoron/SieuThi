using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SieuThi.Migrations
{
    public partial class MartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Masp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Donvi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaBan = table.Column<int>(type: "int", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Masp);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Manv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tennv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luong = table.Column<int>(type: "int", nullable: true),
                    Ca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotaCV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Manv);
                });

            migrationBuilder.CreateTable(
                name: "Storeds",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Masp_FKMasp = table.Column<int>(type: "int", nullable: true),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaNhap = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storeds", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_Storeds_Products_Masp_FKMasp",
                        column: x => x.Masp_FKMasp,
                        principalTable: "Products",
                        principalColumn: "Masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesManagements",
                columns: table => new
                {
                    Mahoadon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manv_FKManv = table.Column<int>(type: "int", nullable: true),
                    TriGia = table.Column<int>(type: "int", nullable: true),
                    Masp_FKMasp = table.Column<int>(type: "int", nullable: true),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesManagements", x => x.Mahoadon);
                    table.ForeignKey(
                        name: "FK_SalesManagements_Products_Masp_FKMasp",
                        column: x => x.Masp_FKMasp,
                        principalTable: "Products",
                        principalColumn: "Masp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesManagements_Staffs_Manv_FKManv",
                        column: x => x.Manv_FKManv,
                        principalTable: "Staffs",
                        principalColumn: "Manv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReports",
                columns: table => new
                {
                    MaBaoCao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoanhThu = table.Column<int>(type: "int", nullable: true),
                    Manv_FKManv = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReports", x => x.MaBaoCao);
                    table.ForeignKey(
                        name: "FK_SalesReports_Staffs_Manv_FKManv",
                        column: x => x.Manv_FKManv,
                        principalTable: "Staffs",
                        principalColumn: "Manv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagements_Manv_FKManv",
                table: "SalesManagements",
                column: "Manv_FKManv");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagements_Masp_FKMasp",
                table: "SalesManagements",
                column: "Masp_FKMasp");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReports_Manv_FKManv",
                table: "SalesReports",
                column: "Manv_FKManv");

            migrationBuilder.CreateIndex(
                name: "IX_Storeds_Masp_FKMasp",
                table: "Storeds",
                column: "Masp_FKMasp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesManagements");

            migrationBuilder.DropTable(
                name: "SalesReports");

            migrationBuilder.DropTable(
                name: "Storeds");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
