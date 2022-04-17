using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IDocGiaRepository DocGia { get; }
        INhanVienRepository NhanVien { get; }
        IAuthRepository User { get; }
        ISachRepository Sach { get; }
        IPhieuMuonRepository PhieuMuon { get; }
        ICTPhieuMuonRepository CTPhieuMuon { get; }
        IPhieuTraRepository PhieuTra { get; }
        ICTPhieuTraRepository CTPhieuTra { get; }

        Task SaveAsync();

    }
}
