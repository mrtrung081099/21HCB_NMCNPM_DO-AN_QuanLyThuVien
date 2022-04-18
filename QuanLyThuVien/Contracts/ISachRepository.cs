using Entities.DTO.Sach;
using Entities.DTO.ThanhLySach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISachRepository
    {
        Task<IEnumerable<Sach>> GetAllSachAsync(SachParameters sachParameters);
        Task<IEnumerable<Sach>> GetAllSachByStateAsync(SachParameters sachParameters);
        Task<IEnumerable<Sach>> GetAllSachByNameAsync(SachParameters sachParameters);
        Task<List<SachMuonDto>> GetAllSachMuonByDocGiaIdAsync(Guid docgiaId);
        Task<List<SachMuonDto>> GetAllSachMuonByPhieuTraIdAsync(Guid ptId);
        Task<List<SachThanhLyDto>> GetAllSachThanhLyByTlsIdAsync(Guid tlsId);

        Task<Sach> GetSachByIdAsync(Guid id);
        Task<int> Count();
        Task<int> CountTotalByState(string trinhTrang);
        Task<int> CountTotalByName(string tenSach);

        Task<int> CountSach();
        void CreateSach(Sach sach);
        void UpdateSach(Sach sach);
        void DeleteSach(Sach sach);
    }
}
