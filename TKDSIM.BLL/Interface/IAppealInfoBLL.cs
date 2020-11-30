using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IAppealInfoBLL
    {
        Task<AppealInfoDTO> Add(AppealInfoDTO item);
        Task<AppealInfoDTO> Update(AppealInfoDTO item);
        void Delete(int id);
        Task<AppealInfoDTO> GetByID(decimal id);
        Task<List<AppealInfoDTO>> AppealInfoSearch(AppealInfoDTO item);
        Task<List<AppealInfoDTO>> GetList();
    }
}
