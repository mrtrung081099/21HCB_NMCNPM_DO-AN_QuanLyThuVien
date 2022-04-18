using AutoMapper;
using Contracts;
using Entities.DTO.ThanhLySach;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class ThanhLySachService : IThanhLySachService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ICTThanhLySachService _cttlsService;
        private readonly ISachService _sachService;
        public ThanhLySachService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, ICTThanhLySachService cttlsService, ISachService sachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _cttlsService = cttlsService;
            _sachService = sachService;
        }
        public async Task<ThanhLySachDto> CreateThanhLySachAsync(ThanhLySachForCreationDto thanhLySachForCreation)
        {
            var thanhLySach = _mapper.Map<ThanhLySach>(thanhLySachForCreation);
            _repository.ThanhLySach.CreateThanhLySach(thanhLySach);
            await _repository.SaveAsync();
            foreach(var sach in thanhLySachForCreation.SachThanhLys)
            {
                await _cttlsService.CreateCTThanhLySachAsync(sach, thanhLySach.Id);
                await _sachService.UpdateStateSachAsync(sach.SachId, "Đã Thanh Lý");
            }
            return await GetThanhLySachDtoByIdAsync(thanhLySach.Id);
        }

        public async Task<IEnumerable<ThanhLySachDto>> GetAllThanhLySachDtoAsync(ThanhLySachParameters thanhLySachParameters)
        {
            var listTls = await _repository.ThanhLySach.GetAllThanhLySachAsync(thanhLySachParameters);
            var listPmDto = _mapper.Map<List<ThanhLySachDto>>(listTls);
            foreach(var item in listPmDto) {
                var nv = await _repository.NhanVien.GetNhanVienByIdAsync(item.NhanVienId);
                var sachthanhlys = await _repository.Sach.GetAllSachThanhLyByTlsIdAsync(item.Id);
                item.TenNhanVien = nv.HoTen;
                item.SachThanhLys = sachthanhlys;
            }
            return listPmDto;
        }

        public async Task<int> GetCountThanhLySach()
        {
            return await _repository.ThanhLySach.CountThanhLySach();
        }

        public async Task<ThanhLySachDto> GetThanhLySachDtoByIdAsync(Guid id)
        {
            var tls = await _repository.ThanhLySach.GetThanhLySachByIdAsync(id);
            var sachthanhlys = await _repository.Sach.GetAllSachThanhLyByTlsIdAsync(tls.Id);
            var nv = await _repository.NhanVien.GetNhanVienByIdAsync(tls.NhanVienId);
            var tlsDto = _mapper.Map<ThanhLySachDto>(tls);
            tlsDto.TenNhanVien = nv.HoTen;
            tlsDto.SachThanhLys = sachthanhlys;
            return tlsDto;
        }
    }
}
