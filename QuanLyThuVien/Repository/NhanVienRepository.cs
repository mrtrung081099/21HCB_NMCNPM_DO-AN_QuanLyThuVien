using Contracts;
using Entities;
using Entities.DTO.NhanVien;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NhanVienRepository : RepositoryBase<NhanVien>, INhanVienRepository
    {
        public NhanVienRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateNhanVien(NhanVien nhanvien)
        {
            Create(nhanvien);
        }

        public void DeleteNhanVien(NhanVien nhanvien)
        {
            Delete(nhanvien);

        }
        public void UpdateNhanVien(NhanVien nhanvien)
        {
            Update(nhanvien);
        }

        public async Task<IEnumerable<NhanVien>> GetAllNhanVienAsync(NhanVienParameters nhanvienParameters)
        {
            List<NhanVien> nhanviens;
            if (nhanvienParameters.Search == null || nhanvienParameters.Search == "null")
            {
                nhanviens = await FindAll().OrderBy(e => e.BoPhan)
                .Skip((nhanvienParameters.PageNumber - 1) * nhanvienParameters.PageSize)
                .Take(nhanvienParameters.PageSize)
                .ToListAsync();
            }
            else
            {
                nhanviens = await FindByCondition(x => x.HoTen.Contains(nhanvienParameters.Search)).OrderBy(e => e.BoPhan)
                .Skip((nhanvienParameters.PageNumber - 1) * nhanvienParameters.PageSize)
                .Take(nhanvienParameters.PageSize)
                .ToListAsync();
            }
            return nhanviens;
        }

        public async Task<NhanVien> GetNhanVienByIdAsync(Guid id)
        {
            var nv = await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
            return nv;
        }

        public async Task<int> CountNhanVien()
        {
            var total = await CountAll();
            return total;
        }
    }
}
