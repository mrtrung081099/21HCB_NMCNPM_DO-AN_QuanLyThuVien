using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ThanhLySach
{
    public class CTThanhLySachForCreationDto
    {
        public Guid SachId { get; set; }
        public Guid ThanhLySachId { get; set; }
        public string LyDoThanhLy { get; set; }
    }
}
