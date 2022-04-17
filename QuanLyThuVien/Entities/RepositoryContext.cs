using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<PhieuMuon> PhieuMuons { get; set; }
        public DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        public DbSet<PhieuTra> PhieuTras { get; set; }

        public DbSet<ChiTietPhieuTra> ChiTietPhieuTras { get; set; }

        

    }
}
