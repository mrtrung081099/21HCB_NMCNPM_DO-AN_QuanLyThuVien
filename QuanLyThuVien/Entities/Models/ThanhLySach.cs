using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ThanhLySach
    {
        [Column("ThanhLySachId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(NhanVien))]
        public Guid NhanVienId { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
