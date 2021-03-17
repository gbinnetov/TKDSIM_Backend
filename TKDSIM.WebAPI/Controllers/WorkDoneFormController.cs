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
    public class WorkDoneFormController : ControllerBase
    {
        private readonly IWorkDoneFormBLL _WorkDoneFormBLL;
        private readonly IAppealInfoBLL _appealInfoBLL;
        public WorkDoneFormController(IWorkDoneFormBLL WorkDoneFormBLL, IAppealInfoBLL appealInfoBLL)
        {
            _WorkDoneFormBLL = WorkDoneFormBLL;
            _appealInfoBLL = appealInfoBLL;
        }

        [HttpGet("WorkDoneFormGetAll")]
        public async Task<IActionResult> WorkDoneFormGetAll()
        {

            List<WorkDoneFormDTO> WorkDoneFormDTO = await _WorkDoneFormBLL.GetList();

            return Ok(WorkDoneFormDTO);
        }

        [HttpGet("WorkDoneFormGetByID/{id}")]
        public async Task<IActionResult> WorkDoneFormGetByID(decimal id)
        {

            WorkDoneFormDTO WorkDoneFormDTO = await _WorkDoneFormBLL.GetByID(id);

            return Ok(WorkDoneFormDTO);
        }

        [HttpGet("WorkDoneFormGetByAppealInfoID/{id}")]
        public async Task<IActionResult> WorkDoneFormGetByAppealInfoID(decimal id)
        {

            List<WorkDoneFormDTO> WorkDoneFormDTO = await _WorkDoneFormBLL.GetByAppealInfoID(id);

            return Ok(WorkDoneFormDTO);
        }

        [HttpPost("WorkDoneFormUpdate")]
        public async Task<IActionResult> WorkDoneFormUpdate(WorkDoneFormDTO item)
        {

            WorkDoneFormDTO WorkDoneFormDTO = await _WorkDoneFormBLL.Update(item);

            if (WorkDoneFormDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(WorkDoneFormDTO);
        }

        [HttpPost("WorkDoneFormInsert")]
        public async Task<IActionResult> WorkDoneFormInsert(WorkDoneFormDTO item)
        {

            WorkDoneFormDTO WorkDoneFormDTO = await _WorkDoneFormBLL.Add(item);

            if (WorkDoneFormDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(WorkDoneFormDTO);
        }

        [HttpDelete("WorkDoneFormDelete/{id}")]
        public async Task<IActionResult> WorkDoneFormDelete(int id)
        {

            _WorkDoneFormBLL.Delete(id);

            _appealInfoBLL.UpdateDate(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
