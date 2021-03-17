using System;
using System.Collections.Generic;
using System.IO;
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
    public class SubmittedDocsController : ControllerBase
    {
        private readonly ISubmittedDocsBLL _SubmittedDocsBLL;
        private readonly IAppealInfoBLL _appealInfoBLL;
        public SubmittedDocsController(ISubmittedDocsBLL SubmittedDocsBLL, IAppealInfoBLL appealInfoBLL)
        {
            _SubmittedDocsBLL = SubmittedDocsBLL;
            _appealInfoBLL = appealInfoBLL;
        }

        [HttpGet("SubmittedDocsGetAll")]
        public async Task<IActionResult> SubmittedDocsGetAll()
        {

            List<SubmittedDocsDTO> SubmittedDocsDTO = await _SubmittedDocsBLL.GetList();

            return Ok(SubmittedDocsDTO);
        }

        [HttpGet("SubmittedDocsGetByID/{id}")]
        public async Task<IActionResult> SubmittedDocsGetByID(decimal id)
        {

            SubmittedDocsListDTO SubmittedDocsDTO = await _SubmittedDocsBLL.GetByID(id);

            return Ok(SubmittedDocsDTO);
        }
        [HttpGet("submittedDocsJsonEnumValListByAppealID/{id}")]
        public async Task<IActionResult> SubmittedDocsJsonEnumValListByAppealID(int id)
        {

            List<SubmittedDocsListDTO> SubmittedDocsDTO = await _SubmittedDocsBLL.SubmittedDocsJsonEnumValListByAppealID(id);

            return Ok(SubmittedDocsDTO);
        }
        [HttpGet("submittedDocsJsonEnumVal/{id}")]
        public async Task<IActionResult> SubmittedDocsJsonEnumVal(int id)
        {

            SubmittedDocsListDTO SubmittedDocsDTO = await _SubmittedDocsBLL.SubmittedDocsJsonEnumVal(id);

            return Ok(SubmittedDocsDTO);
        }

        [HttpGet("SubmittedDocsGetByAppealInfoID/{id}")]
        public async Task<IActionResult> SubmittedDocsGetByByAppealInfoID(decimal id)
        {

            List<SubmittedDocsListDTO> SubmittedDocsDTO = await _SubmittedDocsBLL.GetByAppealInfoID((int)id);

            return Ok(SubmittedDocsDTO);
        }

        [HttpPost("SubmittedDocsUpdate")]
        public async Task<IActionResult> SubmittedDocsUpdate([FromForm]SubmittedDocsDTO item)
        {

            SubmittedDocsListDTO SubmittedDocsDTO = await _SubmittedDocsBLL.Update(item);

            if (SubmittedDocsDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(SubmittedDocsDTO);
        }

        [HttpPost("SubmittedDocsInsert")]
        public async Task<IActionResult> SubmittedDocsInsert([FromForm] SubmittedDocsDTO item)
        {
            List<SubmittedDocsListDTO> SubmittedDocsDTO  = await _SubmittedDocsBLL.Add(item);
            
            if (SubmittedDocsDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(SubmittedDocsDTO);
        }

        [HttpDelete("SubmittedDocsDelete/{id}")]
        public async Task<IActionResult> SubmittedDocsDelete(int id)
        {

            _SubmittedDocsBLL.Delete(id);

            _appealInfoBLL.UpdateDate(id);

            return Ok(HttpStatusCode.OK);
        }

        [HttpGet("downloadFile/{id}")]
        public async Task<IActionResult> downloadFile(int id)
        {
            SubmittedDocsListDTO projectFileDtos = await _SubmittedDocsBLL.GetByID(id);
            if (projectFileDtos == null)
                return Content("filename not present");

            var path = Path.Combine(projectFileDtos.FilePath);
            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(path),
                Path.GetFileName(projectFileDtos.FileName));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".bacpac", "image/gif"},
                {".sql", "image/gif"},
                {".csv", "text/csv"},
                {".rar", "application/x-rar-compressed"},
                {".zip", "application/zip"},
            };
        }


    }
}
