using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICTPhieuTraRepository
    {
        Task<IEnumerable<ChiTietPhieuTra>> GetAllCTPhieuTraAsync(CTPhieuTraParameters ctptParameters);
        Task<IEnumerable<ChiTietPhieuTra>> GetAllCTPhieuTraByIdPtAsync(Guid PtId);
        Task<ChiTietPhieuTra> GetCTPhieuTraByIdAsync(Guid id);
        void CreateCTPhieuTra(ChiTietPhieuTra ctpt);
        void UpdateCTPhieuTra(ChiTietPhieuTra ctpt);
        void DeleteCTPhieuTra(ChiTietPhieuTra ctpt);
        Task<int> CountCTPhieuTra();
    }
}
