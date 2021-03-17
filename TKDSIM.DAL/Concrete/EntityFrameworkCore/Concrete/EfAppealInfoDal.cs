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
using Microsoft.EntityFrameworkCore.Internal;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore
{
    public class EfAppealInfoDal : EfEntityRepositoryBase<AppealInfo, TKDSIMDBContext>, IEfAppealInfoDal
    {


        public async Task<List<AppealInfoDTO>> AppealInfoSearch(AppealInfoDTO item)
        {
            using (var context = new TKDSIMDBContext())
            {

                if (item.OrderStatus != 0)
                {
                    var resultOrder = from a in context.AppealInfos
                                      join aid in context.AppealInfoDetails on a.A_ID equals aid.A_ID
                                      //join r in context.EnumValues on a.Region equals r.EV_ID
                                      join o in context.OrderProjects on a.A_ID equals o.A_ID
                                      where a.DeleteDate == null && o.OrderStatus == item.OrderStatus
                                      select new AppealInfoDTO
                                      {
                                          Address = aid.Address,
                                          AppealNo = a.AppealNo,
                                          AppealType = aid.AppealType,
                                          ApplicantName = aid.ApplicantName,
                                          AppealTypeName = aid.ApplicantName,
                                          ApplicantType = aid.ApplicantType,
                                          // RegionName = r.Value,
                                          Region = aid.Region,
                                          A_ID = a.A_ID,
                                          DeleteDate = a.DeleteDate,
                                          DeqkisNo = aid.DeqkisNo,
                                          GrandAreaSize = aid.GrandAreaSize,
                                          GrandCategory = aid.GrandCategory,
                                          IED_EV = aid.IED_EV,
                                          InsertDate = a.InsertDate,
                                          //  Planting = a.Planting,
                                          UpadateDate = a.UpadateDate,
                                          MainApplicantName = aid.MainApplicantName
                                          

                                      };
                    return await resultOrder.ToListAsync();

                }
                else
                {
                    var result = from a in context.AppealInfos
                                 join aid in context.AppealInfoDetails on a.A_ID equals aid.A_ID
                                 //   join r in context.EnumValues on a.Region equals r.EV_ID
                                 where a.DeleteDate == null
                                 select new AppealInfoDTO
                                 {
                                     Address = aid.Address,
                                     AppealNo = a.AppealNo,
                                     AppealType = aid.AppealType,
                                     ApplicantName = aid.ApplicantName,
                                     AppealTypeName = aid.ApplicantName,
                                     ApplicantType = aid.ApplicantType,
                                     //   RegionName = r.Value,
                                     Region = aid.Region,
                                     A_ID = a.A_ID,
                                     DeleteDate = a.DeleteDate,
                                     DeqkisNo = aid.DeqkisNo,
                                     GrandAreaSize = aid.GrandAreaSize,
                                     GrandCategory = aid.GrandCategory,
                                     IED_EV = aid.IED_EV,
                                     InsertDate = a.InsertDate,
                                     //Planting = a.Planting,
                                     UpadateDate = a.UpadateDate,
                                     MainApplicantName = aid.MainApplicantName

                                 };
                    return await result.ToListAsync();
                }
            }
        }

        private string RegionNameByID(string id)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from a in context.AdminUnits select new AdminUnitDto { Admin_Unit_ID = a.Admin_Unit_ID, Name = a.Name };

                List<AdminUnitDto> regionlist = result.ToList();

                string[] regionID = id.Split(';');


                string resultName = "";

                for (int i = 0; i < regionID.Count(); i++)
                {
                    if (regionID[i] != "")
                    {
                        resultName += regionlist.Find(q => q.Admin_Unit_ID == regionID[i]).Name + " ";
                    }

                }
                return resultName;
            }

        }

        public async Task<List<ReportDto>> Report(int id)
        {
            using (var context = new TKDSIMDBContext())
            {

                var result = from a in context.AppealInfos
                             join aid in context.AppealInfoDetails on a.A_ID equals aid.A_ID
                             join r in context.OrderProjects on a.A_ID equals r.A_ID into rtemp
                             from r in rtemp.DefaultIfEmpty()
                             join evGrandCategory in context.EnumValues on aid.GrandCategory equals evGrandCategory.EV_ID into evGrandCategorytemp
                             from evGrandCategory in evGrandCategorytemp.DefaultIfEmpty()
                             join evWillChangecat in context.EnumValues on aid.WillChangeCategory equals evWillChangecat.EV_ID into evWillChangecattemp
                             from evWillChangecat in evWillChangecattemp.DefaultIfEmpty()
                             join evAppealType in context.EnumValues on aid.AppealType equals evAppealType.EV_ID into evAppealTypetemp
                             from evAppealType in evAppealTypetemp.DefaultIfEmpty()
                             join evPropertType in context.EnumValues on aid.PropertType equals evPropertType.EV_ID into evPropertTypetemp
                             from evPropertType in evPropertTypetemp.DefaultIfEmpty()
                             join evOrderStatus in context.EnumValues on r.OrderStatus equals evOrderStatus.EV_ID into evOrderStatustemp
                             from evOrderStatus in evOrderStatustemp.DefaultIfEmpty()

                             where a.DeleteDate == null //&& a.A_ID == id
                             select new ReportDto
                             {
                                 Region = aid.Region,
                                 Address = aid.Address,
                                 ApplicantName = aid.ApplicantName,
                                 PropertType = evPropertType == null ? 0 : evPropertType.EV_ID,
                                 PropertyTypeName = evPropertType == null ? "" : evPropertType.Value,
                                 GrandAreaSize = aid.GrandAreaSize,
                                 //GrandCategoryType = a.GrandCategory,
                                 WillChangeCategory = evWillChangecat == null ? 0 : evWillChangecat.EV_ID,
                                 WillChangeCategoryName = evWillChangecat == null ? "" : evWillChangecat.Value,
                                 OrderStatus = evOrderStatus == null ? 0 : evOrderStatus.EV_ID,
                                 OrderStatusName = evOrderStatus == null ? "" : evOrderStatus.Value,
                                 OrderStatusNote = r == null ? "" : r.OrderStatusNote,
                                 MainApplicantName = aid.MainApplicantName

                             };

                List<ReportDto> listResult = new List<ReportDto>();

                foreach (var item in result)
                {
                    ReportDto reportDto = new ReportDto();

                    reportDto = item;

                    reportDto.Region = RegionNameByID(reportDto.Region);

                    listResult.Add(reportDto);

                }

                return listResult;




                //var resultOrderProject = (from a in context.OrderProjects where a.A_ID == id select new ReportDto { A_ID = a.A_ID }).ToList();

                //if (resultOrderProject.Count > 0)
                //{
                //    var result = from a in context.AppealInfos
                //                 join r in context.OrderProjects on a.A_ID equals r.A_ID
                //                 //join evRegion in context.EnumValues on a.Region equals evRegion.EV_ID
                //                 join evGrandCategory in context.EnumValues on a.GrandCategory equals evGrandCategory.EV_ID
                //                 join evWillChangecat in context.EnumValues on a.WillChangeCategory equals evWillChangecat.EV_ID
                //                 join evAppealType in context.EnumValues on a.AppealType equals evAppealType.EV_ID
                //                 join evPropertType in context.EnumValues on a.PropertType equals evPropertType.EV_ID
                //                 join evOrderStatus in context.EnumValues on r.OrderStatus equals evOrderStatus.EV_ID
                //                 where a.DeleteDate == null && a.A_ID == id
                //                 select new ReportDto
                //                 {
                //                     A_ID = a.A_ID,
                //                     Address = a.Address,
                //                     OrderStatus = evOrderStatus.EV_ID,
                //                     OrderStatusName = evOrderStatus.Value,
                //                     AppealType = evAppealType.EV_ID,
                //                     AppealTypeName = evAppealType.Value,
                //                     GrandCategoryType = evGrandCategory.EV_ID,
                //                     GrandCategoryTypeName = evGrandCategory.Value,
                //                     OrderNo = r.OrderNo,
                //                     OrderStatusNote = r.OrderStatusNote,
                //                     O_ID = r.O_ID,
                //                     PropertType = evPropertType.EV_ID,
                //                     PropertTypeName = evPropertType.Value,
                //                     Region = a.Region,
                //                     //    RegionName = evRegion.Value,
                //                     WillChangeCategory = evWillChangecat.EV_ID,
                //                     WillChangeCategoryName = evWillChangecat.Value
                //                 };
                //    return await result.ToListAsync();
                //}
                //else
                //{
                //    var result = from a in context.AppealInfos
                //                     //join evRegion in context.EnumValues on a.Region equals evRegion.EV_ID
                //                 join evGrandCategory in context.EnumValues on a.GrandCategory equals evGrandCategory.EV_ID
                //                 join evWillChangecat in context.EnumValues on a.WillChangeCategory equals evWillChangecat.EV_ID
                //                 join evAppealType in context.EnumValues on a.AppealType equals evAppealType.EV_ID
                //                 join evPropertType in context.EnumValues on a.PropertType equals evPropertType.EV_ID
                //                 where a.DeleteDate == null && a.A_ID == id
                //                 select new ReportDto
                //                 {
                //                     A_ID = a.A_ID,
                //                     Address = a.Address,
                //                     OrderStatus = 0,
                //                     OrderStatusName = "",
                //                     AppealType = evAppealType.EV_ID,
                //                     AppealTypeName = evAppealType.Value,
                //                     GrandCategoryType = evGrandCategory.EV_ID,
                //                     GrandCategoryTypeName = evGrandCategory.Value,
                //                     OrderNo = "",
                //                     OrderStatusNote = "",
                //                     O_ID = 0,
                //                     PropertType = evPropertType.EV_ID,
                //                     PropertTypeName = evPropertType.Value,
                //                     Region = a.Region,
                //                     // RegionName = evRegion.Value,
                //                     WillChangeCategory = evWillChangecat.EV_ID,
                //                     WillChangeCategoryName = evWillChangecat.Value
                //                 };
                //    return await result.ToListAsync();
                //}



            }
        }
    }
}
