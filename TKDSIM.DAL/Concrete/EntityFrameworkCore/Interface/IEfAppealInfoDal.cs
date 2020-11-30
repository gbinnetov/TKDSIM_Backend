using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface
{
    public interface IEfAppealInfoDal : IEfEntityRepositoryBase<AppealInfo>
    {
        Task<List<AppealInfoDTO>> AppealInfoSearch(AppealInfoDTO item);
        Task<List<ReportDto>> Report(int id);
    }
}
