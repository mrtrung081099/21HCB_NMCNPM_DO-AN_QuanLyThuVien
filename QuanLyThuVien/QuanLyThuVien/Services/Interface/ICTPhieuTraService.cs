using Entities.DTO.PhieuMuon;
using Entities.DTO.PhieuTra;
using Entities.DTO.Sach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface ICTPhieuTraService
    {
        public Task CreateCTPhieuTraAsync(CTPhieuTraForCreationDto ctpt);
        public Task CreateCtptAsync(SachMuonDto ctpt, Guid ptId);
        public Task<IEnumerable<ChiTietPhieuTra>> GetAllCTPhieuTraByptId(Guid ptId);
    }
}
