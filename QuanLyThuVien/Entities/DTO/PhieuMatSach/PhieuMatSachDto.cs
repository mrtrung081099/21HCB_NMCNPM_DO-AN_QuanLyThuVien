using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuMatSach
{
    public class PhieuMatSachDto
    {
        public Guid Id { get; set; }
        public Guid SachId { get; set; }
        public Guid DocGiaId { get; set; }
        public Guid NhanVienId { get; set; }
        public DateTime NgayGhiNhan { get; set; }
        public float TienPhat { get; set; }
        public string TenSach { get; set; }
        public string TenDocGia { get; set; }
        public string TenNhanVien { get; set; }
    }
}
