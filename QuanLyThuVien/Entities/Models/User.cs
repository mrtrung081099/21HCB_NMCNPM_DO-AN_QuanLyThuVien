using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User 
    {
        [Column("UserId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Email không được bỏ trống.")]
        [MaxLength(60, ErrorMessage = "Tối đa 60 kí tự.")]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
