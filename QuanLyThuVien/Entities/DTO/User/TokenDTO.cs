﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.User
{
    public class TokenDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Token không hợp lệ")]
        public string AccessToken { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Token không hợp lệ")]
        public string RefreshToken { get; set; }
    }
}
