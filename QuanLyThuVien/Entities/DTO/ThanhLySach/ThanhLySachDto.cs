using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ThanhLySach
{
    public class ThanhLySachDto
    {
        public Guid Id { get; set; }
        public Guid NhanVienId { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public List<SachThanhLyDto> SachThanhLys { get; set; }
    }
}
