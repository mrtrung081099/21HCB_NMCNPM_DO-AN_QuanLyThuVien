using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMatSach;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    [Route("api/phieumatsachs")]
    [ApiController]
    public class PhieuMatSachController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IPhieuMatSachService _phieumatsachService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public PhieuMatSachController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IPhieuMatSachService phieumatsachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _phieumatsachService = phieumatsachService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPhieuMatSach([FromQuery] PhieuMatSachParameters phieuMatSachParameters)
        {
            var pms = await _phieumatsachService.GetAllPhieuMatSachDtoAsync(phieuMatSachParameters);
            var total = await _repository.PhieuMatSach.CountPhieuMatSach();
            return Ok(new { total = total, listPhieuMatSachs = pms });
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPhieuMatSachById(Guid id)
        {
            var result = await _phieumatsachService.GetPhieuMatSachDtoByIdAsync(id);
            if (result == null)
            {
                _logger.LogInfo($"Phiếu mat sach với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(result);

        }
        [HttpPost("CreatePhieuMatSach")]
        public async Task<IActionResult> CreatePhieuMatSach(PhieuMatSachForCreationDto phieuMatSach)
        {
            return Ok(await _phieumatsachService.CreatePhieuMatSachAsync(phieuMatSach));
        }
    }
}
