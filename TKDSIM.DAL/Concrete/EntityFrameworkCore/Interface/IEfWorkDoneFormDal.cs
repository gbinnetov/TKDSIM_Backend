using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface
{
    public interface IEfWorkDoneFormDal : IEfEntityRepositoryBase<WorkDoneForm>
    {
        Task<List<WorkDoneFormDTO>> GetAll();
        Task<List<WorkDoneFormDTO>> GetByAppealID(int id);
        Task<WorkDoneFormDTO> GetByID(int id);

    }
}
