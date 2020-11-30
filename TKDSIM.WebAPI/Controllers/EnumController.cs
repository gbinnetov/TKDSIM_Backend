using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TKDSIM.BLL.Interface;
using TKDSIM.DTO.DTO;

namespace TKDSIM.WebAPI.Controllers
{
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        private readonly IEnumBLL _EnumBLL;
        public EnumController(IEnumBLL EnumBLL)
        {
            _EnumBLL = EnumBLL;
        }

        [HttpGet("enumGetAll")]
        public async Task<IActionResult> EnumGetAll()
        {

            List<EnumDTO> EnumDTO = await _EnumBLL.GetList();

            return Ok(EnumDTO);
        }

        [HttpGet("enumGetByID/{id}")]
        public async Task<IActionResult> EnumGetByID(decimal id)
        {

            EnumDTO EnumDTO = await _EnumBLL.GetByID(id);

            return Ok(EnumDTO);
        }

        [HttpPost("enumUpdate")]
        public async Task<IActionResult> EnumUpdate(EnumDTO item)
        {

            EnumDTO EnumDTO = await _EnumBLL.Update(item);

            if (EnumDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(EnumDTO);
        }

        [HttpPost("enumInsert")]
        public async Task<IActionResult> EnumInsert(EnumDTO item)
        {

            EnumDTO EnumDTO = await _EnumBLL.Add(item);

            if (EnumDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(EnumDTO);
        }

        [HttpDelete("enumDelete/{id}")]
        public async Task<IActionResult> EnumDelete(int id)
        {

            _EnumBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
