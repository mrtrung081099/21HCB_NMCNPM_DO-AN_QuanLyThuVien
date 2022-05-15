using AutoMapper;
using Contracts;
using Entities.DTO.DocGia;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    [Route("api/docgias")]
    [ApiController]
    public class DocGiasController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IDocGiaService _docgiaService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;
        public DocGiasController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IDocGiaService docgiaService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _docgiaService = docgiaService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDocGia([FromQuery] DocGiaParameters docgiaParameters)
        {
            var dgs = await _docgiaService.GetAllDocGiaAsync(docgiaParameters);
            var total = await _docgiaService.GetCountDocGia();
            return Ok(new { total = total, listDgs = dgs });
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetDocGiaById(Guid id)
        {
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(id);
            if (dg == null)
            {
                _logger.LogInfo($"Độc giả với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(await _docgiaService.GetDocGiaByIdAsync(dg));
        }
        [HttpGet("CheckDeadlineMuonSachDocGia/{id}")]
        public async Task<IActionResult> CheckDeadlineMuonSachDocGia(Guid id)
        {
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(id);
            if (dg == null)
            {
                _logger.LogInfo($"Độc giả với id: {id} không tồn tại .");
                return NotFound();
            }
            return Ok(await _repository.DocGia.CheckDeadlineMuonSachDocGia(id));
        }
        [HttpGet("ThongKeDocGiaNoTien")]
        public async Task<IActionResult> ThongKeDocGiaNoTien(DateTime ngay)
        {
            return Ok(await _repository.DocGia.ThongKeDocGiaNoTien(ngay));
        }
        [HttpPost("CreateDocGia")]
        public async Task<IActionResult> CreateDocGia(DocGiaForCreationUpdateDto docgia)
        {
            if(docgia == null)
            {
                return BadRequest("DocGiaForCreationUpdateDto object is null");
            }
            return Ok( await _docgiaService.CreateDocGiaAsync(docgia));
        }
        [HttpPut("UpdateDocGia/{id}")]
        public async Task<IActionResult> UpdateDocGia(Guid id, DocGiaForCreationUpdateDto docgia)
        {
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(id);
            if (dg == null)
            {
                _logger.LogInfo($"Độc giả với id: {id} không tồn tại .");
                return NotFound();
            }
            if (docgia == null)
            {
                return BadRequest("DocGiaForCreationUpdateDto object is null");
            }
            _mapper.Map(docgia, dg);
            return Ok(await _docgiaService.UpdateDocGiaAsync(dg));

        }
        [HttpDelete("DeleteDocGia/{id}")]
        public async Task<IActionResult> DeleteDocGiaById(Guid id)
        {
            var dg = await _repository.DocGia.GetDocGiaByIdAsync(id);
            if (dg == null)
            {
                _logger.LogInfo($"Độc giả với id: {id} không tồn tại .");
                return NotFound();
            }
            _docgiaService.DeleteDocGiaAsync(dg);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
