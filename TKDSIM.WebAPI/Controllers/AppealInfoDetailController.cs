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
        private readonly IAppealInfoBLL _appealInfoBLL;

        public AppealInfoDetailController(IAppealInfoDetailBLL appealInfodetail, IAppealInfoBLL appealInfoBLL)
        {
            _appealInfodetail = appealInfodetail;
            _appealInfoBLL = appealInfoBLL;
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
            if (item.RegionList.Count == 1)
            {
                item.Region = item.RegionList[0] + ";;";
            }
            else if (item.RegionList.Count == 2)
            {
                item.Region = item.RegionList[0] + ";" + item.RegionList[1] + ";";
            }
            else if (item.RegionList.Count == 3)
            {
                item.Region = item.RegionList[0] + ";" + item.RegionList[1] + ";" + item.RegionList[2];
            } 
            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.Add(item);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(appealInfoDTO);
        }

        [HttpPost("appealInfoDetailUpdate")]
        public async Task<IActionResult> appealInfoDetailUpdate(AppealInfoDetailDto item)
        {

            if (item.RegionList.Count == 1)
            {
                item.Region = item.RegionList[0] + ";;";
            }
            else if (item.RegionList.Count == 2)
            {
                item.Region = item.RegionList[0] + ";" + item.RegionList[1] + ";";
            }
            else if (item.RegionList.Count == 3)
            {
                item.Region = item.RegionList[0] + ";" + item.RegionList[1] + ";" + item.RegionList[2];
            }

            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.Update(item);

            if (appealInfoDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(appealInfoDTO);
        }
        [HttpDelete("appealInfoDetailDelete/{id}")]
        public async Task<IActionResult> appealInfoDetailDelete(int id)
        {
            List<AppealInfoDetailDto> appealInfoDTO = await _appealInfodetail.Delete(id);
            _appealInfoBLL.UpdateDate(id);

            return Ok(appealInfoDTO);
        }
    }
}
