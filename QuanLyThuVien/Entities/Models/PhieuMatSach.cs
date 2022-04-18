using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PhieuMatSach
    {
        [Column("PhieuMatSachId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Sach))]
        public Guid SachId { get; set; }
        [ForeignKey(nameof(DocGia))]
        public Guid DocGiaId { get; set; }
        [ForeignKey(nameof(NhanVien))]
        public Guid NhanVienId { get; set; }
        public DateTime NgayGhiNhan { get; set; }
        public float TienPhat { get; set; }
        public DocGia DocGia { get; set; }
        public NhanVien NhanVien { get; set; }
        public Sach Sach { get; set; }
    }
}
