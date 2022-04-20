using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PhieuPhat
    {
        [Column("PhieuPhatId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(DocGia))]
        public Guid DocGiaId { get; set; }
        [ForeignKey(nameof(NhanVien))]
        public Guid NhanVienId { get; set; }
        public float TienNo { get; set; }
        public float TienThu { get; set; }
        public float TienNoConlai { get; set; }
        public DateTime NgayThu { get; set; }
        public DocGia DocGia { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
