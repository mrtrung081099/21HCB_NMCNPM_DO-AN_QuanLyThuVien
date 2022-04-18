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
    public class CTThanhLySachService : ICTThanhLySachService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ISachService _sachService;

        public CTThanhLySachService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, ISachService sachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _sachService = sachService;
        }

        public async Task CreateCTThanhLySachAsync(SachThanhLyForCreationDto sachThanhLy, Guid tlsId)
        {
            var chitietTls = _mapper.Map<ChiTietThanhLySach>(sachThanhLy);
            chitietTls.ThanhLySachId = tlsId;
            _repository.CTThanhLySach.CreateCTThanhLySach(chitietTls);
            await _repository.SaveAsync();
        }
    }
}
