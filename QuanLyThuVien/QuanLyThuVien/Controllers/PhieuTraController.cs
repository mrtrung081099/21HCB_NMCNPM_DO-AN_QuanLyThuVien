using AutoMapper;
using Contracts;
using Entities.DTO.PhieuTra;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    [Route("api/phieutras")]
    [ApiController]
    public class PhieuTraController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IPhieuTraService _phieuTraService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public PhieuTraController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IPhieuTraService phieuTraService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _phieuTraService = phieuTraService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPhieuTra([FromQuery] PhieuTraParameters ptParameters)
        {
            var pts = await _phieuTraService.GetAllPhieuTraDtoAsync(ptParameters);
            var total = await _repository.PhieuTra.CountPhieuTra();
            return Ok(new { total = total, listPhieuTras = pts });
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPhieuTraById(Guid id)
        {
            var nv = await _phieuTraService.GetPhieuTraDtoByIdAsync(id);
            if (nv == null)
            {
                _logger.LogInfo($"Phiếu trả với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(nv);

        }
        [HttpPost("CreatePhieuTra")]
        public async Task<IActionResult> CreatePhieuTra(PhieuTraForCreationDto pm)
        {
            return Ok(await _phieuTraService.CreatePhieuTraAsync(pm));
        }
    }
}
