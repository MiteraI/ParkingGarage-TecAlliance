using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.Authentication
{
    public class LoginDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
