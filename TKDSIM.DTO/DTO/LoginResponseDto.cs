using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class LoginResponseDto
    {
        public AuthDto userInfo { get; set; }
        public string token { get; set; }
    }
}
