using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICTThanhLySachRepository
    {
        Task<IEnumerable<ChiTietThanhLySach>> GetAllCTThanhLySachnAsync(CTThanhLySachParameters cttlsParameters);
        Task<IEnumerable<ChiTietThanhLySach>> GetAllCTThanhLySachByTlsIdAsync(Guid tlsId);
        Task<ChiTietThanhLySach> GetCTThanhLySachByIdAsync(Guid id);
        Task<int> CountCTThanhLySach();
        void CreateCTThanhLySach(ChiTietThanhLySach cttls);
        void UpdateCTThanhLySach(ChiTietThanhLySach cttls);
        void DeleteCTThanhLySach(ChiTietThanhLySach cttls);
    }
}
