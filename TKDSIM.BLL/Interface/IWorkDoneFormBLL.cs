using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IWorkDoneFormBLL
    {
        Task<WorkDoneFormDTO> Add(WorkDoneFormDTO item);
        Task<WorkDoneFormDTO> Update(WorkDoneFormDTO item);
        void Delete(int id);
        Task<WorkDoneFormDTO> GetByID(decimal id);
        Task<List<WorkDoneFormDTO>> GetByAppealInfoID(decimal id);
        Task<List<WorkDoneFormDTO>> GetList();
    }
}
