using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class updatePhieutra_Phieuphat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TienNo",
                table: "PhieuTras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TongNo",
                table: "PhieuTras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TienNo",
                table: "PhieuPhats",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TienNoConlai",
                table: "PhieuPhats",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TienNo",
                table: "PhieuTras");

            migrationBuilder.DropColumn(
                name: "TongNo",
                table: "PhieuTras");

            migrationBuilder.DropColumn(
                name: "TienNo",
                table: "PhieuPhats");

            migrationBuilder.DropColumn(
                name: "TienNoConlai",
                table: "PhieuPhats");
        }
    }
}
