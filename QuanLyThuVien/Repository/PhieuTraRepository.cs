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
    public class PhieuTraRepository : RepositoryBase<PhieuTra>, IPhieuTraRepository
    {
        public PhieuTraRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountPhieuTra()
        {
            return await CountAll();
        }

        public void CreatePhieuTra(PhieuTra pt)
        {
            Create(pt);
        }

        public void DeletePhieuTra(PhieuTra pt)
        {
            Delete(pt);
        }

        public async Task<IEnumerable<PhieuTra>> GetAllPhieuTraAsync(PhieuTraParameters ptParameters)
        {
            List<PhieuTra> pts;
            pts = await FindAll().OrderByDescending(e => e.NgayTra)
                .Skip((ptParameters.PageNumber - 1) * ptParameters.PageSize)
                .Take(ptParameters.PageSize)
                .ToListAsync();
            return pts;
        }

        public async Task<PhieuTra> GetPhieuTraByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdatePhieuTra(PhieuTra pt)
        {
            Update(pt);
        }
    }
}
