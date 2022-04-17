using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPhieuTraRepository
    {
        Task<IEnumerable<PhieuTra>> GetAllPhieuTraAsync(PhieuTraParameters ptParameters);
        Task<PhieuTra> GetPhieuTraByIdAsync(Guid id);
        Task<int> CountPhieuTra();
        void CreatePhieuTra(PhieuTra pt);
        void UpdatePhieuTra(PhieuTra pt);
        void DeletePhieuTra(PhieuTra pt);
    }
}
