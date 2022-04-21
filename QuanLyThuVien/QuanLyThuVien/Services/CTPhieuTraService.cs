using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMuon;
using Entities.DTO.PhieuTra;
using Entities.DTO.Sach;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class CTPhieuTraService : ICTPhieuTraService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ISachService _sachService;

        public CTPhieuTraService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, ISachService sachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _sachService = sachService;
        }

        public async Task CreateCTPhieuTraAsync(CTPhieuTraForCreationDto ctpt)
        {
            var chitietpt = _mapper.Map<ChiTietPhieuTra>(ctpt);
            _repository.CTPhieuTra.CreateCTPhieuTra(chitietpt);
            await _repository.SaveAsync();
        }

        public async Task CreateCtptAsync(SachMuonDto ctpt, Guid ptId)
        {
            var chitietDto = _mapper.Map<CTPhieuTraForCreationDto>(ctpt);
            var chitietpt = _mapper.Map<ChiTietPhieuTra>(chitietDto);
            chitietpt.PhieuTraId = ptId;
            chitietpt.SachId = ctpt.Id;
            _repository.CTPhieuTra.CreateCTPhieuTra(chitietpt);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ChiTietPhieuTra>> GetAllCTPhieuTraByptId(Guid ptId)
        {
            var listCtpt = await _repository.CTPhieuTra.GetAllCTPhieuTraByIdPtAsync(ptId);
            if (listCtpt != null)
            {
                foreach (var ctpm in listCtpt)
                {
                    ctpm.Sach = await _repository.Sach.GetSachByIdAsync(ctpm.SachId);
                }
            }
            return listCtpt;
        }
    }
}
