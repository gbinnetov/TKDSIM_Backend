using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TKDSIM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// When request unauthorized
        /// </summary>
        /// <returns></returns>
        [HttpGet("Unauthorized")]
        public IActionResult UnauthorizedCustomErrorResponse()
        {
            return Unauthorized();
        }

        /// <summary>
        /// When route not found
        /// </summary>
        /// <returns></returns>
        [Route("NotFoundAPI")]
        public IActionResult NotFoundAPI()
        {
            return BadRequest("This action was not found.");
        }

        /// <summary>
        /// When user dont have access to action
        /// </summary>
        /// <returns></returns>
        [Route("Forbidden")]
        public IActionResult Forbidden()
        {
            return BadRequest("You do not have permission to this action.");
        }

        /// <summary>
        /// When request type is wrong
        /// </summary>
        /// <returns></returns>
        [Route("MethodNotAllowed")]
        public IActionResult MethodNotAllowed()
        {
            return BadRequest("Check your request type (POST/GET/PATCH/DELETE/PUT).");
        }
    }
}
