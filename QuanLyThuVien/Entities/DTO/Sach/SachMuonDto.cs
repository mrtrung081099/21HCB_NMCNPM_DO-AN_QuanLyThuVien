using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Sach
{
    public class SachMuonDto
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public DateTime NgayMuon { get; set; }
        public int SoNgayMuon { get; set; }
        public float TienPhat { get; set; }
    }
}
