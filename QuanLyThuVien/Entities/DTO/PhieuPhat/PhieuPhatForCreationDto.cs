using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuPhat
{
    public class PhieuPhatForCreationDto
    {
        public Guid DocGiaId { get; set; }
        public Guid NhanVienId { get; set; }
        public float TienNo { get; set; }
        public float TienThu { get; set; }
        public float TienNoConlai { get; set; }
    }
}
