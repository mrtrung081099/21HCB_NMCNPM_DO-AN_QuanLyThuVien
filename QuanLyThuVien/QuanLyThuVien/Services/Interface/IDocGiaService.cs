﻿using Entities.DTO.DocGia;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services.Interface
{
    public interface IDocGiaService
    {

        public Task<IEnumerable<DocGiaDto>> GetAllDocGiaAsync(DocGiaParameters docgiaParameters);
        public Task<DocGiaDto> GetDocGiaByIdAsync(DocGia dg);
        public Task<DocGiaDto> CreateDocGiaAsync(DocGiaForCreationUpdateDto docgia);
        public void DeleteDocGiaAsync(DocGia dg);
        public Task<DocGiaDto> UpdateDocGiaAsync(DocGiaForCreationUpdateDto docgia);


    }
}
