using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface
{
    public interface IEfAppealInfoDetailDal : IEfEntityRepositoryBase<AppealInfoDetail>
    {
        Task<List<AppealInfoDetailDto>> AppealInfoDetailsGetByAppealID(int id);
        Task<AppealInfoDetailDto> AppealInfoDetailsGetByID(int id);
        Task<List<AppealInfoDetailDto>> AppealInfoDetailsGetAll();

    }
}
