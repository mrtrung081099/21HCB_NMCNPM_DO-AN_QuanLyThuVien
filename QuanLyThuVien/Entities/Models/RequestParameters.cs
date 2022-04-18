using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string Search { get; set; }

    }
    public class NhanVienParameters : RequestParameters
    {

    }
    public class DocGiaParameters : RequestParameters
    {

    }
    public class SachParameters : RequestParameters
    {

    }
    public class PhieuMuonParameters : RequestParameters
    {

    }
    public class CTPhieuMuonParameters : RequestParameters
    {

    }
    public class PhieuTraParameters : RequestParameters
    {

    }
    public class CTPhieuTraParameters : RequestParameters
    {

    }
    public class PhieuPhatParameters : RequestParameters
    {

    }
    public class PhieuMatSachParameters : RequestParameters
    {

    }
    public class CTThanhLySachParameters : RequestParameters
    {

    }
    public class ThanhLySachParameters : RequestParameters
    {

    }

}
