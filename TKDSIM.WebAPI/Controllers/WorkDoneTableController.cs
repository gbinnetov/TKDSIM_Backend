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
    public class WorkDoneTableController : ControllerBase
    {
        private readonly IWorkDoneTableBLL _WorkDoneTableBLL;
        private readonly IAppealInfoBLL _appealInfoBLL;
        public WorkDoneTableController(IWorkDoneTableBLL WorkDoneTableBLL, IAppealInfoBLL appealInfoBLL)
        {
            _WorkDoneTableBLL = WorkDoneTableBLL;
            _appealInfoBLL = appealInfoBLL;
        }

        [HttpGet("WorkDoneTableGetAll")]
        public async Task<IActionResult> WorkDoneTableGetAll()
        {

            List<WorkDoneTableDTO> WorkDoneTableDTO = await _WorkDoneTableBLL.GetList();

            return Ok(WorkDoneTableDTO);
        }

        [HttpGet("WorkDoneTableGetByID/{id}")]
        public async Task<IActionResult> WorkDoneTableGetByID(decimal id)
        {

            WorkDoneTableDTO WorkDoneTableDTO = await _WorkDoneTableBLL.GetByID(id);

            return Ok(WorkDoneTableDTO);
        }

        [HttpGet("WorkDoneTableGetByAppealInfoID/{id}")]
        public async Task<IActionResult> WorkDoneTableGetByAppealInfoID(decimal id)
        {

            List<WorkDoneTableDTO> WorkDoneTableDTO = await _WorkDoneTableBLL.GetByAppealInfoID(id);

            return Ok(WorkDoneTableDTO);
        }

        [HttpPost("WorkDoneTableUpdate")]
        public async Task<IActionResult> WorkDoneTableUpdate(WorkDoneTableDTO item)
        {

            WorkDoneTableDTO WorkDoneTableDTO = await _WorkDoneTableBLL.Update(item);

            if (WorkDoneTableDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(WorkDoneTableDTO);
        }

        [HttpPost("WorkDoneTableInsert")]
        public async Task<IActionResult> WorkDoneTableInsert(WorkDoneTableDTO item)
        {

            WorkDoneTableDTO WorkDoneTableDTO = await _WorkDoneTableBLL.Add(item);

            if (WorkDoneTableDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(WorkDoneTableDTO);
        }

        [HttpDelete("WorkDoneTableDelete/{id}")]
        public async Task<IActionResult> WorkDoneTableDelete(int id)
        {

            _WorkDoneTableBLL.Delete(id);

            _appealInfoBLL.UpdateDate(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
