using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class updateCtpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayMuon",
                table: "ChiTietPhieuTras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SoNgayMuon",
                table: "ChiTietPhieuTras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TienPhat",
                table: "ChiTietPhieuTras",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayMuon",
                table: "ChiTietPhieuTras");

            migrationBuilder.DropColumn(
                name: "SoNgayMuon",
                table: "ChiTietPhieuTras");

            migrationBuilder.DropColumn(
                name: "TienPhat",
                table: "ChiTietPhieuTras");
        }
    }
}
