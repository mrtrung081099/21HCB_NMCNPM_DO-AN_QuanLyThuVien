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
    public class SachRepository : RepositoryBase<Sach>, ISachRepository
    {
        public SachRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
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
            sachs = await FindByCondition(x => !x.TinhTrang.Contains("Đã Thanh Lý"))
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
    }
}
