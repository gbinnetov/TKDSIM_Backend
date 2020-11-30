using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class LoginDto
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string Password { get; set; }

    }
}
