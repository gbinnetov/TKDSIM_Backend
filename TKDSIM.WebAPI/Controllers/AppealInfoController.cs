using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TKDSIM.BLL.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.WebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AppealInfoController : ControllerBase
    {
        private readonly IAppealInfoBLL _appealInfoBLL;
        
        public AppealInfoController(IAppealInfoBLL appealInfoBLL)
        {
            
            _appealInfoBLL = appealInfoBLL;
        }

        [HttpGet("appealInfoGetAll")]
        public async Task<IActionResult> AppealInfoGetAll() {

            List<AppealInfoDTO> appealInfoDTO = await _appealInfoBLL.GetList();

            return Ok(appealInfoDTO);
        }

        [HttpGet("appealInfoGetByID/{id}")]
        public async Task<IActionResult> AppealInfoGetByID(decimal id)
        {

            AppealInfoDTO appealInfoDTO = await _appealInfoBLL.GetByID(id);

            

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }

        [HttpPost("appealInfoUpdate")]
        public async Task<IActionResult> AppealInfoUpdate(AppealInfoDTO item)
        {
          

            AppealInfoDTO appealInfoDTO = await _appealInfoBLL.Update(item);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }
        
        [HttpPost("appealInfoSearch")]
        public async Task<IActionResult> AppealInfoSearch(AppealInfoDTO item)
        {

            List<AppealInfoDTO> appealInfoDTO = await _appealInfoBLL.AppealInfoSearch(item);



            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }


        [HttpPost("appealInfoInsert")]
        public async Task<IActionResult> appealInfoInsert(AppealInfoDTO item)
        {

            AppealInfoDTO appealInfoDTO = await _appealInfoBLL.Add(item);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(appealInfoDTO);
        }

        [HttpDelete("appealInfoDelete/{id}")]
        public async Task<IActionResult> appealInfoDelete(int id)
        {

            _appealInfoBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }

        [HttpGet("appealNo")]
        public async Task<IActionResult> appealNo() {

            List<AppealInfoDTO> appealInfoDTOs = await _appealInfoBLL.GetList();

            if (appealInfoDTOs.Count < 1)
            {
      
                return Ok("1000001");
            }

            appealInfoDTOs = appealInfoDTOs.OrderByDescending(x => x.A_ID).ToList();


            return Ok((1000001 + appealInfoDTOs[0].A_ID));
        }

    }
}
