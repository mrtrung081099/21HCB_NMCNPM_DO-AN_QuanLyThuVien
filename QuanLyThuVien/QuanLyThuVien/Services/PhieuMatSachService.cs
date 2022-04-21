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
        private readonly ICTPhieuMuonService _ctpmService;

        public PhieuMatSachService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IDocGiaService docGiaService, ISachService sachService, ICTPhieuMuonService ctpmService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _docGiaService = docGiaService;
            _sachService = sachService;
            _ctpmService = ctpmService;
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
            await _docGiaService.UpdateTongNoDocGiaMatSach(phieumatsach.DocGiaId, phieumatsach.TienPhat);
            var sachMuon = await _repository.Sach.GetAllSachMuonByDocGiaIdAsync(phieumatsach.DocGiaId);
            if (sachMuon != null)
            {
                foreach (var i in sachMuon)
                {
                    if (i.Id == phieumatsach.SachId)
                    {
                        await _ctpmService.UpdateCTPhieuMuonAsync(i.Id, "Đã Trả");
                    }
                }
            }
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
