using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class updateCTPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuMuons_PhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons");

            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "ChiTietPhieuMuons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "ChiTietPhieuMuons");

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
    }
}
