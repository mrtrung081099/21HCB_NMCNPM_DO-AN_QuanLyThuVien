using Entities.DTO.PhieuMuon;
using Entities.DTO.Sach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface ISachService
    {
        public Task<SachDto> CreateSachAsync(SachForCreationDto Sach);
        public Task<IEnumerable<SachDto>> GetAllSachAsync(SachParameters SachParameters);
        public Task<IEnumerable<SachDto>> GetAllSachByStateAsync(SachParameters SachParameters);
        public Task<IEnumerable<SachDto>> GetAllSachByNameAsync(SachParameters SachParameters);
        public Task<List<SachMuonDto>> GetListSachMuonByDocGiaId(Guid docgiaId, DateTime ngayTra);
        public Task<List<SachMuonDto>> GetListSachTraByPtId(Guid ptId);
        public Task<SachDto> GetSachDtoByIdAsync(Guid id);
        public Task<Sach> GetSachByIdAsync(Guid id);
        public void DeleteSachAsync(Sach Sach);
        public Task<int> GetCountSach();
        public Task<SachDto> UpdateSachAsync(Sach Sach);
        public Task UpdateStateSachAsync(Guid sachId, string state);
    }
}
