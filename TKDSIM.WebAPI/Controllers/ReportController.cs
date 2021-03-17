using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TKDSIM.BLL.Interface;
using TKDSIM.DTO.DTO;

namespace TKDSIM.WebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBLL _reportBLL;
        private readonly IAppealInfoBLL _appealInfo;
        private readonly IAppealInfoDetailBLL _appealInfoDetail;
        private readonly IOrderProjectBLL _orderProjectBLL;
        private readonly IWorkDoneFormBLL _workDoneForm;
        private readonly IEnumValueBLL _enumValueBLL;
        private readonly IMissingDocsBLL _missingDocsBLL;
        private readonly IAdminUnitBLL _adminUnitBLL;

        public ReportController(IAdminUnitBLL adminUnitBLL, IMissingDocsBLL missingDocsBLL, IReportBLL reportBLL, IAppealInfoBLL appealInfo, IAppealInfoDetailBLL appealInfoDetail, IOrderProjectBLL orderProjectBLL, IWorkDoneFormBLL workDoneForm, IEnumValueBLL enumValueBLL)
        {
            _adminUnitBLL = adminUnitBLL;
            _missingDocsBLL = missingDocsBLL;
            _reportBLL = reportBLL;
            _appealInfo = appealInfo;
            _appealInfoDetail = appealInfoDetail;
            _orderProjectBLL = orderProjectBLL;
            _workDoneForm = workDoneForm;
            _enumValueBLL = enumValueBLL;
        }



        //[HttpGet("print/{id}")]
        //public async Task<IActionResult> Print(int id) {
        //    using (var workbook = new XLWorkbook())
        //    {
        //        var worksheet = workbook.Worksheets.Add("Hesabat");
        //        var currentRow = 1;
        //        worksheet.Cell(currentRow, 1).Value = "S/s";
        //        worksheet.Cell(currentRow, 2).Value = "Rayon";
        //        worksheet.Cell(currentRow, 3).Value = "Torpağın kateqoriyası";
        //        worksheet.Cell(currentRow, 4).Value = "Dəyişdiriləcək kateqoriya(təyinat)";
        //        worksheet.Cell(currentRow, 5).Value = "Ünvan";
        //        worksheet.Cell(currentRow, 6).Value = "Müraciətin növü";
        //        worksheet.Cell(currentRow, 7).Value = "Mülkiyyət növü";
        //        worksheet.Cell(currentRow, 8).Value = "Sərəncamın statusu";
        //        worksheet.Cell(currentRow, 9).Value = "Sərəncam lahiyəsinin nömrəsi";
        //        worksheet.Cell(currentRow, 10).Value = "Sərəncamın statusu barədə qeyd";

        //        List<ReportDto> reportList = await _reportBLL.ReportPrint(id);

        //        foreach (var item in reportList)
        //        {
        //            currentRow++;
        //            worksheet.Cell(currentRow, 1).Value = currentRow-1;
        //            worksheet.Cell(currentRow, 2).Value = item.RegionName;
        //            worksheet.Cell(currentRow, 3).Value = item.GrandCategoryTypeName;
        //            worksheet.Cell(currentRow, 4).Value = item.WillChangeCategoryName;
        //            worksheet.Cell(currentRow, 5).Value = item.Address;
        //            worksheet.Cell(currentRow, 6).Value = item.AppealTypeName;
        //            worksheet.Cell(currentRow, 7).Value = item.PropertTypeName;
        //            worksheet.Cell(currentRow, 8).Value = item.OrderStatusName;
        //            worksheet.Cell(currentRow, 9).Value = item.OrderNo;
        //            worksheet.Cell(currentRow, 10).Value = item.OrderStatusNote;
        //        }

        //        using (var stream = new MemoryStream())
        //        {
        //            workbook.SaveAs(stream);
        //            var content = stream.ToArray();

        //            return File(
        //                content,
        //                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //                "Hesabat.xlsx");
        //        }
        //    }



        private List<AppealInfoDetailDto> IncomingAppeal(List<AppealInfoDTO> appealInfoDTO, List<AppealInfoDetailDto> appealInfoDetailDTO)
        {

            List<AppealInfoDetailDto> groupByAppealID = new List<AppealInfoDetailDto>();

            for (int i = 0; i < appealInfoDTO.Count; i++)
            {
                AppealInfoDetailDto returnDto = new AppealInfoDetailDto();
                var resultByAppealID = appealInfoDetailDTO.Where(x => x.A_ID == appealInfoDTO[i].A_ID).ToList();
                if (resultByAppealID.Count > 0)
                {
                    returnDto = resultByAppealID[0];
                    for (int j = 0; j < resultByAppealID.Count; j++)
                    {

                        if (returnDto.InsertDate < resultByAppealID[j].InsertDate)
                        {
                            returnDto = resultByAppealID[j];
                        }
                    }
                    groupByAppealID.Add(returnDto);
                }

            }


            return groupByAppealID;
        }


        private List<AppealInfoDetailDto> IncomingAppeal(List<AppealInfoDetailDto> appealInfoDTO, List<AppealInfoDetailDto> appealInfoDetailDTO)
        {

            List<AppealInfoDetailDto> groupByAppealID = new List<AppealInfoDetailDto>();

            for (int i = 0; i < appealInfoDTO.Count; i++)
            {
                AppealInfoDetailDto returnDto = new AppealInfoDetailDto();
                var resultByAppealID = appealInfoDetailDTO.Where(x => x.A_ID == appealInfoDTO[i].A_ID).ToList();
                if (resultByAppealID.Count > 0)
                {
                    returnDto = resultByAppealID[0];
                    for (int j = 0; j < resultByAppealID.Count; j++)
                    {

                        if (returnDto.InsertDate < resultByAppealID[j].InsertDate)
                        {
                            returnDto = resultByAppealID[j];
                        }
                    }
                    groupByAppealID.Add(returnDto);
                }

            }


            return groupByAppealID;
        }



        private List<AppealInfoDTO> IncomingAppealSize(List<AppealInfoDTO> appealInfoDTO, List<AppealInfoDetailDto> appealInfoDetailDTO)
        {

            List<AppealInfoDTO> groupByAppealID = new List<AppealInfoDTO>();

            if (appealInfoDetailDTO.Count() > 0)
            {
                for (int i = 0; i < appealInfoDTO.Count; i++)
                {
                    AppealInfoDetailDto returnDto = new AppealInfoDetailDto();

                    var resultByAppealID = appealInfoDetailDTO.Where(x => x.A_ID == appealInfoDTO[i].A_ID).ToList();
                    if (resultByAppealID.Count > 0)
                    {
                        returnDto = resultByAppealID[0];
                        for (int j = 0; j < resultByAppealID.Count; j++)
                        {
                            if (returnDto.UpadateDate != null)
                            {
                                if (returnDto.InsertDate < resultByAppealID[j].InsertDate)
                                {
                                    returnDto = resultByAppealID[j];

                                }
                            }
                            else
                            {
                                returnDto = resultByAppealID[j];
                            }

                        }
                        AppealInfoDTO returnAppealDto = appealInfoDTO.Where(x => x.A_ID == returnDto.A_ID).FirstOrDefault();
                        returnAppealDto.GrandAreaSize = returnDto.GrandAreaSize == "" ? "0" : returnDto.GrandAreaSize;
                        groupByAppealID.Add(returnAppealDto);
                    }
                }
            }
            return groupByAppealID;
        }

        private List<WorkDoneFormDTO> getWorkDonefrom(List<AppealInfoDTO> appealInfos, List<WorkDoneFormDTO> workDoneForms)
        {

            if (appealInfos != null && workDoneForms != null)
            {
                List<WorkDoneFormDTO> dto = new List<WorkDoneFormDTO>();

                for (int i = 0; i < appealInfos.Count; i++)
                {
                    WorkDoneFormDTO item = new WorkDoneFormDTO();
                    var resultByAppealID = workDoneForms.Where(x => x.A_ID == appealInfos[i].A_ID).ToList();
                    if (resultByAppealID.Count > 0)
                    {
                        item = resultByAppealID[0];
                        for (int j = 0; j < resultByAppealID.Count; j++)
                        {

                            if (item.InsertDate < resultByAppealID[j].InsertDate)
                            {
                                item = resultByAppealID[j];
                            }
                        }
                        dto.Add(item);
                    }
                }
                return dto;
            }

            return null;

        }

        private List<OrderProjectDTO> getOrderProject(List<AppealInfoDTO> appealInfos, List<OrderProjectDTO> orderProjects)
        {
            if (appealInfos != null && orderProjects != null)
            {
                List<OrderProjectDTO> dto = new List<OrderProjectDTO>();

                for (int i = 0; i < appealInfos.Count; i++)
                {
                    OrderProjectDTO item = new OrderProjectDTO();
                    var resultByAppealID = orderProjects.Where(x => x.A_ID == appealInfos[i].A_ID).ToList();
                    if (resultByAppealID.Count > 0)
                    {
                        item = resultByAppealID[0];
                        for (int j = 0; j < resultByAppealID.Count; j++)
                        {

                            if (item.InsertDate < resultByAppealID[j].InsertDate)
                            {
                                item = resultByAppealID[j];
                            }
                        }
                        dto.Add(item);
                    }
                }
                return dto;
            }
            return null;
        }



        [HttpGet("reportAll")]
        public async Task<IActionResult> ReportAll()
        {
            List<AppealInfoDTO> appealInfoDTO = await _appealInfo.GetList();
            List<AppealInfoDetailDto> appealInfoDetailDTO = await _appealInfoDetail.GetList();
            List<OrderProjectDTO> orderProjectDTO = await _orderProjectBLL.GetList();
            List<WorkDoneFormDTO> workDoneFormDTO = await _workDoneForm.GetList();


            List<AppealInfoDetailDto> groupByAppealID = IncomingAppeal(appealInfoDTO, appealInfoDetailDTO);



            ReportAllDto reportAllDto = new ReportAllDto();
            reportAllDto.EntAppealStateCount = groupByAppealID.Where(x => x.PropertType == 13).Count().ToString();
            reportAllDto.EntAppealMunicipalityCount = groupByAppealID.Where(x => x.PropertType == 14).Count().ToString();
            reportAllDto.EntAppealPhysicalAndLegalCount = groupByAppealID.Where(x => x.PropertType == 15).Count().ToString();




            reportAllDto.AppealReasonStateNeedCount1 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 141).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 13).ToList()).Count().ToString();
            reportAllDto.AppealReasonStateNeedCount2 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 141).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 14).ToList()).Count().ToString();
            reportAllDto.AppealReasonStateNeedCount3 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 141).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 15).ToList()).Count().ToString();

            reportAllDto.AppealReasonOtherCount1 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 108).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 13).ToList()).Count().ToString();
            reportAllDto.AppealReasonOtherCount2 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 108).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 14).ToList()).Count().ToString();
            reportAllDto.AppealReasonOtherCount3 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 108).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 15).ToList()).Count().ToString();

            reportAllDto.AppealReasonOwnershipCount1 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 107).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 13).ToList()).Count().ToString();
            reportAllDto.AppealReasonOwnershipCount2 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 107).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 14).ToList()).Count().ToString();
            reportAllDto.AppealReasonOwnershipCount3 = IncomingAppeal(groupByAppealID.Where(x => x.AppealReason == 107).ToList(), appealInfoDetailDTO.Where(x => x.PropertType == 15).ToList()).Count().ToString();

            //AppealInfoDTO landArea1 = IncomingAppealSize(appealInfoDTO, appealInfoDetailDTO.Where(x => x.PropertType == 13).ToList()).GroupBy(x => x.PropertType == 13).Select(cl => new AppealInfoDTO { GrandAreaSize = cl.Sum(c => Convert.ToDecimal(c.GrandAreaSize)).ToString() }).FirstOrDefault()
            //    , landArea2 = IncomingAppealSize(appealInfoDTO, appealInfoDetailDTO.Where(x => x.PropertType == 14).ToList()).GroupBy(x => x.PropertType == 14).Select(cl => new AppealInfoDTO { GrandAreaSize = cl.Sum(c => Convert.ToDecimal(c.GrandAreaSize)).ToString() }).FirstOrDefault()
            //    , landArea3 = IncomingAppealSize(appealInfoDTO, appealInfoDetailDTO.Where(x => x.PropertType == 15).ToList()).GroupBy(x => x.PropertType == 15).Select(cl => new AppealInfoDTO { GrandAreaSize = cl.Sum(c => Convert.ToDecimal(c.GrandAreaSize)).ToString() }).FirstOrDefault();

            decimal landArea1 = 0
            , landArea2 = 0
            , landArea3 = 0;



            for (int i = 0; i < groupByAppealID.Count; i++)
            {

                if (groupByAppealID[i].GrandAreaSize == "")
                {
                    groupByAppealID[i].GrandAreaSize = "0";
                }

                if (groupByAppealID[i].GrandAreaSize != null)
                {
                    if (groupByAppealID[i].GrandAreaSize.IndexOf(",") > 0)
                    {
                        groupByAppealID[i].GrandAreaSize = groupByAppealID[i].GrandAreaSize.Replace(",", ".");
                    }
                }

               



                if (groupByAppealID[i].PropertType == 13)
                {
                    landArea1 += Convert.ToDecimal(groupByAppealID[i].GrandAreaSize);
                }
                else if (groupByAppealID[i].PropertType == 14)
                {
                    landArea2 += Convert.ToDecimal(groupByAppealID[i].GrandAreaSize);
                }
                else if (groupByAppealID[i].PropertType == 15)
                {
                    landArea3 += Convert.ToDecimal(groupByAppealID[i].GrandAreaSize);
                }

            }




            reportAllDto.LandArea1 = landArea1.ToString();
            reportAllDto.LandArea2 = landArea2.ToString();
            reportAllDto.LandArea3 = landArea3.ToString();


            List<AppealInfoDTO> appealInfoLandUsePlan1 = IncomingAppealSize(appealInfoDTO, appealInfoDetailDTO.Where(x => x.PropertType == 13).ToList()),
                appealInfoLandUsePlan2 = IncomingAppealSize(appealInfoDTO, appealInfoDetailDTO.Where(x => x.PropertType == 14).ToList()),
                appealInfoLandUsePlan3 = IncomingAppealSize(appealInfoDTO, appealInfoDetailDTO.Where(x => x.PropertType == 15).ToList());

            reportAllDto.LandUsePlanReadyByStateCount = getWorkDonefrom(appealInfoLandUsePlan1, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 142).ToList()).Count().ToString();
            reportAllDto.LandUsePlanReadyByMunicipalityCount = getWorkDonefrom(appealInfoLandUsePlan2, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 142).ToList()).Count().ToString();
            reportAllDto.LandUsePlanReadyByPhysicalAndLegalCount = getWorkDonefrom(appealInfoLandUsePlan3, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 142).ToList()).Count().ToString();

            reportAllDto.LandUsePlanNotReadyByStateCount = getWorkDonefrom(appealInfoLandUsePlan1, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 143).ToList()).Count().ToString();
            reportAllDto.LandUsePlanNotReadyByMunicipalityCount = getWorkDonefrom(appealInfoLandUsePlan1, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 143).ToList()).Count().ToString();
            reportAllDto.LandUsePlanNotReadyByPhysicalAndLegalCount = getWorkDonefrom(appealInfoLandUsePlan1, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 143).ToList()).Count().ToString();

            reportAllDto.LandUsePlanNoOrderByStateCount = getWorkDonefrom(appealInfoLandUsePlan1, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 181).ToList()).Count().ToString();
            reportAllDto.LandUsePlanNoOrderByMunicipalityCount = getWorkDonefrom(appealInfoLandUsePlan2, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 181).ToList()).Count().ToString();
            reportAllDto.LandUsePlanNoOrderByPhysicalAndLegalCount = getWorkDonefrom(appealInfoLandUsePlan3, workDoneFormDTO.Where(x => x.PlaceStructureOrderStatus == 181).ToList()).Count().ToString();

            reportAllDto.NKStatusApprovedByStateCount = getOrderProject(appealInfoLandUsePlan1, orderProjectDTO.Where(x => x.OrderStatus == 139).ToList()).Count().ToString();
            reportAllDto.NKStatusApprovedByMunicipalityCount = getOrderProject(appealInfoLandUsePlan2, orderProjectDTO.Where(x => x.OrderStatus == 139).ToList()).Count().ToString();
            reportAllDto.NKStatusApprovedByPhysicalAndLegalCount = getOrderProject(appealInfoLandUsePlan3, orderProjectDTO.Where(x => x.OrderStatus == 139).ToList()).Count().ToString();

            reportAllDto.NKStatusConsideredByStateCount = getOrderProject(appealInfoLandUsePlan1, orderProjectDTO.Where(x => x.OrderStatus == 137).ToList()).Count().ToString();
            reportAllDto.NKStatusConsideredByMunicipalityCount = getOrderProject(appealInfoLandUsePlan2, orderProjectDTO.Where(x => x.OrderStatus == 137).ToList()).Count().ToString();
            reportAllDto.NKStatusConsideredByPhysicalAndLegalCount = getOrderProject(appealInfoLandUsePlan3, orderProjectDTO.Where(x => x.OrderStatus == 137).ToList()).Count().ToString();

            reportAllDto.NKStatusRefusedByStateCount = getOrderProject(appealInfoLandUsePlan1, orderProjectDTO.Where(x => x.OrderStatus == 138).ToList()).Count().ToString();
            reportAllDto.NKStatusRefusedByMunicipalityCount = getOrderProject(appealInfoLandUsePlan2, orderProjectDTO.Where(x => x.OrderStatus == 138).ToList()).Count().ToString();
            reportAllDto.NKStatusRefusedByPhysicalAndLegalCount = getOrderProject(appealInfoLandUsePlan3, orderProjectDTO.Where(x => x.OrderStatus == 138).ToList()).Count().ToString();

            reportAllDto.ExaminedByStateCount = (int.Parse(reportAllDto.EntAppealStateCount) - (int.Parse(reportAllDto.NKStatusApprovedByStateCount) + int.Parse(reportAllDto.NKStatusConsideredByStateCount) + int.Parse(reportAllDto.NKStatusRefusedByStateCount))).ToString();
            reportAllDto.ExaminedByMunicipalityCount = (int.Parse(reportAllDto.EntAppealMunicipalityCount) - (int.Parse(reportAllDto.NKStatusApprovedByMunicipalityCount) + int.Parse(reportAllDto.NKStatusConsideredByMunicipalityCount) + int.Parse(reportAllDto.NKStatusRefusedByMunicipalityCount))).ToString();
            reportAllDto.ExaminedByPhysicalAndLegalCount = (int.Parse(reportAllDto.EntAppealPhysicalAndLegalCount) - (int.Parse(reportAllDto.NKStatusApprovedByPhysicalAndLegalCount) + int.Parse(reportAllDto.NKStatusConsideredByPhysicalAndLegalCount) + int.Parse(reportAllDto.NKStatusRefusedByPhysicalAndLegalCount))).ToString();


            return Ok(reportAllDto);
        }


        private List<AppealInfoDetailDto> IncomingAppeal(AppealInfoDTO appealInfoDTO, List<AppealInfoDetailDto> appealInfoDetailDTO)
        {

            List<AppealInfoDetailDto> groupByAppealID = new List<AppealInfoDetailDto>();


            AppealInfoDetailDto returnDto = new AppealInfoDetailDto();
            if (appealInfoDetailDTO.Count > 0)
            {
                returnDto = appealInfoDetailDTO[0];
                for (int j = 0; j < appealInfoDetailDTO.Count; j++)
                {

                    if (returnDto.InsertDate < appealInfoDetailDTO[j].InsertDate)
                    {
                        returnDto = appealInfoDetailDTO[j];
                    }
                }
                groupByAppealID.Add(returnDto);
            }


            return groupByAppealID;
        }

        private List<WorkDoneFormDTO> IncomingAppealWorkDoneFrom(List<WorkDoneFormDTO> workDoneForms)
        {

            List<WorkDoneFormDTO> groupByAppealID = new List<WorkDoneFormDTO>();


            WorkDoneFormDTO returnDto = new WorkDoneFormDTO();
            if (workDoneForms.Count > 0)
            {
                returnDto = workDoneForms[0];
                for (int j = 0; j < workDoneForms.Count; j++)
                {

                    if (returnDto.InsertDate < workDoneForms[j].InsertDate)
                    {
                        returnDto = workDoneForms[j];
                    }
                }
                groupByAppealID.Add(returnDto);
            }


            return groupByAppealID;
        }

        [HttpGet("appealInfoReport/{id}")]
        public async Task<IActionResult> Print(int id)
        {

            AppealInfoDTO appealInfoDTO = await _appealInfo.GetByID((decimal)id);
            List<AppealInfoDetailDto> appealInfoDetailDTO = await _appealInfoDetail.GetListByAppealID(id);
            List<OrderProjectDTO> orderProjectDTO = await _orderProjectBLL.GetByAppealInfoID((decimal)id);
            List<WorkDoneFormDTO> workDoneFormDTO = await _workDoneForm.GetByAppealInfoID(id);


            AppealInfoDetailDto appealInfoDetailDto = IncomingAppeal(appealInfoDTO, appealInfoDetailDTO).FirstOrDefault();

            ReportDto reportDto = new ReportDto();

            string[] regionSplit = appealInfoDetailDto.Region.Split(';');
            string region = "";
            for (int i = 0; i < regionSplit.Length; i++)
            {
                if (regionSplit[i] != "")
                {
                    region += _adminUnitBLL.AdminUnitByID(regionSplit[i]).Result.Name + " ";
                }
            }



            reportDto.Region = region;
            reportDto.Address = appealInfoDetailDto.Address;
            reportDto.ApplicantName = appealInfoDetailDto.ApplicantName;
            reportDto.MainApplicantName = appealInfoDetailDto.MainApplicantName;
            reportDto.PropertType = appealInfoDetailDto.PropertType;



            EnumValueDTO properType = await _enumValueBLL.GetByID(reportDto.PropertType);

            if (properType != null)
            {
                reportDto.PropertyTypeName = properType.Value;
            }

            reportDto.GrandAreaSize = appealInfoDetailDto.GrandAreaSize;



            reportDto.GrandCategoryTypeName = appealInfoDetailDto.GrandCategoryTypeName;

            if (appealInfoDetailDto.UqodiyaGC != 0 && appealInfoDetailDto.UqodiyaGC != null)
            {
                EnumValueDTO willchangeCateEnum = await _enumValueBLL.GetByID(appealInfoDetailDto.UqodiyaGC);

                reportDto.GrandCategoryTypeName += " (" + willchangeCateEnum.Value + ")";
            }


            EnumValueDTO willchangeCate = await _enumValueBLL.GetByID(appealInfoDetailDto.WillChangeCategory);

            if (willchangeCate != null)
            {
                reportDto.WillChangeCategoryName = willchangeCate.Value;

                if (appealInfoDetailDto.UqodyaWCC != 0 && appealInfoDetailDto.UqodyaWCC != null)
                {
                    EnumValueDTO willchangeCateEnum = await _enumValueBLL.GetByID(appealInfoDetailDto.UqodyaWCC);

                    reportDto.WillChangeCategoryName += " (" + willchangeCateEnum.Value + ")";
                }
            }



            reportDto.PlaceStructureOrderStatusName = "";
            reportDto.PlaceStructureOrderNote = "";
            if (IncomingAppealWorkDoneFrom(workDoneFormDTO).Count > 0)
            {
                reportDto.PlaceStructureOrderStatusName = IncomingAppealWorkDoneFrom(workDoneFormDTO).FirstOrDefault().PlaceStructureOrderStatusName;
                reportDto.PlaceStructureOrderNote = IncomingAppealWorkDoneFrom(workDoneFormDTO).FirstOrDefault().PlaceStructureOrderNote;
            }

            List<MissingDocsDTO> miss = await _missingDocsBLL.GetByAppealInfoID(id);

            string missingdoc = "";

            for (int i = 0; i < miss.Count; i++)
            {
                missingdoc += miss[i].DocNameValue + ", ";
            }

            reportDto.MissingDocs = missingdoc;

            EnumValueDTO enumValueDTO = new EnumValueDTO();

            if (orderProjectDTO.Count > 0)
            {
                enumValueDTO = await _enumValueBLL.GetByID(orderProjectDTO.FirstOrDefault().OrderStatus);
            }

            if (reportDto.OrderStatusName != null)
            {

                reportDto.OrderStatusName = enumValueDTO.Value;
                reportDto.OrderStatusNote = orderProjectDTO.OrderBy(x => x.InsertDate).FirstOrDefault().OrderStatusNote;
            }

            return Ok(reportDto);
        }
    }
}
