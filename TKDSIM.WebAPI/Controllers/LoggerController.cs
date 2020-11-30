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
    public class LoggerController : ControllerBase
    {
        private readonly ILoggerBLL _LoggerBLL;
        public LoggerController(ILoggerBLL LoggerBLL)
        {
            _LoggerBLL = LoggerBLL;
        }

        [HttpGet("LoggerGetAll")]
        public async Task<IActionResult> LoggerGetAll()
        {

            List<LoggerDTO> LoggerDTO = await _LoggerBLL.GetList();

            return Ok(LoggerDTO);
        }

        [HttpGet("LoggerGetByID/{id}")]
        public async Task<IActionResult> LoggerGetByID(decimal id)
        {

            LoggerDTO LoggerDTO = await _LoggerBLL.GetByID(id);

            return Ok(LoggerDTO);
        }

        [HttpPost("LoggerUpdate")]
        public async Task<IActionResult> LoggerUpdate(LoggerDTO item)
        {

            LoggerDTO LoggerDTO = await _LoggerBLL.Update(item);

            if (LoggerDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(LoggerDTO);
        }

        [HttpPost("LoggerInsert")]
        public async Task<IActionResult> LoggerInsert(LoggerDTO item)
        {

            LoggerDTO LoggerDTO = await _LoggerBLL.Add(item);

            if (LoggerDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(LoggerDTO);
        }

        [HttpDelete("LoggerDelete/{id}")]
        public async Task<IActionResult> LoggerDelete(int id)
        {

            _LoggerBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
