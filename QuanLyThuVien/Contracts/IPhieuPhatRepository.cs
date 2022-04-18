using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPhieuPhatRepository
    {
        Task<IEnumerable<PhieuPhat>> GetAllPhieuPhatAsync(PhieuPhatParameters phieuphatParameters);
        Task<PhieuPhat> GetPhieuPhatByIdAsync(Guid id);
        Task<int> CountPhieuPhat();
        void CreatePhieuPhat(PhieuPhat phieuPhat);
        void UpdatePhieuPhat(PhieuPhat phieuPhat);
        void DeletePhieuPhat(PhieuPhat phieuPhat);
    }
}
