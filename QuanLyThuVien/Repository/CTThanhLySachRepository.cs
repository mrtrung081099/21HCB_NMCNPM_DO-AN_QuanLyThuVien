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
    public class CTThanhLySachRepository : RepositoryBase<ChiTietThanhLySach>, ICTThanhLySachRepository
    {
        public CTThanhLySachRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<int> CountCTThanhLySach()
        {
            return await CountAll();
        }

        public void CreateCTThanhLySach(ChiTietThanhLySach cttls)
        {
            Create(cttls);
        }

        public void DeleteCTThanhLySach(ChiTietThanhLySach cttls)
        {
            Delete(cttls);
        }

        public async Task<IEnumerable<ChiTietThanhLySach>> GetAllCTThanhLySachByTlsIdAsync(Guid tlsId)
        {
            List<ChiTietThanhLySach> listCttls;
            listCttls = await FindByCondition(x => x.ThanhLySachId == tlsId)
                .ToListAsync();
            return listCttls;
        }

        public async Task<IEnumerable<ChiTietThanhLySach>> GetAllCTThanhLySachnAsync(CTThanhLySachParameters cttlsParameters)
        {
            List<ChiTietThanhLySach> listCttls;
            listCttls = await FindAll()
                .Skip((cttlsParameters.PageNumber - 1) * cttlsParameters.PageSize)
                .Take(cttlsParameters.PageSize)
                .ToListAsync();
            return listCttls;
        }

        public async Task<ChiTietThanhLySach> GetCTThanhLySachByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdateCTThanhLySach(ChiTietThanhLySach cttls)
        {
            Update(cttls);
        }
    }
}
