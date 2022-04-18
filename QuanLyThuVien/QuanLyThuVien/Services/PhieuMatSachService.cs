using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMatSach;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class PhieuMatSachService: IPhieuMatSachService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDocGiaService _docGiaService;
        private readonly ISachService _sachService;
        public PhieuMatSachService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IDocGiaService docGiaService, ISachService sachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _docGiaService = docGiaService;
            _sachService = sachService;
        }

        public async Task<List<PhieuMatSachDto>> GetAllPhieuMatSachDtoAsync(PhieuMatSachParameters phieuMatSachParameters)
        {
            return await _repository.PhieuMatSach.GetAllPhieuMatSachDtoAsync(phieuMatSachParameters);
        }

        public async Task<PhieuMatSachDto> CreatePhieuMatSachAsync(PhieuMatSachForCreationDto phieuMatSach)
        {
            var phieumatsach = _mapper.Map<PhieuMatSach>(phieuMatSach);
            _repository.PhieuMatSach.CreatePhieuMatSach(phieumatsach);
            await _repository.SaveAsync();
            await _docGiaService.UpdateTongNoDocGia(phieumatsach.DocGiaId, phieumatsach.TienPhat);
            await _sachService.UpdateStateSachAsync(phieumatsach.SachId, "Đã Mất");
            return await GetPhieuMatSachDtoByIdAsync(phieumatsach.Id);
        }

        public async Task<PhieuMatSachDto> GetPhieuMatSachDtoByIdAsync(Guid id)
        {
            var phieumatsach = await _repository.PhieuMatSach.GetPhieuMatSachByIdAsync(id);
            var phieumatsachDto = _mapper.Map<PhieuMatSachDto>(phieumatsach);
            var sach = await _repository.Sach.GetSachByIdAsync(phieumatsachDto.SachId);
            var nv = await _repository.NhanVien.GetNhanVienByIdAsync(phieumatsachDto.NhanVienId);
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(phieumatsachDto.DocGiaId);
            phieumatsachDto.TenSach = sach.Ten;
            phieumatsachDto.TenDocGia = dg.HoTen;
            phieumatsachDto.TenNhanVien = nv.HoTen;
            return phieumatsachDto;
        }
    }
}
