﻿using AutoMapper;
using Contracts;
using Entities.DTO.DocGia;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class DocGiaService : IDocGiaService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DocGiaService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<DocGiaDto>> GetAllDocGiaAsync(DocGiaParameters docgiaParameters)
        {
            var dgs = new List<DocGiaDto>();
            var listDg = await _repository.DocGia.GetAllDocGiaAsync(docgiaParameters);
            var listDgDto = _mapper.Map(listDg, dgs);
            foreach(var item in listDgDto)
            {
                var nv = await _repository.NhanVien.GetNhanVienByIdAsync(item.NhanVienId);
                item.TenNhanVienLap = nv.HoTen;
            }
            return listDgDto;
        }

        public async Task<DocGiaDto> GetDocGiaByIdAsync(DocGia dg)
        {
            var dgDto = _mapper.Map<DocGiaDto>(dg);
            var nv = await _repository.NhanVien.GetNhanVienByIdAsync(dgDto.NhanVienId);
            dgDto.TenNhanVienLap = nv.HoTen;
            return dgDto;
        }

        public async Task<DocGiaDto> CreateDocGiaAsync(DocGiaForCreationUpdateDto docgia)
        {
            var dg = _mapper.Map<DocGia>(docgia);
            _repository.DocGia.CreateDocGia(dg);
            await _repository.SaveAsync();
            var result = await GetDocGiaByIdAsync(dg);
            return result;
        }

        public void DeleteDocGiaAsync(DocGia dg)
        {
            _repository.DocGia.DeleteDocGia(dg);
        }

        public async Task<DocGiaDto> UpdateDocGiaAsync(DocGia docgia)
        {
            _repository.DocGia.UpdateDocGia(docgia);
            await _repository.SaveAsync();
            var result = await GetDocGiaByIdAsync(docgia);
            return result;
        }
    }
}
