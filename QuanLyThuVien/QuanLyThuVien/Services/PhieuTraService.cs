using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMuon;
using Entities.DTO.PhieuTra;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class PhieuTraService : IPhieuTraService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ICTPhieuTraService _ctptService;
        private readonly ISachService _sachService;
        private readonly ICTPhieuMuonService _ctpmService;
        private readonly IDocGiaService _docGiaService;
        public PhieuTraService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, ICTPhieuTraService ctptService, ISachService sachService, ICTPhieuMuonService ctpmService, IDocGiaService docGiaService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _ctptService = ctptService;
            _sachService = sachService;
            _ctpmService = ctpmService;
            _docGiaService = docGiaService;
        }

        public async Task<PhieuTraDto> CreatePhieuTraAsync(PhieuTraForCreationDto pt)
        {
            var phieutra = _mapper.Map<PhieuTra>(pt);
            phieutra.NgayTra = DateTime.Now;
            _repository.PhieuTra.CreatePhieuTra(phieutra);
            await _repository.SaveAsync();
            if (pt.SachTras != null)
            {
                foreach (var ctpt in pt.SachTras)
                {
                    await _ctptService.CreateCtptAsync(ctpt, phieutra.Id);
                    await _sachService.UpdateStateSachAsync(ctpt.Id, "Chưa Mượn");
                    await _ctpmService.UpdateCTPhieuMuonAsync(ctpt.Id, "Đã Trả");
                }
            }
            await _docGiaService.UpdateTongNoDocGia(phieutra.DocGiaId, phieutra.TienPhat);
            var result = await GetPhieuTraDtoByIdAsync(phieutra.Id);

            return result;
        }

        public async Task<PhieuTraDto> GetPhieuTraDtoByIdAsync(Guid id)
        {
            var pt = await _repository.PhieuTra.GetPhieuTraByIdAsync(id);
            if (pt != null)
            {
                var sachtras = await _sachService.GetListSachTraByPtId(pt.Id);
                var dg = await _repository.DocGia.GetDocGiaByIdAsync(pt.DocGiaId);
                var pmDto = _mapper.Map<PhieuTraDto>(pt);
                pmDto.TenDocGia = dg.HoTen;
                pmDto.SachTras = sachtras;
                return pmDto;
            }
        }
    }
}
