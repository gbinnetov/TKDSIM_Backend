using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IWorkDoneTableBLL
    {
        Task<WorkDoneTableDTO> Add(WorkDoneTableDTO item);
        Task<WorkDoneTableDTO> Update(WorkDoneTableDTO item);
        void Delete(int id);
        Task<WorkDoneTableDTO> GetByID(decimal id);
        Task<List<WorkDoneTableDTO>> GetByAppealInfoID(decimal id);
        Task<List<WorkDoneTableDTO>> GetList();
    }
}
