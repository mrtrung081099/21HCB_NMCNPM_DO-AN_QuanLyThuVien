using Contracts;
using Entities;
using Entities.DTO.PhieuMatSach;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PhieuMatSachRepository : RepositoryBase<PhieuMatSach>, IPhieuMatSachRepository
    {
        public readonly RepositoryContext _repositoryContext;
        public PhieuMatSachRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<int> CountPhieuMatSach()
        {
            return await CountAll();
        }

        public void CreatePhieuMatSach(PhieuMatSach PhieuMatSach)
        {
            Create(PhieuMatSach);
        }

        public void DeletePhieuMatSach(PhieuMatSach PhieuMatSach)
        {
            Delete(PhieuMatSach);
        }

        public async Task<IEnumerable<PhieuMatSach>> GetAllPhieuMatSachAsync(PhieuMatSachParameters phieuMatSachParameters)
        {
            List<PhieuMatSach> phieuMatSaches;
            phieuMatSaches = await FindAll().OrderBy(e => e.NgayGhiNhan)
                .Skip((phieuMatSachParameters.PageNumber - 1) * phieuMatSachParameters.PageSize)
                .Take(phieuMatSachParameters.PageSize)
                .ToListAsync();
            return phieuMatSaches;
        }

        public Task<List<PhieuMatSachDto>> GetAllPhieuMatSachDtoAsync(PhieuMatSachParameters phieuMatSachParameters)
        {
            var query = from pms in _repositoryContext.PhieuMatSachs
                        join s in _repositoryContext.Sachs on pms.SachId equals s.Id
                        join dg in _repositoryContext.DocGias on pms.DocGiaId equals dg.Id
                        join nv in _repositoryContext.NhanViens on pms.NhanVienId equals nv.Id
                        select new PhieuMatSachDto
                        {
                            Id = pms.Id,
                            SachId = pms.SachId,
                            DocGiaId = pms.DocGiaId,
                            NhanVienId = pms.NhanVienId,
                            NgayGhiNhan = pms.NgayGhiNhan,
                            TienPhat = pms.TienPhat,
                            TenSach = s.Ten,
                            TenDocGia = dg.HoTen,
                            TenNhanVien = nv.HoTen
                        };
            var result = query.OrderBy(e => e.NgayGhiNhan)
                .Skip((phieuMatSachParameters.PageNumber - 1) * phieuMatSachParameters.PageSize)
                .Take(phieuMatSachParameters.PageSize)
                .ToListAsync();
            return result;
        }

        public async Task<PhieuMatSach> GetPhieuMatSachByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdatePhieuMatSach(PhieuMatSach PhieuMatSach)
        {
            Update(PhieuMatSach);
        }
    }
}
