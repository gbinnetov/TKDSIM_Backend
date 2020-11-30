using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Concrete;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore
{
    public class EfSubmittedDocsDal : EfEntityRepositoryBase<SubmittedDocs, TKDSIMDBContext>, IEfSubmittedDocsDal
    {
        public async Task<SubmittedDocsListDTO> SubmittedDocsJsonEnumVal(int id)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from s in context.SubmittedDocs
                             join ev in context.EnumValues on s.DocName equals ev.EV_ID
                             where s.DeleteDate == null && s.S_ID == id
                             select new SubmittedDocsListDTO
                             {
                                 S_ID = s.S_ID,
                                 A_ID = s.A_ID,
                                 DeleteDate = s.DeleteDate,
                                 DocName = ev.EV_ID,
                                 DeqkisNo = s.DeqkisNo,
                                 DocNameEnumVal = ev.Value,
                                 FilePath = s.FilePath,
                                 InsertDate = s.InsertDate,
                                 PresentationDate = s.PresentationDate,
                                 UpadateDate = s.UpadateDate,
                                 FileName=s.FileName
                             };
                return await result.FirstOrDefaultAsync();
            }
        }

        public async Task<List<SubmittedDocsListDTO>> SubmittedDocsJsonEnumValListByAppealID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from s in context.SubmittedDocs
                             join ev in context.EnumValues on s.DocName equals ev.EV_ID
                             where s.DeleteDate == null && s.A_ID==id
                             select new SubmittedDocsListDTO
                             {
                                 S_ID = s.S_ID,
                                 A_ID = s.A_ID,
                                 DeleteDate = s.DeleteDate,
                                 DocName = ev.EV_ID,
                                 DeqkisNo = s.DeqkisNo,
                                 DocNameEnumVal = ev.Value,
                                 //FilePath = s.FilePath,
                                 InsertDate = s.InsertDate,
                                 PresentationDate = s.PresentationDate,
                                 UpadateDate = s.UpadateDate,
                                 FileName=s.FileName
                             };
                return await result.ToListAsync();
            }
        }
    }
}
