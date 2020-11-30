using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface ISubmittedDocsBLL
    {
        Task<List<SubmittedDocsListDTO>> Add(SubmittedDocsDTO item);
        Task<SubmittedDocsListDTO> Update(SubmittedDocsDTO item);
        void Delete(int id);
        Task<List<SubmittedDocsListDTO>> SubmittedDocsJsonEnumValListByAppealID(int id);
        Task<SubmittedDocsListDTO> SubmittedDocsJsonEnumVal(int id);
        Task<SubmittedDocsListDTO> GetByID(decimal id);
        Task<string> GetByteArrayFromImage(IFormFile file);
        Task<List<SubmittedDocsListDTO>> GetByAppealInfoID(int id);
        Task<List<SubmittedDocsDTO>> GetList();
    }
}
