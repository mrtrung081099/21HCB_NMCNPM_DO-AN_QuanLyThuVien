using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Sach
{
    public class SachForCreationDto
    {
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string TacGia { get; set; }
        public string NamSx { get; set; }
        public string NhaSx { get; set; }
        public string TinhTrang { get; set; }
        public float Gia { get; set; }
        public DateTime NgayTiepNhan { get; set; }

        public Guid NhanVienId { get; set; }
    }
}
