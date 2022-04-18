using Entities.DTO.PhieuMatSach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPhieuMatSachRepository
    {
        Task<IEnumerable<PhieuMatSach>> GetAllPhieuMatSachAsync(PhieuMatSachParameters phieuMatSachParameters);
        Task<List<PhieuMatSachDto>> GetAllPhieuMatSachDtoAsync(PhieuMatSachParameters phieuMatSachParameters);
        Task<PhieuMatSach> GetPhieuMatSachByIdAsync(Guid id);
        Task<int> CountPhieuMatSach();
        void CreatePhieuMatSach(PhieuMatSach PhieuMatSach);
        void UpdatePhieuMatSach(PhieuMatSach PhieuMatSach);
        void DeletePhieuMatSach(PhieuMatSach PhieuMatSach);
    }
}
