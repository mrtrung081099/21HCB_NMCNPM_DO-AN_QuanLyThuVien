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
    public class ThanhLySachRepository : RepositoryBase<ThanhLySach>, IThanhLySachRepository
    {
        public ThanhLySachRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountThanhLySach()
        {
            return await CountAll();
        }

        public void CreateThanhLySach(ThanhLySach thanhLySach)
        {
            Create(thanhLySach);
        }

        public void DeleteThanhLySach(ThanhLySach thanhLySach)
        {
            Delete(thanhLySach);
        }

        public async Task<IEnumerable<ThanhLySach>> GetAllThanhLySachAsync(ThanhLySachParameters thanhLySachParameters)
        {
            List<ThanhLySach> listTls;
            listTls = await FindAll().OrderByDescending(e => e.NgayThanhLy)
                .Skip((thanhLySachParameters.PageNumber - 1) * thanhLySachParameters.PageSize)
                .Take(thanhLySachParameters.PageSize)
                .ToListAsync();
            return listTls;
        }

        public async Task<ThanhLySach> GetThanhLySachByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdateThanhLySach(ThanhLySach thanhLySach)
        {
            Update(thanhLySach);
        }
    }
}
