using Entities.DTO.PhieuMuon;
using Entities.DTO.Sach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IPhieuMuonService
    {
        public Task<PhieuMuonDto> CreatePhieuMuonAsync(PhieuMuonForCreationDto pm);
        public Task<PhieuMuon> GetPhieuMuonByIdAsync(Guid id);
        public Task<PhieuMuonDto> GetPhieuMuonDtoByIdAsync(Guid id);
        public Task<IEnumerable<PhieuMuonDto>> GetAllPhieuMuonDtoAsync(PhieuMuonParameters pm);
        public Task<int> GetCountPhieuMuon();

    }
}
