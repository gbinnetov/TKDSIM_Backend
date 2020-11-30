using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TKDSIM.BLL.Interface;
using TKDSIM.DTO.DTO;

namespace TKDSIM.WebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBLL _auth;

        public AuthController(IUserBLL _auth)
        {
            this._auth = _auth;
        }

        /// <summary>
        /// Login by userName and password
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status204NoContent, "Invalid model");
            }
      
            AuthDto authDto = await _auth.Login(loginDto.UserName, loginDto.Password);
            if (authDto.statusCode != "1")
            {
                return StatusCode(StatusCodes.Status401Unauthorized, authDto.responseText);
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, authDto.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, authDto.Role.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TkDabcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789SiM"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenValue = tokenHandler.WriteToken(token);

            LoginResponseDto loginResponseDto = new LoginResponseDto();
            loginResponseDto.userInfo = authDto;
            loginResponseDto.token = tokenValue;

            return Ok(loginResponseDto);
        }

        /// <summary>
        /// Logout, clear cookie
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public IActionResult logout()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Security.Cookie");
            return Ok();
        }
    }
}
