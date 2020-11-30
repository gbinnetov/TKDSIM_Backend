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
    public class MissingDocsController : ControllerBase
    {
        private readonly IMissingDocsBLL _MissingDocsBLL;
        public MissingDocsController(IMissingDocsBLL MissingDocsBLL)
        {
            _MissingDocsBLL = MissingDocsBLL;
        }

        [HttpGet("MissingDocsGetAll")]
        public async Task<IActionResult> MissingDocsGetAll()
        {

            List<MissingDocsDTO> MissingDocsDTO = await _MissingDocsBLL.GetList();

            return Ok(MissingDocsDTO);
        }

        [HttpGet("MissingDocsGetByID/{id}")]
        public async Task<IActionResult> MissingDocsGetByID(decimal id)
        {

            MissingDocsDTO MissingDocsDTO = await _MissingDocsBLL.GetByID(id);

            return Ok(MissingDocsDTO);
        }


        [HttpGet("MissingDocsGetByAppealInfoID/{id}")]
        public async Task<IActionResult> MissingDocsGetByAppealInfoID(decimal id)
        {

            List<MissingDocsDTO> MissingDocsDTO = await _MissingDocsBLL.GetByAppealInfoID(id);

            return Ok(MissingDocsDTO);
        }


        [HttpPost("MissingDocsInsert")]
        public async Task<IActionResult> MissingDocsInsert(MissingDocsDTO item)
        {

            List<MissingDocsDTO> MissingDocsDTO = await _MissingDocsBLL.Add(item);

            if (MissingDocsDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(MissingDocsDTO);
        }

        [HttpDelete("MissingDocsDelete/{id}")]
        public async Task<IActionResult> MissingDocsDelete(int id)
        {

            _MissingDocsBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
