using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMuon;
using Entities.DTO.Sach;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class PhieuMuonService: IPhieuMuonService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ICTPhieuMuonService _ctpmService;
        private readonly ISachService _sachService;
        public PhieuMuonService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, ICTPhieuMuonService ctpmService, ISachService sachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _ctpmService = ctpmService;
            _sachService = sachService;
        }

        public async Task<PhieuMuonDto> CreatePhieuMuonAsync(PhieuMuonForCreationDto pm)
        {
            var phieumuon = _mapper.Map<PhieuMuon>(pm);
            phieumuon.NgayMuon = DateTime.Now;
            phieumuon.NgayHetHan = phieumuon.NgayMuon.AddDays(4);
            _repository.PhieuMuon.CreatePhieuMuon(phieumuon);
            await _repository.SaveAsync();
            if (pm.SachMuons != null)
            {
                foreach(var ctpm in pm.SachMuons)
                {
                    await _ctpmService.CreateCtPmAsync(ctpm, phieumuon.Id);
                    await _sachService.UpdateStateSachAsync(ctpm.SachId, "Đã Mượn");
                }
            }
            var result = await GetPhieuMuonDtoByIdAsync(phieumuon.Id);

            return result;
        }


        public async Task<PhieuMuonDto> GetPhieuMuonDtoByIdAsync(Guid id)
        {
            var pm = await _repository.PhieuMuon.GetPhieuMuonByIdAsync(id);
            var sachmuons = await _ctpmService.GetAllSachMuonByPmId(pm.Id);
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(pm.DocGiaId);
            var pmDto = _mapper.Map<PhieuMuonDto>(pm);
            pmDto.TenDocGia = dg.HoTen;
            pmDto.SachMuons = sachmuons;
            return pmDto;
        }

        public async Task<IEnumerable<PhieuMuonDto>> GetAllPhieuMuonDtoAsync(PhieuMuonParameters pm)
        {
            var pms = new List<PhieuMuonDto>();
            var listPm =  await _repository.PhieuMuon.GetAllPhieuMuonAsync(pm);
            var listPmDto = _mapper.Map(listPm, pms);
            foreach (var pmDto in listPmDto)
            {
                var sachmuons = await _ctpmService.GetAllSachMuonByPmId(pmDto.Id);
                var dg = await _repository.DocGia.GetDocGiaByIdAsync(pmDto.DocGiaId);
                pmDto.TenDocGia = dg.HoTen;
                pmDto.SachMuons = sachmuons;
            }
            return listPmDto;
        }
        public async Task<int> GetCountPhieuMuon()
        {
            return await _repository.PhieuMuon.CountPhieuMuon();
        }

        public Task<PhieuMuon> GetPhieuMuonByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
