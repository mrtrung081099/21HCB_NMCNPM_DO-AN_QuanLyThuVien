﻿using AutoMapper;
using Contracts;
using Entities.DTO.PhieuMuon;
using Entities.DTO.Sach;
using Entities.Models;
using QuanLyThuVien.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class SachService : ISachService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;
        public SachService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SachDto> CreateSachAsync(SachForCreationDto Sach)
        {
            var sach = _mapper.Map<Sach>(Sach);
            _repository.Sach.CreateSach(sach);
            await _repository.SaveAsync();
            var result = await GetSachDtoByIdAsync(sach.Id);
            return result;

        }

        public async Task<IEnumerable<SachDto>> GetAllSachAsync(SachParameters SachParameters)
        {
            var sachs = await _repository.Sach.GetAllSachAsync(SachParameters);
            var listSachDto = _mapper.Map<IEnumerable<SachDto>>(sachs);
            foreach (var s in listSachDto)
            {
                var nv = await _repository.NhanVien.GetNhanVienByIdAsync(s.NhanVienId);
                s.TenNhanVien = nv.HoTen;
            }
            return listSachDto;
        }

        public async Task<SachDto> GetSachDtoByIdAsync(Guid id)
        {
            var sach = await _repository.Sach.GetSachByIdAsync(id);
            var nv = await _repository.NhanVien.GetNhanVienByIdAsync(sach.NhanVienId);
            var sachdto = _mapper.Map<SachDto>(sach);
            sachdto.TenNhanVien = nv.HoTen;
            return sachdto;
        }

        public void DeleteSachAsync(Sach Sach)
        {
            _repository.Sach.DeleteSach(Sach);
        }

        public async Task<int> GetCountSach()
        {
            return await _repository.Sach.CountSach();
        }

        public async Task<SachDto> UpdateSachAsync(Sach Sach)
        {
            _repository.Sach.UpdateSach(Sach);
            await _repository.SaveAsync();
            var result = await GetSachDtoByIdAsync(Sach.Id);
            return result;
        }

        public async Task<Sach> GetSachByIdAsync(Guid id)
        {
            return await _repository.Sach.GetSachByIdAsync(id);
        }

        public async Task<IEnumerable<SachDto>> GetAllSachByStateAsync(SachParameters SachParameters)
        {
            var sachs = await _repository.Sach.GetAllSachByStateAsync(SachParameters);
            var listSachDto = _mapper.Map<IEnumerable<SachDto>>(sachs);
            foreach (var s in listSachDto)
            {
                var nv = await _repository.NhanVien.GetNhanVienByIdAsync(s.NhanVienId);
                s.TenNhanVien = nv.HoTen;
            }
            return listSachDto;
        }

        public async Task<IEnumerable<SachDto>> GetAllSachByNameAsync(SachParameters SachParameters)
        {
            var sachs = await _repository.Sach.GetAllSachByNameAsync(SachParameters);
            var listSachDto = _mapper.Map<IEnumerable<SachDto>>(sachs);
            foreach (var s in listSachDto)
            {
                var nv = await _repository.NhanVien.GetNhanVienByIdAsync(s.NhanVienId);
                s.TenNhanVien = nv.HoTen;
            }
            return listSachDto;
        }

        public async Task UpdateStateSachAsync(Guid id, string state)
        {
                var sach = await _repository.Sach.GetSachByIdAsync(id);
                if (sach != null)
                {
                    sach.TinhTrang = state;
                    _repository.Sach.UpdateSach(sach);
                    await _repository.SaveAsync();
                }
        }
        public async Task<List<SachMuonDto>> GetListSachMuonByDocGiaId(Guid docgiaId,DateTime ngayTra)
        {
            var sach = await _repository.Sach.GetAllSachMuonByDocGiaIdAsync(docgiaId);
            foreach(var item in sach)
            {
                TimeSpan Time = ngayTra.Date - item.NgayMuon.Date;
                item.SoNgayMuon = Time.Days;
                var ngayTre = item.SoNgayMuon - 4;
                if (ngayTre > 0)
                {
                    item.TienPhat = 1000 * ngayTre;
                }
                else
                {
                    item.TienPhat = 0;
                }
            }
            return sach;
        }

        public async Task<List<SachMuonDto>> GetListSachTraByPtId(Guid ptId)
        {
            return await _repository.Sach.GetAllSachMuonByPhieuTraIdAsync(ptId);
        }
    }
}
