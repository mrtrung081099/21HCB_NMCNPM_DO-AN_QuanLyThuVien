using AutoMapper;
using Contracts;
using Entities.DTO.PhieuPhat;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    [Route("api/phieuphats")]
    [ApiController]
    public class PhieuPhatController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IPhieuPhatService _phieuphatService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public PhieuPhatController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IPhieuPhatService phieuphatService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _phieuphatService = phieuphatService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPhieuPhat([FromQuery] PhieuPhatParameters ppParameters)
        {
            var pts = await _phieuphatService.GetAllPhieuPhatDtoAsync(ppParameters);
            var total = await _repository.PhieuPhat.CountPhieuPhat();
            return Ok(new { total = total, listPhieuPhats = pts });
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPhieuPhatById(Guid id)
        {
            var result = await _phieuphatService.GetPhieuTraDtoByIdAsync(id);
            if (result == null)
            {
                _logger.LogInfo($"Phiếu phạt với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(result);

        }
        [HttpPost("CreatePhieuPhat")]
        public async Task<IActionResult> CreatePhieuPhat(PhieuPhatForCreationDto phieuPhat)
        {
            return Ok(await _phieuphatService.CreatePhieuTraAsync(phieuPhat));
        }
    }
}
