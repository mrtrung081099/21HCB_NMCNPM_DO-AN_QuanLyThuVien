using Entities.DTO.PhieuMuon;
using Entities.DTO.Sach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuTra
{
    public class PhieuTraForCreationDto
    {
        public Guid DocGiaId { get; set; }
        public DateTime NgayTra { get; set; }
        public float TienPhat { get; set; }
        public float TienNo { get; set; }
        public float TongNo { get; set; }
        public List<SachMuonDto> SachTras { get; set; }
    }
}
