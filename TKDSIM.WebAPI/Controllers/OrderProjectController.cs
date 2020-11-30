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
    public class OrderProjectController : ControllerBase
    {
        private readonly IOrderProjectBLL _OrderProjectBLL;
        public OrderProjectController(IOrderProjectBLL OrderProjectBLL)
        {
            _OrderProjectBLL = OrderProjectBLL;
        }

        [HttpGet("OrderProjectGetAll")]
        public async Task<IActionResult> OrderProjectGetAll()
        {

            List<OrderProjectDTO> OrderProjectDTO = await _OrderProjectBLL.GetList();

            return Ok(OrderProjectDTO);
        }

        [HttpGet("OrderProjectGetByID/{id}")]
        public async Task<IActionResult> OrderProjectGetByID(decimal id)
        {

            OrderProjectDTO OrderProjectDTO = await _OrderProjectBLL.GetByID(id);

            return Ok(OrderProjectDTO);
        }

        [HttpGet("OrderProjectGetByAppealInfoID/{id}")]
        public async Task<IActionResult> OrderProjectGetByAppealInfoID(decimal id)
        {

            List<OrderProjectDTO> OrderProjectDTO = await _OrderProjectBLL.GetByAppealInfoID(id);

            return Ok(OrderProjectDTO);
        }

        [HttpPost("OrderProjectUpdate")]
        public async Task<IActionResult> OrderProjectUpdate(OrderProjectDTO item)
        {

            OrderProjectDTO OrderProjectDTO = await _OrderProjectBLL.Update(item);

            if (OrderProjectDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(OrderProjectDTO);
        }

        [HttpPost("OrderProjectInsert")]
        public async Task<IActionResult> OrderProjectInsert(OrderProjectDTO item)
        {

            OrderProjectDTO OrderProjectDTO = await _OrderProjectBLL.Add(item);

            if (OrderProjectDTO == null)
                return Ok(HttpStatusCode.NotFound);

            return Ok(OrderProjectDTO);
        }

        [HttpDelete("OrderProjectDelete/{id}")]
        public async Task<IActionResult> OrderProjectDelete(int id)
        {

            _OrderProjectBLL.Delete(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
