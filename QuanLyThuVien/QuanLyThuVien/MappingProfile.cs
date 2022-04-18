using AutoMapper;
using Entities.DTO.DocGia;
using Entities.DTO.NhanVien;
using Entities.DTO.PhieuMuon;
using Entities.DTO.PhieuPhat;
using Entities.DTO.PhieuTra;
using Entities.DTO.Sach;
using Entities.DTO.User;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NhanVien, NhanVienDto>();
            CreateMap<DocGia, DocGiaDto>();
            CreateMap<DocGiaForCreationUpdateDto, DocGia>();
            CreateMap<NhanVienForCreationDto, NhanVien>();
            CreateMap<NhanVienForUpdateDto, NhanVien>();
            CreateMap<SachForCreationDto, Sach>();
            CreateMap<Sach, SachDto>();
            CreateMap<PhieuMuonForCreationDto, PhieuMuon>(); 
            CreateMap<PhieuMuon, PhieuMuonDto>();
            CreateMap<CTPhieuMuonForCreationDto, ChiTietPhieuMuon>();
            CreateMap<SachMuonForCreationDto, ChiTietPhieuMuon>();
            CreateMap<UserForCreate, User>();
            CreateMap<PhieuTraForCreationDto, PhieuTra>();
            CreateMap<PhieuTra, PhieuTraDto>();
            CreateMap<CTPhieuTraForCreationDto, ChiTietPhieuTra>();
            CreateMap<SachMuonDto, ChiTietPhieuTra>();
            CreateMap<PhieuPhatForCreationDto, PhieuPhat>();
            CreateMap<PhieuPhat, PhieuPhatDto>();
            CreateMap<User, UserForView>()
                .ForMember(x => x.BoPhan, opt => opt.MapFrom(x => x.NhanVien.BoPhan))
                .ForMember(x => x.TenNhanVien, opt => opt.MapFrom(x => x.NhanVien.HoTen));
        }
    }
}
