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
    public class EfMissingDocsDal : EfEntityRepositoryBase<MissingDocs, TKDSIMDBContext>, IEfMissingDocsDal
    {
        public async Task<List<MissingDocsDTO>> MissingDocByAppealID(int AppealID)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from m in context.MissingDocs
                             join ev in context.EnumValues on m.DocName equals ev.EV_ID
                             where m.DeleteDate == null && m.A_ID == AppealID
                             select new MissingDocsDTO
                             {
                                 M_ID = m.M_ID,
                                 DocNameEnumValueID = m.DocName,
                                 A_ID = m.A_ID,
                                 DeleteDate = m.DeleteDate,
                                 DocNameValue = ev.Value,
                                 InsertDate = m.InsertDate,
                                 UpadateDate = m.UpadateDate
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<MissingDocsDTO> MissingDocByID(int ID)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from m in context.MissingDocs
                             join ev in context.EnumValues on m.DocName equals ev.EV_ID
                             where m.DeleteDate == null && m.M_ID == ID
                             select new MissingDocsDTO
                             {
                                 M_ID = m.M_ID,
                                 DocNameEnumValueID = m.DocName,
                                 A_ID = m.A_ID,
                                 DeleteDate = m.DeleteDate,
                                 DocNameValue = ev.Value,
                                 InsertDate = m.InsertDate,
                                 UpadateDate = m.UpadateDate
                             };

                return await result.FirstOrDefaultAsync();
            }
        }
    }
}
