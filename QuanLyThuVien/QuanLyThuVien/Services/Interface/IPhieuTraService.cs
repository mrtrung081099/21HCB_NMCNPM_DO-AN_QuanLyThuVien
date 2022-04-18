using Entities.DTO.PhieuTra;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IPhieuTraService
    {
        public Task<IEnumerable<PhieuTraDto>> GetAllPhieuTraDtoAsync(PhieuTraParameters phieuTraParameters);
        public Task<PhieuTraDto> CreatePhieuTraAsync(PhieuTraForCreationDto pt);
        public Task<PhieuTraDto> GetPhieuTraDtoByIdAsync(Guid id);
    }
}
