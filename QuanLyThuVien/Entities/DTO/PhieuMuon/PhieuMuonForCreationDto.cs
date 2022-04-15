using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PhieuMuon
{
    public class PhieuMuonForCreationDto
    {
        public Guid DocGiaId { get; set; }
        public DateTime NgayMuon { get; set; }
        public List<SachMuonForCreationDto> SachMuons { get; set; }
    }
}
