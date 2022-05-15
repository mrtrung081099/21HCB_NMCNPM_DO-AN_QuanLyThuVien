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
    public class PhieuMuonRepository : RepositoryBase<PhieuMuon>, IPhieuMuonRepository
    {
        public PhieuMuonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountPhieuMuon()
        {
            return await CountAll();
        }

        public void CreatePhieuMuon(PhieuMuon pm)
        {
            Create(pm);
        }

        public void DeletePhieuMuon(PhieuMuon pm)
        {
            Delete(pm);
        }

        public async Task<IEnumerable<PhieuMuon>> GetAllPhieuMuonAsync(PhieuMuonParameters pmParameters)
        {
            List<PhieuMuon> pms;
            pms = await FindAll().OrderByDescending(e => e.NgayMuon)
                .Skip((pmParameters.PageNumber - 1) * pmParameters.PageSize)
                .Take(pmParameters.PageSize)
                .ToListAsync(); 
            return pms;
        }

        public async Task<PhieuMuon> GetPhieuMuonByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdatePhieuMuon(PhieuMuon pm)
        {
            Update(pm);
        }
    }
}
