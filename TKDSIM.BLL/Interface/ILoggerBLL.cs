using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface ILoggerBLL
    {
        Task<LoggerDTO> Add(LoggerDTO item);
        Task<LoggerDTO> Update(LoggerDTO item);
        void Delete(int id);
        Task<LoggerDTO> GetByID(decimal id);
        Task<List<LoggerDTO>> GetList();
    }
}
