using Entities.DTO.ThanhLySach;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IThanhLySachService
    {
        public Task<ThanhLySachDto> CreateThanhLySachAsync(ThanhLySachForCreationDto thanhLySachForCreation);
        public Task<ThanhLySachDto> GetThanhLySachDtoByIdAsync(Guid id);
        public Task<IEnumerable<ThanhLySachDto>> GetAllThanhLySachDtoAsync(ThanhLySachParameters thanhLySachParameters);
        public Task<int> GetCountThanhLySach();
    }
}
