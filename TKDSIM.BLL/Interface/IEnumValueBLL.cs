using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IEnumValueBLL
    {
        Task<EnumValueDTO> Add(EnumValueDTO item);
        Task<EnumValueDTO> Update(EnumValueDTO item);
        void Delete(int item);
        Task<List<EnumValueDTO>> EnumValueJoinEnumGetAll();
        Task<List<EnumValueDTO>> EnumValueByEnumID(int id);
        Task<EnumValueDTO> GetByID(decimal id);
        Task<List<EnumValueDTO>> GetList();
    }
}
