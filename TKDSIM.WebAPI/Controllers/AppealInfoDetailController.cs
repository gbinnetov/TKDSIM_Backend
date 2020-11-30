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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AppealInfoDetailController : ControllerBase
    {
        private readonly IAppealInfoDetailBLL _appealInfodetail;

        public AppealInfoDetailController(IAppealInfoDetailBLL appealInfodetail)
        {
            _appealInfodetail = appealInfodetail;
        }

        [HttpGet("appealInfoDetailGetAll")]
        public async Task<IActionResult> AppealInfoDetailGetAll()
        {

            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.GetList();

            return Ok(appealInfoDTO);
        }
        [HttpGet("appealInfoDetailGetByID/{id}")]
        public async Task<IActionResult> appealInfoDetailGetByID(int id)
        {
            AppealInfoDetailDto appealInfoDTO = await _appealInfodetail.GetByID(id);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }

        [HttpGet("appealInfoDetailGetByAppealID/{id}")]
        public async Task<IActionResult> appealInfoDetailGetByAppealID(int id)
        {

            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.GetListByAppealID(id);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }

        [HttpPost("appealInfoDetailAdd")]
        public async Task<IActionResult> appealInfoDetailAdd(AppealInfoDetailDto item)
        {

            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.Add(item);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }

        [HttpPost("appealInfoDetailUpdate")]
        public async Task<IActionResult> appealInfoDetailUpdate(AppealInfoDetailDto item)
        {

            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.Update(item);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }
        [HttpDelete("appealInfoDetailDelete/{id}")]
        public async Task<IActionResult> appealInfoDetailDelete(int id)
        {
            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.Delete(id);


            return Ok(appealInfoDTO);
        }
    }
}
