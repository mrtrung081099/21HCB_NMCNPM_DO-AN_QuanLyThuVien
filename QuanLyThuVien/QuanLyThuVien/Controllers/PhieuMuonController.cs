﻿using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMuon;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    [Route("api/phieumuons")]
    [ApiController]
    public class PhieuMuonController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IPhieuMuonService _phieumuonService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public PhieuMuonController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IPhieuMuonService phieumuonService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _phieumuonService = phieumuonService;
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPhieuMuonById(Guid id)
        {
            var nv = await _phieumuonService.GetPhieuMuonByIdAsync(id);
            if (nv == null)
            {
                _logger.LogInfo($"Phiếu mượn với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(nv);

        }
        [HttpPost("CreatePhieuMuon")]
        public async Task<IActionResult> CreateSach(PhieuMuonForCreationDto pm)
        {
            return Ok(await _phieumuonService.CreatePhieuMuonAsync(pm));
        }
    }
}
