using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyThuVien.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BangCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.NhanVienId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DocGias",
                columns: table => new
                {
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongNo = table.Column<float>(type: "real", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocGias", x => x.DocGiaId);
                    table.ForeignKey(
                        name: "FK_DocGias_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId");
                });

            migrationBuilder.CreateTable(
                name: "Sachs",
                columns: table => new
                {
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamSx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhaSx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<float>(type: "real", nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sachs", x => x.SachId);
                    table.ForeignKey(
                        name: "FK_Sachs_NhanViens_NhanVienId",
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
                        principalColumn: "NhanVienId");
                });

            migrationBuilder.CreateTable(
                name: "PhieuMuons",
                columns: table => new
                {
                    PhieuMuonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuMuons", x => x.PhieuMuonId);
                    table.ForeignKey(
                        name: "FK_PhieuMuons_DocGias_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGias",
                        principalColumn: "DocGiaId");
                });

            migrationBuilder.CreateTable(
                name: "PhieuPhats",
                columns: table => new
                {
                    PhieuPhatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TienNo = table.Column<float>(type: "real", nullable: false),
                    TienThu = table.Column<float>(type: "real", nullable: false),
                    TienNoConlai = table.Column<float>(type: "real", nullable: false),
                    NgayThu = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuPhats", x => x.PhieuPhatId);
                    table.ForeignKey(
                        name: "FK_PhieuPhats_DocGias_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGias",
                        principalColumn: "DocGiaId");
                    table.ForeignKey(
                        name: "FK_PhieuPhats_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId");
                });

            migrationBuilder.CreateTable(
                name: "PhieuTras",
                columns: table => new
                {
                    PhieuTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TienPhat = table.Column<float>(type: "real", nullable: false),
                    TienNo = table.Column<float>(type: "real", nullable: false),
                    TongNo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuTras", x => x.PhieuTraId);
                    table.ForeignKey(
                        name: "FK_PhieuTras_DocGias_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGias",
                        principalColumn: "DocGiaId");
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
                        principalColumn: "DocGiaId");
                    table.ForeignKey(
                        name: "FK_PhieuMatSachs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId");
                    table.ForeignKey(
                        name: "FK_PhieuMatSachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThanhLySachs",
                columns: table => new
                {
                    ChiTietThanhLySachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThanhLySachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LyDoThanhLy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietThanhLySachs", x => x.ChiTietThanhLySachId);
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLySachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId");
                    table.ForeignKey(
                        name: "FK_ChiTietThanhLySachs_ThanhLySachs_ThanhLySachId",
                        column: x => x.ThanhLySachId,
                        principalTable: "ThanhLySachs",
                        principalColumn: "ThanhLySachId");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuMuons",
                columns: table => new
                {
                    ChiTietPhieuMuonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuMuonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuMuons", x => x.ChiTietPhieuMuonId);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuons_PhieuMuons_PhieuMuonId",
                        column: x => x.PhieuMuonId,
                        principalTable: "PhieuMuons",
                        principalColumn: "PhieuMuonId");
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuons_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuTras",
                columns: table => new
                {
                    ChiTietPhieuTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhieuTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoNgayMuon = table.Column<int>(type: "int", nullable: false),
                    TienPhat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuTras", x => x.ChiTietPhieuTraId);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuTras_PhieuTras_PhieuTraId",
                        column: x => x.PhieuTraId,
                        principalTable: "PhieuTras",
                        principalColumn: "PhieuTraId");
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuTras_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons",
                column: "PhieuMuonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuons_SachId",
                table: "ChiTietPhieuMuons",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuTras_PhieuTraId",
                table: "ChiTietPhieuTras",
                column: "PhieuTraId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuTras_SachId",
                table: "ChiTietPhieuTras",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLySachs_SachId",
                table: "ChiTietThanhLySachs",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhLySachs_ThanhLySachId",
                table: "ChiTietThanhLySachs",
                column: "ThanhLySachId");

            migrationBuilder.CreateIndex(
                name: "IX_DocGias_NhanVienId",
                table: "DocGias",
                column: "NhanVienId");

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
                name: "IX_PhieuMuons_DocGiaId",
                table: "PhieuMuons",
                column: "DocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuPhats_DocGiaId",
                table: "PhieuPhats",
                column: "DocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuPhats_NhanVienId",
                table: "PhieuPhats",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTras_DocGiaId",
                table: "PhieuTras",
                column: "DocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sachs_NhanVienId",
                table: "Sachs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLySachs_NhanVienId",
                table: "ThanhLySachs",
                column: "NhanVienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuMuons");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuTras");

            migrationBuilder.DropTable(
                name: "ChiTietThanhLySachs");

            migrationBuilder.DropTable(
                name: "PhieuMatSachs");

            migrationBuilder.DropTable(
                name: "PhieuPhats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PhieuMuons");

            migrationBuilder.DropTable(
                name: "PhieuTras");

            migrationBuilder.DropTable(
                name: "ThanhLySachs");

            migrationBuilder.DropTable(
                name: "Sachs");

            migrationBuilder.DropTable(
                name: "DocGias");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
