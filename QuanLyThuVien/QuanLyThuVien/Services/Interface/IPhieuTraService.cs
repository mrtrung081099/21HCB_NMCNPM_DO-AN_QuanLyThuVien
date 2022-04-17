using Entities.DTO.PhieuTra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IPhieuTraService
    {
        public Task<PhieuTraDto> CreatePhieuTraAsync(PhieuTraForCreationDto pt);
        public Task<PhieuTraDto> GetPhieuTraDtoByIdAsync(Guid id);
    }
}
