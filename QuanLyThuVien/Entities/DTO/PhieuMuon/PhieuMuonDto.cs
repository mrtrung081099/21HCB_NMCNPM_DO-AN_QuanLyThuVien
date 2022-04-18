using Entities.DTO.Sach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuMuon
{
    public class PhieuMuonDto
    {
        public Guid Id { get; set; }
        public Guid DocGiaId { get; set; }
        public DateTime NgayMuon { get; set; }
        public string TenDocGia { get; set; }
        public List<SachDto> SachMuons { get; set; }
    }
}
