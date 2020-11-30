using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IMissingDocsBLL
    {
        Task<List<MissingDocsDTO>> Add(MissingDocsDTO item);
        void Delete(int id);
        Task<MissingDocsDTO> GetByID(decimal id);
        Task<List<MissingDocsDTO>> GetByAppealInfoID(decimal id);
        Task<List<MissingDocsDTO>> GetList();
    }
}
