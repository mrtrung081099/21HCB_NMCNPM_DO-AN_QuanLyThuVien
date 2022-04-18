using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ChiTietThanhLySach
    {
        [Column("ChiTietThanhLySachId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Sach))]
        public Guid SachId { get; set; }
        [ForeignKey(nameof(ThanhLySach))]
        public Guid ThanhLySachId { get; set; }
        public string LyDoThanhLy { get; set; }
        public Sach Sach { get; set; }
        public ThanhLySach ThanhLySach { get; set; }
    }
}
