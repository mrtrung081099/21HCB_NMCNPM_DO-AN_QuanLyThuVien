using Entities.DTO.Sach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuTra
{
    public class PhieuTraDto
    {
        public Guid Id { get; set; }
        public Guid DocGiaId { get; set; }
        public DateTime NgayTra { get; set; }
        public string TenDocGia { get; set; }
        public float TienPhat { get; set; }
        public List<SachMuonDto> SachTras { get; set; }
    }
}
