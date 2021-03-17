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
    public class EfOrderProjectDal : EfEntityRepositoryBase<OrderProject, TKDSIMDBContext>, IEfOrderProjectDal
    {
        public async Task<List<OrderProjectDTO>> OrderProjectsByAppealID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {

                var resultOrder = from ad in context.OrderProjects
                                  join OrderStatusEnum in context.EnumValues on ad.OrderStatus equals OrderStatusEnum.EV_ID into tempOrderStatusEnum
                                  from OrderStatusEnum in tempOrderStatusEnum.DefaultIfEmpty()
                                  where ad.DeleteDate == null && ad.A_ID == id
                                  select new OrderProjectDTO
                                  {
                                      DeleteDate = ad.DeleteDate,
                                      A_ID = ad.A_ID,
                                      DocumentNo = ad.DocumentNo,
                                      InsertDate = ad.InsertDate,
                                      OrderNo = ad.OrderNo,
                                      OrderStatusNote = ad.OrderStatusNote,
                                      O_ID = ad.O_ID,
                                      UpadateDate=ad.UpadateDate,
                                      OrderStatus = OrderStatusEnum == null ? 0 : OrderStatusEnum.EV_ID,
                                      OrderStatusName = OrderStatusEnum == null ? "" : OrderStatusEnum.Value

                                  };

                return await resultOrder.ToListAsync();
            }
        }

        public async Task<OrderProjectDTO> OrderProjectsByID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {

                var resultOrder = from ad in context.OrderProjects
                                  join OrderStatusEnum in context.EnumValues on ad.OrderStatus equals OrderStatusEnum.EV_ID into tempOrderStatusEnum
                                  from OrderStatusEnum in tempOrderStatusEnum.DefaultIfEmpty()
                                  where ad.DeleteDate == null && ad.O_ID == id
                                  select new OrderProjectDTO
                                  {
                                      DeleteDate = ad.DeleteDate,
                                      A_ID = ad.A_ID,
                                      DocumentNo = ad.DocumentNo,
                                      InsertDate = ad.InsertDate,
                                      OrderNo = ad.OrderNo,
                                      OrderStatusNote = ad.OrderStatusNote,
                                      O_ID = ad.O_ID,
                                      UpadateDate = ad.UpadateDate,
                                      OrderStatus = OrderStatusEnum == null ? 0 : OrderStatusEnum.EV_ID,
                                      OrderStatusName = OrderStatusEnum == null ? "" : OrderStatusEnum.Value

                                  };

                return await resultOrder.FirstOrDefaultAsync();
            }
        }

        public async Task<List<OrderProjectDTO>> OrderProjectsGetAll()
        {
            using (var context = new TKDSIMDBContext())
            {

                var resultOrder = from ad in context.OrderProjects
                                  join OrderStatusEnum in context.EnumValues on ad.OrderStatus equals OrderStatusEnum.EV_ID into tempOrderStatusEnum
                                  from OrderStatusEnum in tempOrderStatusEnum.DefaultIfEmpty()
                                  where ad.DeleteDate == null
                                  select new OrderProjectDTO
                                  {
                                      DeleteDate = ad.DeleteDate,
                                      A_ID = ad.A_ID,
                                      DocumentNo = ad.DocumentNo,
                                      InsertDate = ad.InsertDate,
                                      OrderNo = ad.OrderNo,
                                      OrderStatusNote = ad.OrderStatusNote,
                                      O_ID = ad.O_ID,
                                      UpadateDate = ad.UpadateDate,
                                      OrderStatus = OrderStatusEnum == null ? 0 : OrderStatusEnum.EV_ID,
                                      OrderStatusName = OrderStatusEnum == null ? "" : OrderStatusEnum.Value

                                  };

                return await resultOrder.ToListAsync();
            }
        }
    }
}
