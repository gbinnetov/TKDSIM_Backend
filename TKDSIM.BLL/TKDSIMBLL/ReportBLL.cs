using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class ReportBLL : IReportBLL
    {
        private readonly IEfAppealInfoDal _efAppealInfoDal;

        public ReportBLL(IEfAppealInfoDal efAppealInfoDal)
        {
            _efAppealInfoDal = efAppealInfoDal;
        }
        public async Task<List<ReportDto>> ReportPrint(int id)
        {
            return await _efAppealInfoDal.Report(id);
        }
    }
}
