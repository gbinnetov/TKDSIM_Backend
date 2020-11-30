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
    public class EfWorkDoneFormDal : EfEntityRepositoryBase<WorkDoneForm, TKDSIMDBContext>, IEfWorkDoneFormDal
    {
        public async Task<List<WorkDoneFormDTO>> GetAll()
        {

            using (var context = new TKDSIMDBContext())
            {
                var result = from w in context.WorkDoneForms
                             join e in context.EnumValues on w.PlaceStructureOrderStatus equals e.EV_ID into etemp
                             from e in etemp.DefaultIfEmpty()
                             where w.DeleteDate == null 
                             select new WorkDoneFormDTO
                             {
                                PlaceStructureOrderStatus = e == null ? 0 : e.EV_ID,
                                PlaceStructureOrderStatusName = e == null ? "" : e.Value,
                                A_ID = w.A_ID,
                                DeleteDate = w.DeleteDate,
                                InsertDate = w.InsertDate,
                                PlaceStructureOrderNo =w.PlaceStructureOrderNo,
                                PlaceStructureOrderNote = w.PlaceStructureOrderNote,
                                PlaceStructurePlanDeqkisNo = w.PlaceStructurePlanDeqkisNo,
                                UpadateDate = w.UpadateDate,
                                WF_ID = w.WF_ID
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<WorkDoneFormDTO>> GetByAppealID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from w in context.WorkDoneForms
                             join e in context.EnumValues on w.PlaceStructureOrderStatus equals e.EV_ID into etemp
                             from e in etemp.DefaultIfEmpty()
                             where w.DeleteDate == null && w.A_ID == id
                             select new WorkDoneFormDTO
                             {
                                 PlaceStructureOrderStatus = e == null ? 0 : e.EV_ID,
                                 PlaceStructureOrderStatusName = e == null ? "" : e.Value,
                                 A_ID = w.A_ID,
                                 DeleteDate = w.DeleteDate,
                                 InsertDate = w.InsertDate,
                                 PlaceStructureOrderNo = w.PlaceStructureOrderNo,
                                 PlaceStructureOrderNote = w.PlaceStructureOrderNote,
                                 PlaceStructurePlanDeqkisNo = w.PlaceStructurePlanDeqkisNo,
                                 UpadateDate = w.UpadateDate,
                                 WF_ID = w.WF_ID
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<WorkDoneFormDTO> GetByID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from w in context.WorkDoneForms
                             join e in context.EnumValues on w.PlaceStructureOrderStatus equals e.EV_ID into etemp
                             from e in etemp.DefaultIfEmpty()
                             where w.DeleteDate == null && w.WF_ID == id
                             select new WorkDoneFormDTO
                             {
                                 PlaceStructureOrderStatus = e == null ? 0 : e.EV_ID,
                                 PlaceStructureOrderStatusName = e == null ? "" : e.Value,
                                 A_ID = w.A_ID,
                                 DeleteDate = w.DeleteDate,
                                 InsertDate = w.InsertDate,
                                 PlaceStructureOrderNo = w.PlaceStructureOrderNo,
                                 PlaceStructureOrderNote = w.PlaceStructureOrderNote,
                                 PlaceStructurePlanDeqkisNo = w.PlaceStructurePlanDeqkisNo,
                                 UpadateDate = w.UpadateDate,
                                 WF_ID = w.WF_ID
                             };
                return await result.FirstOrDefaultAsync();
            }
        }
    }
}
