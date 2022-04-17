using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private INhanVienRepository _nhanvienRepository;
        private IDocGiaRepository _docgiaRepository;
        private IAuthRepository _authRepository;
        private ISachRepository _sachRepository;
        private IPhieuMuonRepository _phieumuonRepository;
        private ICTPhieuMuonRepository _ctphieumuonRepository;
        private IPhieuTraRepository _phieutraRepository;
        private ICTPhieuTraRepository _ctphieutraRepository;


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public INhanVienRepository NhanVien
        {
            get
            {
                if (_nhanvienRepository == null)
                    _nhanvienRepository = new NhanVienRepository(_repositoryContext);
                return _nhanvienRepository;
            }
        }
        public IDocGiaRepository DocGia
        {
            get
            {
                if (_docgiaRepository == null)
                    _docgiaRepository = new DocGiaRepository(_repositoryContext);
                return _docgiaRepository;
            }
        }
        public IAuthRepository User
        {
            get
            {
                if (_authRepository == null)
                    _authRepository = new AuthRepository(_repositoryContext);
                return _authRepository;
            }
        }
        public ISachRepository Sach
        {
            get
            {
                if (_sachRepository == null)
                    _sachRepository = new SachRepository(_repositoryContext);
                return _sachRepository;
            }
        }

        public IPhieuMuonRepository PhieuMuon
        {
            get
            {
                if (_phieumuonRepository == null)
                    _phieumuonRepository = new PhieuMuonRepository(_repositoryContext);
                return _phieumuonRepository;
            }
        }
        public ICTPhieuMuonRepository CTPhieuMuon
        {
            get
            {
                if (_ctphieumuonRepository == null)
                    _ctphieumuonRepository = new CTPhieuMuonRepository(_repositoryContext);
                return _ctphieumuonRepository;
            }
        }
        public IPhieuTraRepository PhieuTra
        {
            get
            {
                if (_phieutraRepository == null)
                    _phieutraRepository = new PhieuTraRepository(_repositoryContext);
                return _phieutraRepository;
            }
        }
        public ICTPhieuTraRepository CTPhieuTra
        {
            get
            {
                if (_ctphieutraRepository == null)
                    _ctphieutraRepository = new CTPhieuTraRepository(_repositoryContext);
                return _ctphieutraRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }
}
