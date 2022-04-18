using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ThanhLySach
{
    public class ThanhLySachForCreationDto
    {
        public Guid NhanVienId { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public List<SachThanhLyForCreationDto> SachThanhLys { get; set; }
    }
}
