using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.User
{
    public class UserForCreate
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập mail hợp lệ")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập id nhân viên")]
        public string Password { get; set; }
        [Compare(otherProperty: "Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

    }
}
