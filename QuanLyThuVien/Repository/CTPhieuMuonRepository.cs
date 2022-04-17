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
    public class CTPhieuMuonRepository : RepositoryBase<ChiTietPhieuMuon>, ICTPhieuMuonRepository
    {
        public CTPhieuMuonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountCTPhieuMuon()
        {
            return await CountAll();
        }

        public void CreateCTPhieuMuon(ChiTietPhieuMuon ctpm)
        {
            Create(ctpm);
        }

        public void DeleteCTPhieuMuon(ChiTietPhieuMuon ctpm)
        {
            Delete(ctpm);
        }

        public async Task<IEnumerable<ChiTietPhieuMuon>> GetAllCTPhieuMuonAsync(CTPhieuMuonParameters ctpmParameters)
        {
            List<ChiTietPhieuMuon> ctpms;
            ctpms = await FindAll()
                .Skip((ctpmParameters.PageNumber - 1) * ctpmParameters.PageSize)
                .Take(ctpmParameters.PageSize)
                .ToListAsync();
            return ctpms;
        }

        public async Task<IEnumerable<ChiTietPhieuMuon>> GetAllCTPhieuMuonByIdPmAsync(Guid pmId)
        {
            List<ChiTietPhieuMuon> ctpms;
            ctpms = await FindByCondition(x => x.PhieuMuonId == pmId)
                .ToListAsync();
            return ctpms;
        }

        public async Task<ChiTietPhieuMuon> GetCTPhieuMuonByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<ChiTietPhieuMuon> GetCTPhieuMuonBySachIdAsync(Guid sachId)
        {
            return await FindByCondition(x => x.SachId == sachId && x.TinhTrang == "Chưa Trả").SingleOrDefaultAsync();
        }

        public void UpdateCTPhieuMuon(ChiTietPhieuMuon ctpm)
        {
            Update(ctpm);
        }
    }
}
