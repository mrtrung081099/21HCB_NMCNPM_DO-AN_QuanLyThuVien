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
    public class CTPhieuTraRepository : RepositoryBase<ChiTietPhieuTra>, ICTPhieuTraRepository
    {
        public CTPhieuTraRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountCTPhieuTra()
        {
            return await CountAll();
        }

        public void CreateCTPhieuTra(ChiTietPhieuTra ctpt)
        {
            Create(ctpt);
        }

        public void DeleteCTPhieuTra(ChiTietPhieuTra ctpt)
        {
            Delete(ctpt);
        }

        public async Task<IEnumerable<ChiTietPhieuTra>> GetAllCTPhieuTraAsync(CTPhieuTraParameters ctptParameters)
        {
            List<ChiTietPhieuTra> ctpts;
            ctpts = await FindAll()
                .Skip((ctptParameters.PageNumber - 1) * ctptParameters.PageSize)
                .Take(ctptParameters.PageSize)
                .ToListAsync();
            return ctpts;
        }

        public async Task<IEnumerable<ChiTietPhieuTra>> GetAllCTPhieuTraByIdPtAsync(Guid PtId)
        {
            List<ChiTietPhieuTra> ctpts;
            ctpts = await FindByCondition(x => x.PhieuTraId == PtId)
                .ToListAsync();
            return ctpts;
        }

        public async Task<ChiTietPhieuTra> GetCTPhieuTraByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdateCTPhieuTra(ChiTietPhieuTra ctpt)
        {
            Update(ctpt);
        }
    }
}
