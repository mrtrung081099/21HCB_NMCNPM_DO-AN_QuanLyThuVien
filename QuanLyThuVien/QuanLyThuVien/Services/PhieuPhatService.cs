using AutoMapper;
using Contracts;
using Entities.DTO.PhieuPhat;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class PhieuPhatService: IPhieuPhatService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDocGiaService _docGiaService;
        public PhieuPhatService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IDocGiaService docGiaService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _docGiaService = docGiaService;
        }

        public async Task<PhieuPhatDto> CreatePhieuTraAsync(PhieuPhatForCreationDto phieuPhat)
        {
            var phieuphat = _mapper.Map<PhieuPhat>(phieuPhat);
            phieuphat.NgayThu = DateTime.Now;
            _repository.PhieuPhat.CreatePhieuPhat(phieuphat);   
            await _repository.SaveAsync();
            await _docGiaService.UpdateTongNoDocGia(phieuphat.DocGiaId, phieuphat.TienNoConlai);
            return await GetPhieuTraDtoByIdAsync(phieuphat.Id);
        }

        public async Task<PhieuPhatDto> GetPhieuTraDtoByIdAsync(Guid id)
        {
            var phieuphat = await _repository.PhieuPhat.GetPhieuPhatByIdAsync(id);
            var phieuphatDto = _mapper.Map<PhieuPhatDto>(phieuphat);
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(phieuphatDto.DocGiaId);
            var nv = await _repository.NhanVien.GetNhanVienByIdAsync(phieuphatDto.NhanVienId);
            phieuphatDto.TenDocGia = dg.HoTen;
            phieuphatDto.TenNhanVien = nv.HoTen;
            return phieuphatDto;
        }

        public async Task<IEnumerable<PhieuPhatDto>> GetAllPhieuPhatDtoAsync(PhieuPhatParameters phieuPhatParameters)
        {
            var pps = new List<PhieuPhatDto>();
            var listPp = await _repository.PhieuPhat.GetAllPhieuPhatAsync(phieuPhatParameters);
            var listPpDto = _mapper.Map(listPp, pps);
            foreach (var pp in listPpDto)
            {
                var dg = await _repository.DocGia.GetDocGiaByIdAsync(pp.DocGiaId);
                var nv = await _repository.NhanVien.GetNhanVienByIdAsync(pp.NhanVienId);
                pp.TenDocGia = dg.HoTen;
                pp.TenNhanVien = nv.HoTen;
            }
            return listPpDto;
        }
    }
}
