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
    public class EnumValueController : ControllerBase
    {
        private readonly IEnumValueBLL _EnumValueBLL;
        public EnumValueController(IEnumValueBLL EnumValueBLL)
        {
            _EnumValueBLL = EnumValueBLL;
        }

        [HttpGet("EnumValueGetAll")]
        public async Task<IActionResult> EnumValueGetAll()
        {

            List<EnumValueDTO> EnumValueDTO = await _EnumValueBLL.GetList();

            return Ok(EnumValueDTO);
        }

        [HttpGet("EnumValueGetByID/{id}")]
        public async Task<IActionResult> EnumValueGetByID(decimal id)
        {

            EnumValueDTO EnumValueDTO = await _EnumValueBLL.GetByID(id);

            return Ok(EnumValueDTO);
        }

        [HttpGet("EnumValueGetByEnumID/{id}")]
        public async Task<IActionResult> EnumValueGetByEnumID(int id)
        {

            List<EnumValueDTO> EnumValueDTO = await _EnumValueBLL.EnumValueByEnumID(id);

            return Ok(EnumValueDTO);
        }

        [HttpPost("EnumValueUpdate")]
        public async Task<IActionResult> EnumValueUpdate(EnumValueDTO item)
        {

            EnumValueDTO EnumValueDTO = await _EnumValueBLL.Update(item);

            if (EnumValueDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(EnumValueDTO);
        }

        [HttpPost("EnumValueInsert")]
        public async Task<IActionResult> EnumValueInsert(EnumValueDTO item)
        {

            EnumValueDTO EnumValueDTO = await _EnumValueBLL.Add(item);

            if (EnumValueDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(EnumValueDTO);
        }
        [HttpGet("enumValueJoinEnumGetAll")]
        public async Task<IActionResult> EnumValueJoinEnumGetAll() {
            List<EnumValueDTO> enumValueDTO = await _EnumValueBLL.EnumValueJoinEnumGetAll();
            return Ok(enumValueDTO);
        }

        [HttpDelete("EnumValueDelete/{id}")]
        public async Task<IActionResult> EnumValueDelete(int id)
        {

            _EnumValueBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
