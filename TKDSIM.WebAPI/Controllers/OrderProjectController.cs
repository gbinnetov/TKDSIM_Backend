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
        private readonly IAppealInfoBLL _appealInfoBLL;
        public OrderProjectController(IOrderProjectBLL OrderProjectBLL, IAppealInfoBLL appealInfoBLL)
        {
            _OrderProjectBLL = OrderProjectBLL;
            _appealInfoBLL = appealInfoBLL;
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

            List<OrderProjectDTO> OrderProjectDTO = await _OrderProjectBLL.Update(item);

            if (OrderProjectDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(OrderProjectDTO);
        }

        [HttpPost("OrderProjectInsert")]
        public async Task<IActionResult> OrderProjectInsert(OrderProjectDTO item)
        {

            List<OrderProjectDTO> OrderProjectDTO = await _OrderProjectBLL.Add(item);

            if (OrderProjectDTO == null)
                return Ok(HttpStatusCode.NotFound);

            _appealInfoBLL.UpdateDate(item.A_ID);

            return Ok(OrderProjectDTO);
        }

        [HttpDelete("OrderProjectDelete/{id}")]
        public async Task<IActionResult> OrderProjectDelete(int id)
        {

            _OrderProjectBLL.Delete(id);

            _appealInfoBLL.UpdateDate(id);

            return Ok(HttpStatusCode.OK);
        }
    }
}
