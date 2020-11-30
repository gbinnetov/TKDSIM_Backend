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
    public class AdminUnitController : ControllerBase
    {
        private readonly IAdminUnitBLL _adminUnitBLL;
        public AdminUnitController(IAdminUnitBLL adminUnitBLL)
        {
            _adminUnitBLL = adminUnitBLL;
        }

        [HttpGet("adminUnitAll")]
        public async Task<IActionResult> AdminUnitAll()
        {

            List<AdminUnitDto> adminUnitDtos = await _adminUnitBLL.AdminUnitAll();

            return Ok(adminUnitDtos);
        }
        [HttpGet("adminUnitByCode/{code}")]
        public async Task<IActionResult> AdminUnitByCode(string code)
        {

            List<AdminUnitDto> adminUnitDtos = await _adminUnitBLL.AdminUnitByCode(code);

            return Ok(adminUnitDtos);
        }

        [HttpGet("adminUnitByID/{id}")]
        public async Task<IActionResult> AdminUnitByID(string id)
        {

            AdminUnitDto adminUnitDtos = await _adminUnitBLL.AdminUnitByID(id);

            return Ok(adminUnitDtos);
        }

        [HttpGet("adminUnitByParentCode/{parentCode}")]
        public async Task<IActionResult> AdminUnitByParentCode(string parentCode)
        {

            List<AdminUnitDto> adminUnitDtos = await _adminUnitBLL.AdminUnitByParentCode(parentCode);

            return Ok(adminUnitDtos);
        }

        [HttpGet("adminUnitChildByID/{id}")]
        public async Task<IActionResult> AdminUnitChildByID(string id)
        {

            List<AdminUnitDto> adminUnitDtos = await _adminUnitBLL.AdminUnitChildByID(id);

            return Ok(adminUnitDtos);
        }

        [HttpGet("adminUnitChildByCode/{code}")]
        public async Task<IActionResult> AdminUnitChildByCode(string code)
        {

            List<AdminUnitDto> adminUnitDtos = await _adminUnitBLL.AdminUnitChildByCode(code);

            return Ok(adminUnitDtos);
        }

    }
}
