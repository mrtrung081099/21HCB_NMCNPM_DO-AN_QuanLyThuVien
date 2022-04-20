using Contracts;
using Entities;
using Entities.DTO.Sach;
using Entities.DTO.ThanhLySach;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SachRepository : RepositoryBase<Sach>, ISachRepository
    {
        protected RepositoryContext _repositoryContext;
        public SachRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<int> CountSach()
        {
            return await CountAll();
        }

        public void CreateSach(Sach sach)
        {
            Create(sach);
        }

        public void DeleteSach(Sach sach)
        {
            Delete(sach);
        }

        public async Task<IEnumerable<Sach>> GetAllSachAsync(SachParameters sachParameters)
        {
            List<Sach> sachs;
            sachs = await FindByCondition(x => !x.TinhTrang.Contains("Đã Thanh Lý") && !x.TinhTrang.Contains("Đã Mất"))
                                        .OrderBy(e => e.TinhTrang)
                                        .Skip((sachParameters.PageNumber - 1) * sachParameters.PageSize)
                                        .Take(sachParameters.PageSize)
                                        .ToListAsync();
            return sachs;
        }

        public async Task<Sach> GetSachByIdAsync(Guid id)
        {
            var sach = await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
            return sach;
        }

        public void UpdateSach(Sach sach)
        {
            Update(sach);
        }

        public async Task<int> CountTotalByState(string trinhTrang)
        {
            var total = await FindByCondition(x => x.TinhTrang.Contains(trinhTrang)).ToListAsync();
            return total.Count();
        }
        public async Task<int> Count()
        {
            var total = await FindByCondition(x => !x.TinhTrang.Contains("Đã Thanh Lý") && !x.TinhTrang.Contains("Đã Mất")).ToListAsync();
            return total.Count();
        }

        public async Task<IEnumerable<Sach>> GetAllSachByStateAsync(SachParameters sachParameters)
        {
            List<Sach> sachs;
            sachs = await FindByCondition(x => x.TinhTrang.Contains(sachParameters.Search))
                                        .Skip((sachParameters.PageNumber - 1) * sachParameters.PageSize)
                                        .Take(sachParameters.PageSize)
                                        .ToListAsync();
            return sachs;
        }

        public async Task<IEnumerable<Sach>> GetAllSachByNameAsync(SachParameters sachParameters)
        {
            List<Sach> sachs;
            sachs = await FindByCondition(x => x.Ten.Contains(sachParameters.Search))
                                        .Skip((sachParameters.PageNumber - 1) * sachParameters.PageSize)
                                        .Take(sachParameters.PageSize)
                                        .ToListAsync();
            return sachs;
        }

        public async Task<int> CountTotalByName(string tenSach)
        {
            var total = await FindByCondition(x => x.Ten.Contains(tenSach)).ToListAsync();
            return total.Count();
        }

        public Task<List<SachMuonDto>> GetAllSachMuonByDocGiaIdAsync(Guid docgiaId)
        {
            var query = from s in _repositoryContext.Sachs
                        join ctpm in _repositoryContext.ChiTietPhieuMuons on s.Id equals ctpm.SachId
                        join pt in _repositoryContext.PhieuMuons on ctpm.PhieuMuonId equals pt.Id
                        where pt.DocGiaId == docgiaId && ctpm.TinhTrang == "Chưa Trả"
                        orderby pt.NgayMuon 
                        select new SachMuonDto
                        {
                            Id = s.Id,
                            Ten = s.Ten,
                            NgayMuon = pt.NgayMuon
                        };
            var sachs = query.ToListAsync();
            return sachs;
        }

        public Task<List<SachMuonDto>> GetAllSachMuonByPhieuTraIdAsync(Guid ptId)
        {
            var query = from s in _repositoryContext.Sachs
                        join ctpt in _repositoryContext.ChiTietPhieuTras on s.Id equals ctpt.SachId
                        where ctpt.PhieuTraId == ptId
                        select new SachMuonDto
                        {
                            Id = s.Id,
                            Ten = s.Ten,
                            NgayMuon = ctpt.NgayMuon,
                            SoNgayMuon = ctpt.SoNgayMuon,
                            TienPhat = ctpt.TienPhat
                        };
            var sachs = query.ToListAsync();
            return sachs;
        }

        public Task<List<SachThanhLyDto>> GetAllSachThanhLyByTlsIdAsync(Guid tlsId)
        {
            var query = from s in _repositoryContext.Sachs
                        join cttls in _repositoryContext.ChiTietThanhLySachs on s.Id equals cttls.SachId
                        where cttls.ThanhLySachId == tlsId
                        select new SachThanhLyDto
                        {
                            SachId = s.Id,
                            TenSach = s.Ten,
                            LyDoThanhLy = cttls.LyDoThanhLy
                        };
            var sachs = query.ToListAsync();
            return sachs;
        }
    }
}
