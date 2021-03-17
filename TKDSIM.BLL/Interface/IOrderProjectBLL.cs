using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IOrderProjectBLL
    {
        Task<List<OrderProjectDTO>> Add(OrderProjectDTO item);
        Task<List<OrderProjectDTO>> Update(OrderProjectDTO item);
        void Delete(int id);
        Task<OrderProjectDTO> GetByID(decimal id);
        Task<List<OrderProjectDTO>> GetByAppealInfoID(decimal id);
        Task<List<OrderProjectDTO>> GetList();
    }
}
