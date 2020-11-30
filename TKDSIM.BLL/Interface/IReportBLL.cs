using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IReportBLL
    {
        Task<List<ReportDto>> ReportPrint(int id);
    }
}
