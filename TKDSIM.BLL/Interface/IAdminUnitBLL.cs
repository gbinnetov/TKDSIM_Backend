using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IAdminUnitBLL
    {
        Task<List<AdminUnitDto>> AdminUnitAll();
        Task<AdminUnitDto> AdminUnitByID(string id);
        Task<List<AdminUnitDto>> AdminUnitChildByID(string id);
        Task<List<AdminUnitDto>> AdminUnitByCode(string code);
        Task<List<AdminUnitDto>> AdminUnitByParentCode(string parentCode);
        Task<List<AdminUnitDto>> AdminUnitChildByCode(string code);

    }
}
