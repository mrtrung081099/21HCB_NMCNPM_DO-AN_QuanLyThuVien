using AutoMapper;
using Contracts;
using Entities.DTO.ThanhLySach;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    [Route("api/thanhlysachs")]
    [ApiController]
    public class ThanhLySachController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IThanhLySachService _thanhlyService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public ThanhLySachController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IThanhLySachService thanhlyService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _thanhlyService = thanhlyService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllThanhLySach([FromQuery] ThanhLySachParameters pmParameters)
        {
            var result = await _thanhlyService.GetAllThanhLySachDtoAsync(pmParameters);
            var total = await _thanhlyService.GetCountThanhLySach();
            return Ok(new { total = total, listThanhLySachs = result });
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetThanhLySachById(Guid id)
        {
            var nv = await _thanhlyService.GetThanhLySachDtoByIdAsync(id);
            if (nv == null)
            {
                _logger.LogInfo($"Phiếu thanh ly sach với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(nv);

        }
        [HttpPost("CreateThanhLySach")]
        public async Task<IActionResult> CreateThanhLySach(ThanhLySachForCreationDto pm)
        {
            return Ok(await _thanhlyService.CreateThanhLySachAsync(pm));
        }
    }
}
