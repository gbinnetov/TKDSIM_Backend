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
    public class EfEnumValueDal : EfEntityRepositoryBase<EnumValue, TKDSIMDBContext>, IEfEnumValueDal
    {
        public async Task<List<EnumValueDTO>> EnumValueJoinEnumGetAll()
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from ev in context.EnumValues
                             join e in context.Enums on ev.E_ID equals e.E_ID
                             where ev.DeleteDate == null
                             select new EnumValueDTO
                             {
                                DeleteDate = ev.DeleteDate,
                                EV_ID = ev.EV_ID,
                                E_ID = ev.E_ID,
                                EnumValue = e.Val,
                                InsertDate = ev.InsertDate,
                                UpadateDate = ev.UpadateDate,
                                Value = ev.Value
                             };
                return await result.ToListAsync();
            }
        }
        public async Task<List<EnumValueDTO>> EnumValueByEnumID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from ev in context.EnumValues
                             join e in context.Enums on ev.E_ID equals e.E_ID
                             where ev.DeleteDate == null && ev.E_ID == id
                             select new EnumValueDTO
                             {
                                 DeleteDate = ev.DeleteDate,
                                 EV_ID = ev.EV_ID,
                                 E_ID = ev.E_ID,
                                 EnumValue = e.Val,
                                 InsertDate = ev.InsertDate,
                                 UpadateDate = ev.UpadateDate,
                                 Value = ev.Value
                             };
                return await result.ToListAsync();
            }
        }
    }
}
