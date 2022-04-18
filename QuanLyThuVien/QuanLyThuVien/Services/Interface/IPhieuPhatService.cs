using Entities.DTO.PhieuPhat;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IPhieuPhatService
    {
        public Task<IEnumerable<PhieuPhatDto>> GetAllPhieuPhatDtoAsync(PhieuPhatParameters phieuPhatParameters);
        public Task<PhieuPhatDto> CreatePhieuTraAsync(PhieuPhatForCreationDto phieuPhat);
        public Task<PhieuPhatDto> GetPhieuTraDtoByIdAsync(Guid id);
    }
}
