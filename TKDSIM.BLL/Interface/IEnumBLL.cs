using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IEnumBLL
    {
        Task<EnumDTO> Add(EnumDTO item);
        Task<EnumDTO> Update(EnumDTO item);
        void Delete(int id);
        Task<EnumDTO> GetByID(decimal id);
        Task<List<EnumDTO>> GetList();
    }
}
