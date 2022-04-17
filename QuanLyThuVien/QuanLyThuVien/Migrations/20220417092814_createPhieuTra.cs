using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class createPhieuTra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons",
                column: "PhieuMuonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuMuons_PhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons",
                column: "PhieuMuonId",
                principalTable: "PhieuMuons",
                principalColumn: "PhieuMuonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuMuons_PhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons");
        }
    }
}
