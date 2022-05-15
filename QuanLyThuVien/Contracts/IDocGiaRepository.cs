using Entities.DTO.DocGia;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDocGiaRepository
    {
        Task<IEnumerable<DocGia>> GetAllDocGiaAsync(DocGiaParameters nhanvienParameters);
        Task<DocGia> GetDocGiaByIdAsync(Guid id);
        Task<List<ThongKeDocGiaNoTien>> ThongKeDocGiaNoTien(DateTime ngay);
        Task<bool> CheckDeadlineMuonSachDocGia(Guid id);
        void CreateDocGia(DocGia docgia);
        void UpdateDocGia(DocGia docgia);
        void DeleteDocGia(DocGia docgia);
        Task<int> CountDocGia();

    }
}
