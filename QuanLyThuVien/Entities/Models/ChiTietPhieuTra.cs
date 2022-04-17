using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ChiTietPhieuTra
    {
        [Column("ChiTietPhieuTraId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(PhieuTra))]
        public Guid PhieuTraId { get; set; }
        [ForeignKey(nameof(Sach))]
        public Guid SachId { get; set; }
        public DateTime NgayMuon { get; set; }
        public int SoNgayMuon { get; set; }
        public float TienPhat { get; set; }
        public PhieuTra PhieuTra { get; set; }
        public Sach Sach { get; set; }
    }
}
