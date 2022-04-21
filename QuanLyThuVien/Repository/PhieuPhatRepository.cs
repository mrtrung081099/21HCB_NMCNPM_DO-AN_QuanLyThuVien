using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PhieuPhatRepository : RepositoryBase<PhieuPhat>, IPhieuPhatRepository
    {
        public PhieuPhatRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountPhieuPhat()
        {
            return await CountAll();
        }

        public void CreatePhieuPhat(PhieuPhat phieuPhat)
        {
            Create(phieuPhat);
        }

        public void DeletePhieuPhat(PhieuPhat phieuPhat)
        {
            Delete(phieuPhat);
        }

        public async Task<IEnumerable<PhieuPhat>> GetAllPhieuPhatAsync(PhieuPhatParameters phieuphatParameters)
        {
            List<PhieuPhat> phieuPhats;
            phieuPhats = await FindAll().OrderByDescending(e => e.NgayThu)
                .Skip((phieuphatParameters.PageNumber - 1) * phieuphatParameters.PageSize)
                .Take(phieuphatParameters.PageSize)
                .ToListAsync();
            return phieuPhats;
        }

        public async Task<PhieuPhat> GetPhieuPhatByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdatePhieuPhat(PhieuPhat phieuPhat)
        {
            Update(phieuPhat);
        }
    }
}
