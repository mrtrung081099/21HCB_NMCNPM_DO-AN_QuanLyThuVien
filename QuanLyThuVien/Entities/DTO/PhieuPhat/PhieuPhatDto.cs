using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuPhat
{
    public class PhieuPhatDto
    {
        public Guid Id { get; set; }
        public Guid DocGiaId { get; set; }
        public Guid NhanVienId { get; set; }
        public float TienNo { get; set; }
        public float TienThu { get; set; }
        public float TienNoConlai { get; set; }
        public DateTime NgayThu { get; set; }
        public string TenDocGia { get; set; }
        public string TenNhanVien { get; set; }
    }
}
