using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class createCTPhieuTra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuTras",
                columns: table => new
                {
                    PhieuTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TienPhat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuTras", x => x.PhieuTraId);
                    table.ForeignKey(
                        name: "FK_PhieuTras_DocGias_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGias",
                        principalColumn: "DocGiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuTras",
                columns: table => new
                {
                    ChiTietPhieuTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhieuTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuTras", x => x.ChiTietPhieuTraId);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuTras_PhieuTras_PhieuTraId",
                        column: x => x.PhieuTraId,
                        principalTable: "PhieuTras",
                        principalColumn: "PhieuTraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuTras_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuTras_PhieuTraId",
                table: "ChiTietPhieuTras",
                column: "PhieuTraId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuTras_SachId",
                table: "ChiTietPhieuTras",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTras_DocGiaId",
                table: "PhieuTras",
                column: "DocGiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuTras");

            migrationBuilder.DropTable(
                name: "PhieuTras");
        }
    }
}
