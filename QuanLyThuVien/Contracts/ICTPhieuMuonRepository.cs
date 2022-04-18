using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICTPhieuMuonRepository
    {
        Task<IEnumerable<ChiTietPhieuMuon>> GetAllCTPhieuMuonAsync(CTPhieuMuonParameters ctpmParameters);
        Task<IEnumerable<ChiTietPhieuMuon>> GetAllCTPhieuMuonByIdPmAsync(Guid pmId);
        Task<ChiTietPhieuMuon> GetCTPhieuMuonByIdAsync(Guid id);
        Task<ChiTietPhieuMuon> GetCTPhieuMuonBySachIdAsync(Guid sachId);
        Task<int> CountCTPhieuMuon();
        void CreateCTPhieuMuon(ChiTietPhieuMuon ctpm);
        void UpdateCTPhieuMuon(ChiTietPhieuMuon ctpm);
        void DeleteCTPhieuMuon(ChiTietPhieuMuon ctpm);
    }
}
