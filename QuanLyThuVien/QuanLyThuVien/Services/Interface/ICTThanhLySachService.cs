using Entities.DTO.ThanhLySach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface ICTThanhLySachService
    {
        public Task CreateCTThanhLySachAsync(SachThanhLyForCreationDto sachThanhLy, Guid tlsId);
    }
}
