using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class createNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietThanhLySachs",
                columns: table => new
                {
                    ChiTietThanhLySachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LyDoThanhLy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietThanhLySachs", x => x.ChiTietThanhLySachId);
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLySachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuMatSachs",
                columns: table => new
                {
                    PhieuMatSachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayGhiNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TienPhat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuMatSachs", x => x.PhieuMatSachId);
                    table.ForeignKey(
                        name: "FK_PhieuMatSachs_DocGias_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGias",
                        principalColumn: "DocGiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuMatSachs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId");
                    table.ForeignKey(
                        name: "FK_PhieuMatSachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuPhats",
                columns: table => new
                {
                    PhieuPhatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TienThu = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuPhats", x => x.PhieuPhatId);
                    table.ForeignKey(
                        name: "FK_PhieuPhats_DocGias_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGias",
                        principalColumn: "DocGiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuPhats_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId");
                });

            migrationBuilder.CreateTable(
                name: "ThanhLySachs",
                columns: table => new
                {
                    ThanhLySachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayThanhLy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhLySachs", x => x.ThanhLySachId);
                    table.ForeignKey(
                        name: "FK_ThanhLySachs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLySachs_SachId",
                table: "ChiTietThanhLySachs",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMatSachs_DocGiaId",
                table: "PhieuMatSachs",
                column: "DocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMatSachs_NhanVienId",
                table: "PhieuMatSachs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMatSachs_SachId",
                table: "PhieuMatSachs",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuPhats_DocGiaId",
                table: "PhieuPhats",
                column: "DocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuPhats_NhanVienId",
                table: "PhieuPhats",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLySachs_NhanVienId",
                table: "ThanhLySachs",
                column: "NhanVienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietThanhLySachs");

            migrationBuilder.DropTable(
                name: "PhieuMatSachs");

            migrationBuilder.DropTable(
                name: "PhieuPhats");

            migrationBuilder.DropTable(
                name: "ThanhLySachs");
        }
    }
}
