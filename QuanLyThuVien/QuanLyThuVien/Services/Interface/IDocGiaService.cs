using Entities.DTO.DocGia;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IDocGiaService
    {

        public Task<IEnumerable<DocGiaDto>> GetAllDocGiaAsync(DocGiaParameters docgiaParameters);
        public Task<DocGiaDto> GetDocGiaByIdAsync(DocGia dg);
        public Task<DocGiaDto> CreateDocGiaAsync(DocGiaForCreationUpdateDto docgia);
        public Task UpdateTongNoDocGia(Guid dgId, float tienPhat);
        public Task UpdateTongNoDocGiaMatSach(Guid dgId, float tienPhat);
        public void DeleteDocGiaAsync(DocGia dg);
        public Task<DocGiaDto> UpdateDocGiaAsync(DocGia dg);
        public Task<int> GetCountDocGia();
    }
}
