using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PhieuTra
    {
        [Column("PhieuTraId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(DocGia))]
        public Guid DocGiaId { get; set; }
        public DateTime NgayTra { get; set; }
        public float TienPhat { get; set; }
        public DocGia DocGia { get; set; }
    }
}
