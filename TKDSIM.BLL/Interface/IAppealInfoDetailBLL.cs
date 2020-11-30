using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IAppealInfoDetailBLL
    {
        Task<List<AppealInfoDetailDto>> GetList();
        Task<List<AppealInfoDetailDto>> GetListByAppealID(int appealID);
        Task<AppealInfoDetailDto> GetByID(int ID);
        Task<List<AppealInfoDetailDto>> Add(AppealInfoDetailDto item);
        Task<List<AppealInfoDetailDto>> Update(AppealInfoDetailDto item);
        Task<List<AppealInfoDetailDto>> Delete(int id);

    }
}
