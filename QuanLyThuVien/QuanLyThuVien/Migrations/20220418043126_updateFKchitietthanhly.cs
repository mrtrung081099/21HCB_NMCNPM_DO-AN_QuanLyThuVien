using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class updateFKchitietthanhly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThanhLySachId",
                table: "ChiTietThanhLySachs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLySachs_ThanhLySachId",
                table: "ChiTietThanhLySachs",
                column: "ThanhLySachId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietThanhLySachs_ThanhLySachs_ThanhLySachId",
                table: "ChiTietThanhLySachs",
                column: "ThanhLySachId",
                principalTable: "ThanhLySachs",
                principalColumn: "ThanhLySachId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietThanhLySachs_ThanhLySachs_ThanhLySachId",
                table: "ChiTietThanhLySachs");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietThanhLySachs_ThanhLySachId",
                table: "ChiTietThanhLySachs");

            migrationBuilder.DropColumn(
                name: "ThanhLySachId",
                table: "ChiTietThanhLySachs");
        }
    }
}
