using Entities.DTO.PhieuMuon;
using Entities.DTO.Sach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface ICTPhieuMuonService
    {
        public Task CreateCTPhieuMuonAsync(CTPhieuMuonForCreationDto ctpm);
        public Task CreateCtPmAsync(SachMuonForCreationDto ctpm,Guid pmId);
        public Task<IEnumerable<ChiTietPhieuMuon>> GetAllCTPhieuMuonByPmId(Guid pmId);

        public Task<List<SachDto>> GetAllSachMuonByPmId(Guid pmId);
    }
}
