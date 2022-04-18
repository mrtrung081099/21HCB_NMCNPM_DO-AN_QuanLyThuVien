using Entities.DTO.PhieuMatSach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IPhieuMatSachService
    {
        public Task<List<PhieuMatSachDto>> GetAllPhieuMatSachDtoAsync(PhieuMatSachParameters phieuMatSachParameters);
        public Task<PhieuMatSachDto> CreatePhieuMatSachAsync(PhieuMatSachForCreationDto phieuMatSach);
        public Task<PhieuMatSachDto> GetPhieuMatSachDtoByIdAsync(Guid id);
    }
}
