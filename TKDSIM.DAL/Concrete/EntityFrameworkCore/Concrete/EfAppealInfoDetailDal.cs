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

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Concrete
{
    public class EfAppealInfoDetailDal : EfEntityRepositoryBase<AppealInfoDetail, TKDSIMDBContext>, IEfAppealInfoDetailDal
    {
        public async Task<List<AppealInfoDetailDto>> AppealInfoDetailsGetAll()
        {
            using (var context = new TKDSIMDBContext())
            {

                var resultOrder = from ad in context.AppealInfoDetails
                                  join ep in context.EnumValues on ad.PropertType equals ep.EV_ID
                                  join ea in context.EnumValues on ad.AppealType equals ea.EV_ID
                                  join eg in context.EnumValues on ad.GrandCategory equals eg.EV_ID
                                  join eu in context.EnumValues on ad.UqodiyaGC equals eu.EV_ID into temp3
                                  from eu in temp3.DefaultIfEmpty()
                                  join appReasEnum in context.EnumValues on ad.AppealReason equals appReasEnum.EV_ID into tempappReasEnum
                                  from appReasEnum in tempappReasEnum.DefaultIfEmpty()

                                  join appApplicanEnum in context.EnumValues on ad.ApplicantType equals appApplicanEnum.EV_ID into tempappApplicanEnum
                                  from appApplicanEnum in tempappApplicanEnum.DefaultIfEmpty()

                                  join UqodyaWCCEnum in context.EnumValues on ad.UqodyaWCC equals UqodyaWCCEnum.EV_ID into tempUqodyaWCCEnum
                                  from UqodyaWCCEnum in tempUqodyaWCCEnum.DefaultIfEmpty()

                                  join WillChangeCategoryEnum in context.EnumValues on ad.WillChangeCategory equals WillChangeCategoryEnum.EV_ID into tempWillChangeCategoryEnum
                                  from WillChangeCategoryEnum in tempWillChangeCategoryEnum.DefaultIfEmpty()
                                  where ad.DeleteDate == null
                                  select new AppealInfoDetailDto
                                  {
                                      DeleteDate = ad.DeleteDate,
                                      A_ID = ad.A_ID,
                                      UqodiyaGC = eu == null ? 0 : eu.EV_ID,
                                      UqodyaGCName = eu == null ? "" : eu.Value,
                                      AppealType = ea.EV_ID,
                                      AppealTypeName = ea.Value,
                                      DeqkisNo = ad.DeqkisNo,
                                      GrandCategory = eg.EV_ID,
                                      GrandCategoryTypeName = eg.Value,
                                      ID = ad.ID,
                                      InsertDate = ad.InsertDate,
                                      PropertType = ep.EV_ID,
                                      PropertTypeName = ep.Value,
                                      UpadateDate = ad.UpadateDate,
                                      MainApplicantName = ad.MainApplicantName,
                                      AppealContent = ad.AppealContent,

                                      Address = ad.Address,
                                      AppealReason = appReasEnum == null ? 0 : appReasEnum.EV_ID,
                                      AppealReasonName = appReasEnum == null ? "" : appReasEnum.Value,

                                      ApplicantName = ad.ApplicantName,
                                      DeqkisDate = ad.DeqkisDate,


                                      ApplicantType = appApplicanEnum == null ? 0 : appApplicanEnum.EV_ID,
                                      ApplicantTypeName = appApplicanEnum == null ? "" : appApplicanEnum.Value,

                                      GrandAreaSize = ad.GrandAreaSize,
                                      IED_EV = ad.IED_EV,
                                      Region = ad.Region,



                                      UqodyaWCC = UqodyaWCCEnum == null ? 0 : UqodyaWCCEnum.EV_ID,
                                      UqodyaWCCName = UqodyaWCCEnum == null ? "" : UqodyaWCCEnum.Value,



                                      WillChangeCategory = WillChangeCategoryEnum == null ? 0 : WillChangeCategoryEnum.EV_ID,
                                      WillChangeCategoryName = WillChangeCategoryEnum == null ? "" : WillChangeCategoryEnum.Value,


                                  };

                return await resultOrder.ToListAsync();
            }
        }

        public async Task<List<AppealInfoDetailDto>> AppealInfoDetailsGetByAppealID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {

                var resultOrder = from ad in context.AppealInfoDetails
                                  join ep in context.EnumValues on ad.PropertType equals ep.EV_ID into epTemp
                                  from ep in epTemp.DefaultIfEmpty()

                                  join ea in context.EnumValues on ad.AppealType equals ea.EV_ID into eaTemp
                                  from ea in eaTemp.DefaultIfEmpty()

                                  join eg in context.EnumValues on ad.GrandCategory equals eg.EV_ID into egTemp
                                  from eg in egTemp.DefaultIfEmpty()

                                  join eu in context.EnumValues on ad.UqodiyaGC equals eu.EV_ID into temp3
                                  from eu in temp3.DefaultIfEmpty()

                                  join appReasEnum in context.EnumValues on ad.AppealReason equals appReasEnum.EV_ID into tempappReasEnum
                                  from appReasEnum in tempappReasEnum.DefaultIfEmpty()

                                  join appApplicanEnum in context.EnumValues on ad.ApplicantType equals appApplicanEnum.EV_ID into tempappApplicanEnum
                                  from appApplicanEnum in tempappApplicanEnum.DefaultIfEmpty()

                                  join UqodyaWCCEnum in context.EnumValues on ad.UqodyaWCC equals UqodyaWCCEnum.EV_ID into tempUqodyaWCCEnum
                                  from UqodyaWCCEnum in tempUqodyaWCCEnum.DefaultIfEmpty()

                                  join WillChangeCategoryEnum in context.EnumValues on ad.WillChangeCategory equals WillChangeCategoryEnum.EV_ID into tempWillChangeCategoryEnum
                                  from WillChangeCategoryEnum in tempWillChangeCategoryEnum.DefaultIfEmpty()
                                  where ad.DeleteDate == null && ad.A_ID == id
                                  select new AppealInfoDetailDto
                                  {
                                      DeleteDate = ad.DeleteDate,
                                      A_ID = ad.A_ID,
                                      UqodiyaGC = eu == null ? 0 : eu.EV_ID,
                                      UqodyaGCName = eu == null ? "" : eu.Value,
                                      AppealType = ea == null ? 0 : ea.EV_ID,
                                      AppealTypeName = ea == null ? "" : ea.Value,
                                      DeqkisNo = ad.DeqkisNo,
                                      GrandCategory = eg == null ? 0 : eg.EV_ID,
                                      GrandCategoryTypeName = eg == null ? "" : eg.Value,
                                      ID = ad.ID,
                                      InsertDate = ad.InsertDate,
                                      PropertType = ep == null ? 0 : ep.EV_ID,
                                      PropertTypeName = ep == null ? "" : ep.Value,
                                      UpadateDate = ad.UpadateDate,
                                      MainApplicantName = ad.MainApplicantName,
                                      DeqkisDate = ad.DeqkisDate,
                                      AppealContent = ad.AppealContent,


                                      Address = ad.Address,
                                      AppealReason = appReasEnum == null ? 0 : appReasEnum.EV_ID,
                                      AppealReasonName = appReasEnum == null ? "" : appReasEnum.Value,

                                      ApplicantName = ad.ApplicantName,


                                      ApplicantType = appApplicanEnum == null ? 0 : appApplicanEnum.EV_ID,
                                      ApplicantTypeName = appApplicanEnum == null ? "" : appApplicanEnum.Value,

                                      GrandAreaSize = ad.GrandAreaSize,
                                      IED_EV = ad.IED_EV,
                                      Region = ad.Region,



                                      UqodyaWCC = UqodyaWCCEnum == null ? 0 : UqodyaWCCEnum.EV_ID,
                                      UqodyaWCCName = UqodyaWCCEnum == null ? "" : UqodyaWCCEnum.Value,



                                      WillChangeCategory = WillChangeCategoryEnum == null ? 0 : WillChangeCategoryEnum.EV_ID,
                                      WillChangeCategoryName = WillChangeCategoryEnum == null ? "" : WillChangeCategoryEnum.Value,
                                  };

                return await resultOrder.ToListAsync();
            }
        }

        public async Task<AppealInfoDetailDto> AppealInfoDetailsGetByID(int id)
        {
            using (var context = new TKDSIMDBContext())
            {





                //var result = (from p in Products
                //              join o in Orders on p.ProductId equals o.ProductId into temp
                //              from t in temp.DefaultIfEmpty()
                //              select new
                //              {
                //                  p.ProductId,
                //                  OrderId = (int?)t.OrderId,
                //                  t.OrderNumber,
                //                  p.ProductName,
                //                  Quantity = (int?)t.Quantity,
                //                  t.TotalAmount,
                //                  t.OrderDate
                //              }).ToList();

                var resultOrder = from ad in context.AppealInfoDetails
                                  join ep in context.EnumValues on ad.PropertType equals ep.EV_ID
                                  join ea in context.EnumValues on ad.AppealType equals ea.EV_ID //into temp1
                                  join eg in context.EnumValues on ad.GrandCategory equals eg.EV_ID// into temp2
                                  join eu in context.EnumValues on ad.UqodiyaGC equals eu.EV_ID into temp3
                                  // from ea in temp1.DefaultIfEmpty()
                                  //  from eg in temp2.DefaultIfEmpty()
                                  from eu in temp3.DefaultIfEmpty()

                                  join appReasEnum in context.EnumValues on ad.AppealReason equals appReasEnum.EV_ID into tempappReasEnum
                                  from appReasEnum in tempappReasEnum.DefaultIfEmpty()

                                  join appApplicanEnum in context.EnumValues on ad.ApplicantType equals appApplicanEnum.EV_ID into tempappApplicanEnum
                                  from appApplicanEnum in tempappApplicanEnum.DefaultIfEmpty()

                                  join UqodyaWCCEnum in context.EnumValues on ad.UqodyaWCC equals UqodyaWCCEnum.EV_ID into tempUqodyaWCCEnum
                                  from UqodyaWCCEnum in tempUqodyaWCCEnum.DefaultIfEmpty()

                                  join WillChangeCategoryEnum in context.EnumValues on ad.WillChangeCategory equals WillChangeCategoryEnum.EV_ID into tempWillChangeCategoryEnum
                                  from WillChangeCategoryEnum in tempWillChangeCategoryEnum.DefaultIfEmpty()

                                  where ad.DeleteDate == null && ad.ID == id
                                  select new AppealInfoDetailDto
                                  {
                                      DeleteDate = ad.DeleteDate,
                                      A_ID = ad.A_ID,
                                      UqodiyaGC = eu == null ? 0 : eu.EV_ID,
                                      UqodyaGCName = eu == null ? "" : eu.Value,
                                      AppealType = ea == null ? 0 : ea.EV_ID,
                                      AppealTypeName = ea == null ? "" : ea.Value,
                                      DeqkisNo = ad.DeqkisNo,
                                      GrandCategory = eg == null ? 0 : eg.EV_ID,
                                      GrandCategoryTypeName = eg == null ? "" : eg.Value,
                                      ID = ad.ID,
                                      InsertDate = ad.InsertDate,
                                      PropertType = ep.EV_ID,
                                      PropertTypeName = ep.Value,
                                      UpadateDate = ad.UpadateDate,
                                      MainApplicantName = ad.MainApplicantName,
                                      DeqkisDate = ad.DeqkisDate,
                                      AppealContent = ad.AppealContent,


                                      Address = ad.Address,
                                      AppealReason = appReasEnum == null ? 0 : appReasEnum.EV_ID,
                                      AppealReasonName = appReasEnum == null ? "" : appReasEnum.Value,

                                      ApplicantName = ad.ApplicantName,


                                      ApplicantType = appApplicanEnum == null ? 0 : appApplicanEnum.EV_ID,
                                      ApplicantTypeName = appApplicanEnum == null ? "" : appApplicanEnum.Value,

                                      GrandAreaSize = ad.GrandAreaSize,
                                      IED_EV = ad.IED_EV,
                                      Region = ad.Region,



                                      UqodyaWCC = UqodyaWCCEnum == null ? 0 : UqodyaWCCEnum.EV_ID,
                                      UqodyaWCCName = UqodyaWCCEnum == null ? "" : UqodyaWCCEnum.Value,



                                      WillChangeCategory = WillChangeCategoryEnum == null ? 0 : WillChangeCategoryEnum.EV_ID,
                                      WillChangeCategoryName = WillChangeCategoryEnum == null ? "" : WillChangeCategoryEnum.Value,
                                  };
                return await resultOrder.FirstOrDefaultAsync();


                //var isResult = from ad in context.AppealInfoDetails where ad.ID == id select new AppealInfoDetailDto { UqodiyaGC = ad.UqodiyaGC };
                //AppealInfoDetailDto appealInfoDetailDto =  await isResult.FirstOrDefaultAsync();

                //if (appealInfoDetailDto != null)
                //{
                //    var resultOrder = from ad in context.AppealInfoDetails
                //                      join ep in context.EnumValues on ad.PropertType equals ep.EV_ID
                //                      join ea in context.EnumValues on ad.AppealType equals ea.EV_ID
                //                      join eg in context.EnumValues on ad.GrandCategory equals eg.EV_ID
                //                      join eu in context.EnumValues on ad.UqodiyaGC equals eu.EV_ID
                //                      where ad.DeleteDate == null && ad.ID == id
                //                      select new AppealInfoDetailDto
                //                      {
                //                          DeleteDate = ad.DeleteDate,
                //                          A_ID = ad.A_ID,
                //                          UqodiyaGC = eu.EV_ID,
                //                          UqodyaGCName = eu.Value,
                //                          AppealType = ea.EV_ID,
                //                          AppealTypeName = ea.Value,
                //                          DeqkisNo = ad.DeqkisNo,
                //                          GrandCategory = eg.EV_ID,
                //                          GrandCategoryTypeName = eg.Value,
                //                          ID = ad.ID,
                //                          InsertDate = ad.InsertDate,
                //                          PropertType = ep.EV_ID,
                //                          PropertTypeName = ep.Value,
                //                          UpadateDate = ad.UpadateDate
                //                      };
                //    return await resultOrder.FirstOrDefaultAsync();
                //}
                //else
                //{
                //    var resultOrder = from ad in context.AppealInfoDetails
                //                      join ep in context.EnumValues on ad.PropertType equals ep.EV_ID
                //                      join ea in context.EnumValues on ad.AppealType equals ea.EV_ID
                //                      join eg in context.EnumValues on ad.GrandCategory equals eg.EV_ID
                //                      where ad.DeleteDate == null && ad.ID == id
                //                      select new AppealInfoDetailDto
                //                      {
                //                          DeleteDate = ad.DeleteDate,
                //                          A_ID = ad.A_ID,
                //                          UqodiyaGC = 0,
                //                          UqodyaGCName = "",
                //                          AppealType = ea.EV_ID,
                //                          AppealTypeName = ea.Value,
                //                          DeqkisNo = ad.DeqkisNo,
                //                          GrandCategory = eg.EV_ID,
                //                          GrandCategoryTypeName = eg.Value,
                //                          ID = ad.ID,
                //                          InsertDate = ad.InsertDate,
                //                          PropertType = ep.EV_ID,
                //                          PropertTypeName = ep.Value,
                //                          UpadateDate = ad.UpadateDate
                //                      };
                //    return await resultOrder.FirstOrDefaultAsync();
                //}




            }
        }
    }
}
