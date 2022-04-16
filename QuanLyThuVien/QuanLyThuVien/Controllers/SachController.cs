using AutoMapper;
using Contracts;
using Entities.DTO.Sach;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{

    [Route("api/sachs")]
    [ApiController]
    public class SachController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ISachService _sachService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public SachController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, ISachService sachService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _sachService = sachService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSach([FromQuery] SachParameters sachParameters)
        {
            var sach = await _sachService.GetAllSachAsync(sachParameters);
            var total = await _repository.Sach.Count();
            return Ok(new { total = total, listSachs = sach });
        }
        [HttpGet("GetAllByState")]
        public async Task<IActionResult> GetAllByState([FromQuery] SachParameters sachParameters)
        {
            var sach = await _sachService.GetAllSachByStateAsync(sachParameters);
            var total = await _repository.Sach.CountTotalByState(sachParameters.Search);
            return Ok(new { total = total, listSachs = sach });
        }
        [HttpGet("GetAllByName")]
        public async Task<IActionResult> GetAllByNameState([FromQuery] SachParameters sachParameters)
        {
            var sach = await _sachService.GetAllSachByNameAsync(sachParameters);
            var total = await _repository.Sach.CountTotalByName(sachParameters.Search);
            return Ok(new { total = total, listSachs = sach });
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetSachById(Guid id)
        {
            var sach = await _sachService.GetSachDtoByIdAsync(id);
            if (sach == null)
            {
                _logger.LogInfo($"Sách với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(sach);

        }
        [HttpPost("CreateSach")]
        public async Task<IActionResult> CreateSach(SachForCreationDto sach)
        {
            return Ok(await _sachService.CreateSachAsync(sach));
        }
        [HttpPut("UpdateSach/{id}")]
        public async Task<IActionResult> UpdateSach(Guid id, SachForCreationDto sach)
        {
            var s = await _sachService.GetSachByIdAsync(id);
            if (s == null)
            {
                _logger.LogInfo($"Sách với id: {id} không tồn tại .");
                return NotFound();
            }
            _mapper.Map(sach, s);
            return Ok(await _sachService.UpdateSachAsync(s));
        }
        [HttpDelete("DeleteSach/{id}")]
        public async Task<IActionResult> DeleteSach(Guid id)
        {
            var s = await _sachService.GetSachByIdAsync(id);
            if (s == null)
            {
                _logger.LogInfo($"Sách với id: {id} không tồn tại .");
                return NotFound();
            }
            _sachService.DeleteSachAsync(s);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
