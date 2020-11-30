using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TKDSIM.BLL.Interface;
using TKDSIM.DTO.DTO;

namespace TKDSIM.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _UserBLL;
        public UserController(IUserBLL UserBLL)
        {
            _UserBLL = UserBLL;
        }

        [HttpGet("UserGetAll")]
        public async Task<IActionResult> UserGetAll()
        {

            List<UserDTO> UserDTO = await _UserBLL.GetList();

            return Ok(UserDTO);
        }


        [HttpPost("UserGetInfo")]
        public async Task<IActionResult> UserGetInfo()
        {
            string claimRole = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            UserDTO UserDTO = await _UserBLL.GetByID(int.Parse(claimRole));

            return Ok(UserDTO);
        }

        [HttpGet("UserGetByID/{id}")]
        public async Task<IActionResult> UserGetByID(decimal id)
        {

            UserDTO UserDTO = await _UserBLL.GetByID(id);

            return Ok(UserDTO);
        }

        [HttpPost("UserUpdate")]
        public async Task<IActionResult> UserUpdate(UserDTO item)
        {

            UserDTO UserDTO = await _UserBLL.Update(item);

            if (UserDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(UserDTO);
        }

        [HttpPost("UserInsert")]
        public async Task<IActionResult> UserInsert(UserDTO item)
        {

            UserDTO UserDTO = await _UserBLL.Add(item);

            if (UserDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(UserDTO);
        }

        [HttpDelete("UserDelete/{id}")]
        public async Task<IActionResult> UserDelete(int id)
        {

            _UserBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
