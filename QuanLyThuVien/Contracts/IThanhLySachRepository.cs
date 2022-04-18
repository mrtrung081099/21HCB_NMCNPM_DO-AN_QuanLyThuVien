using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IThanhLySachRepository
    {
        Task<IEnumerable<ThanhLySach>> GetAllThanhLySachAsync(ThanhLySachParameters thanhLySachParameters);
        Task<ThanhLySach> GetThanhLySachByIdAsync(Guid id);
        Task<int> CountThanhLySach();
        void CreateThanhLySach(ThanhLySach thanhLySach);
        void UpdateThanhLySach(ThanhLySach thanhLySach);
        void DeleteThanhLySach(ThanhLySach thanhLySach);
    }
}
