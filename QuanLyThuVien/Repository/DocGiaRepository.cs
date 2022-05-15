using AutoMapper;
using Contracts;
using Entities;
using Entities.DTO.DocGia;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DocGiaRepository : RepositoryBase<DocGia>, IDocGiaRepository
    {
        protected RepositoryContext _repositoryContext;

        public DocGiaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }

        public void CreateDocGia(DocGia docgia)
        {
            Create(docgia);
        }

        public void DeleteDocGia(DocGia docgia)
        {
            Delete(docgia);
        }
        public void UpdateDocGia(DocGia docgia)
        {
            Update(docgia);
        }

        public async Task<IEnumerable<DocGia>> GetAllDocGiaAsync(DocGiaParameters nhanvienParameters)
        {
            List<DocGia> docgias;
            if (nhanvienParameters.Search == null || nhanvienParameters.Search == "null")
            {
                docgias = await FindAll().OrderByDescending(e => e.NgayLap)
                .Skip((nhanvienParameters.PageNumber - 1) * nhanvienParameters.PageSize)
                .Take(nhanvienParameters.PageSize)
                .ToListAsync();
            }
            else
            {
                docgias = await FindByCondition(x => x.HoTen.Contains(nhanvienParameters.Search)).OrderByDescending(e => e.NgayLap)
                .Skip((nhanvienParameters.PageNumber - 1) * nhanvienParameters.PageSize)
                .Take(nhanvienParameters.PageSize)
                .ToListAsync();
            }
            return docgias;
        }

        public async Task<DocGia> GetDocGiaByIdAsync(Guid id)
        {
            var dg = await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
            return dg;
        }

        public async Task<int> CountDocGia()
        {
            return await CountAll();
        }

        public async Task<bool> CheckDeadlineMuonSachDocGia(Guid id)
        {
            var result = from dg in _repositoryContext.DocGias
                         join pt in _repositoryContext.PhieuTras
                         on dg.Id equals pt.DocGiaId
                         where dg.Id == id
                         select new {pt};
            var list = await result.ToListAsync();
            float tienPhat = list.Sum(x => x.pt.TienPhat);
            if (tienPhat > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<List<ThongKeDocGiaNoTien>> ThongKeDocGiaNoTien(DateTime ngay)
        {
            var query = from dg in _repositoryContext.DocGias
                        join pt in _repositoryContext.PhieuTras on dg.Id equals pt.DocGiaId
                        where pt.NgayTra.Date == ngay.Date && pt.TienPhat > 0
                        select new ThongKeDocGiaNoTien
                        {
                            TenDocGia = dg.HoTen,
                            TienNo = pt.TienPhat
                        };
            var query2 = from dg in _repositoryContext.DocGias
                        join pms in _repositoryContext.PhieuMatSachs on dg.Id equals pms.DocGiaId
                        where pms.NgayGhiNhan.Date == ngay.Date
                        select new ThongKeDocGiaNoTien
                        {
                            TenDocGia = dg.HoTen,
                            TienNo = pms.TienPhat
                        };
            var list1 = await query.ToListAsync();
            var list2 = await query2.ToListAsync();
            var list3 = list1.Concat(list2).ToList();
            var listResult = new List<ThongKeDocGiaNoTien>();

            foreach (var i in list3)
            {
                var check = false;
                foreach (var j in listResult)
                {
                    if (i.TenDocGia == j.TenDocGia)
                    {
                        check = true;
                        j.TienNo = j.TienNo + i.TienNo;
                    }
                }
                if (!check)
                {
                    listResult.Add(i);
                }
            }

            return listResult;
        }
    }
}
