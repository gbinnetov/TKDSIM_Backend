using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class AppealInfoBLL : IAppealInfoBLL
    {
        private readonly IEfAppealInfoDal _efAppealInfoDal;
        private readonly IEfAppealInfoDetailDal _efAppealInfoDetailDal;
        private readonly IEfOrderProjectDal _efOrderProjectDal;
        private readonly IEfWorkDoneFormDal _efWorkDoneFormDal;
        private readonly IEfWorkDoneTableDal _efWorkDoneTableDal;
        private readonly IEfEnumValueDal _efEnumValueDal;
        private readonly IEfMissingDocsDal _efMissingDocsDal;
        private readonly IMapper _mapper;

        public AppealInfoBLL(IEfAppealInfoDal efAppealInfoDal, IEfWorkDoneTableDal efWorkDoneTableDal, IEfMissingDocsDal efMissingDocsDal, IEfAppealInfoDetailDal efAppealInfoDetailDal, IEfOrderProjectDal efOrderProjectDal, IEfWorkDoneFormDal efWorkDoneFormDal, IEfEnumValueDal efEnumValueDal, IMapper mapper)
        {
            _efAppealInfoDetailDal = efAppealInfoDetailDal;
            _efAppealInfoDal = efAppealInfoDal;
            _efOrderProjectDal = efOrderProjectDal;
            _efWorkDoneFormDal = efWorkDoneFormDal;
            _efEnumValueDal = efEnumValueDal;
            _efMissingDocsDal = efMissingDocsDal;
            _efWorkDoneTableDal = efWorkDoneTableDal;
            _mapper = mapper;
        }
        public async Task<AppealInfoDTO> Add(AppealInfoDTO item)
        {
            AppealInfo appealInfo = _mapper.Map<AppealInfo>(item);
            appealInfo.InsertDate = DateTime.Now;
            AppealInfo appealInfoResult = await _efAppealInfoDal.AddAsync(appealInfo);
            AppealInfoDTO appealInfoDTO = _mapper.Map<AppealInfoDTO>(appealInfoResult);
            return appealInfoDTO;
        }

        private List<AppealInfoDTO> AppealInfoDetailSearch(List<AppealInfoDTO> appealInfo, List<AppealInfoDetail> appealInfoDetailDto)
        {
            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();

            foreach (var item in appealInfo)
            {
                if (appealInfoDetailDto.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {
                    AppealInfoDetail infoDetailDto = appealInfoDetailDto.Where(x => x.A_ID == item.A_ID).FirstOrDefault();
                    item.DeqkisNo = infoDetailDto.DeqkisNo;
                    item.ApplicantName = infoDetailDto.ApplicantName;
                    item.GrandAreaSize = infoDetailDto.GrandAreaSize;
                    item.Region = infoDetailDto.Region;
                    item.GrandCategory = infoDetailDto.GrandCategory;
                    item.WillChangeCategory = infoDetailDto.WillChangeCategory;
                    item.AppealReason = infoDetailDto.AppealReason;
                    item.PropertType = infoDetailDto.PropertType;
                    item.Address = infoDetailDto.Address;
                    item.MainApplicantName = infoDetailDto.MainApplicantName;
                    item.AppealContent = infoDetailDto.AppealContent;
                    item.UqodyaGC = infoDetailDto.UqodiyaGC;
                    item.UqodyaWCC = infoDetailDto.UqodyaWCC;
                      
                    for (int i = 0; i < appealInfoDetailDto.Where(x => x.A_ID == item.A_ID).Count(); i++)
                    {
                        if (infoDetailDto.InsertDate < appealInfoDetailDto[i].InsertDate)
                        {
                            item.MainApplicantName = infoDetailDto.MainApplicantName;
                            item.Address = infoDetailDto.Address;
                            item.DeqkisNo = appealInfoDetailDto[0].DeqkisNo;
                            item.ApplicantName = appealInfoDetailDto[0].ApplicantName;
                            item.GrandAreaSize = appealInfoDetailDto[0].GrandAreaSize;
                            item.Region = appealInfoDetailDto[0].Region;
                            item.GrandCategory = appealInfoDetailDto[0].GrandCategory;
                            item.WillChangeCategory = appealInfoDetailDto[0].WillChangeCategory;
                            item.AppealReason = appealInfoDetailDto[0].AppealReason;
                            item.PropertType = appealInfoDetailDto[0].PropertType;
                            item.AppealContent = infoDetailDto.AppealContent;
                        }
                    }

                    appealInforetrun.Add(item);
                }
            }
            return appealInforetrun;
        }

        private List<AppealInfoDTO> OrderProjectsSearch(List<AppealInfoDTO> appealInfo, List<OrderProject> orderProjects)
        {

            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();
            foreach (var item in appealInfo)
            {
                if (orderProjects.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {
                    appealInforetrun.Add(item);
                }
            }
            return appealInforetrun;
        }

        private  List<AppealInfoDTO> WorkDoneFormSearch(List<AppealInfoDTO> appealInfo, List<WorkDoneForm> workDoneForms)
        {
            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();
            foreach (var item in appealInfo)
            {
                if (workDoneForms.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {
                    item.PlaceStructureOrderNo = workDoneForms.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().PlaceStructureOrderNo;
  
                    int enumvalid = Convert.ToInt32(workDoneForms.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().PlaceStructureOrderStatus);
                    item.PlaceStructureOrderStatusName = _efEnumValueDal.Get(x => x.EV_ID == enumvalid).Result.Value;
                    appealInforetrun.Add(item);
                }
            }
            return appealInforetrun;
        }

        private List<AppealInfoDTO> WorkDoneFormJoin(List<AppealInfoDTO> appealInfo, List<WorkDoneForm> workDoneForms)
        {
            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();
            foreach (var item in appealInfo)
            {
                if (workDoneForms.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {
                    item.PlaceStructureOrderNo = workDoneForms.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().PlaceStructureOrderNo;

                    int enumvalid = Convert.ToInt32(workDoneForms.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().PlaceStructureOrderStatus);
                    item.PlaceStructureOrderStatus = enumvalid;
                    if (enumvalid != 0)
                        item.PlaceStructureOrderStatusName = _efEnumValueDal.Get(x => x.EV_ID == enumvalid).Result.Value;
                    else
                        item.PlaceStructureOrderStatusName = null;

                }
                appealInforetrun.Add(item);
            }
            return appealInforetrun;
        }
        private List<AppealInfoDTO> OrderProjectsJoin(List<AppealInfoDTO> appealInfo, List<OrderProject> orderProjects)
        {

            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();
            foreach (var item in appealInfo)
            {
                if (orderProjects.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {
                    item.OrderNo = orderProjects.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().OrderNo;
                }
                appealInforetrun.Add(item);
            }
            return appealInforetrun;
        }

        private List<AppealInfoDTO> MissingDocsJoin(List<AppealInfoDTO> appealInfo, List<MissingDocs> missingDocs)
        {
            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();
            foreach (var item in appealInfo)
            {
                if (missingDocs.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {

                    int enumvalid = Convert.ToInt32(missingDocs.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().DocName);
                    item.MissingDocName = enumvalid;
                    item.MissingDocNameName = _efEnumValueDal.Get(x => x.EV_ID == enumvalid).Result.Value;

                }
                appealInforetrun.Add(item);
            }
            return appealInforetrun;
        }
        private List<AppealInfoDTO> WorkDoneTableJoin(List<AppealInfoDTO> appealInfo, List<WorkDoneTable> workDoneTables)
        {
            List<AppealInfoDTO> appealInforetrun = new List<AppealInfoDTO>();
            foreach (var item in appealInfo)
            {
                if (workDoneTables.Where(x => x.A_ID == item.A_ID).Count() > 0)
                {
                    item.LatterNo = workDoneTables.Where(x => x.A_ID == item.A_ID).OrderBy(x => x.InsertDate).FirstOrDefault().LatterNo;
                }
                appealInforetrun.Add(item);
            }
            return appealInforetrun;
        }


        public async Task<List<AppealInfoDTO>> AppealInfoSearch(AppealInfoDTO item)
        {
            List<AppealInfo> appealInfo = await _efAppealInfoDal.GetAll(x => x.DeleteDate == null);
            List<AppealInfoDTO> appealInfoResult = _mapper.Map<List<AppealInfoDTO>>(appealInfo);
            List<WorkDoneForm> workDoneForms = await _efWorkDoneFormDal.GetAll(x => x.DeleteDate == null);
            List<WorkDoneTable> workDoneTables = await _efWorkDoneTableDal.GetAll(x => x.DeleteDate == null);
            List<MissingDocs> missingDocs = await _efMissingDocsDal.GetAll(x => x.DeleteDate == null);

            List<AppealInfoDetail> appealInfoDetail = await _efAppealInfoDetailDal.GetAll(x => x.DeleteDate == null);
            List<OrderProject> orderProjectDTO = await _efOrderProjectDal.GetAll(x => x.DeleteDate == null);

            appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail);

            if (item.AppealNo != null && item.AppealNo != "")
                appealInfoResult = appealInfoResult.Where(d => d.AppealNo == item.AppealNo).ToList();
            if (item.DeqkisNo != null && item.DeqkisNo != "")///////////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.DeqkisNo == item.DeqkisNo).ToList());
            }
            if (item.ApplicantName != null && item.ApplicantName != "")//////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.ApplicantName == item.ApplicantName).ToList());

            }
            if (item.MainApplicantName != null && item.MainApplicantName != "")//////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.MainApplicantName == item.MainApplicantName).ToList());

            }
            if (item.GrandAreaSize != null && item.GrandAreaSize != "")///////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.GrandAreaSize == item.GrandAreaSize).ToList());
            }

            if (item.Region != "" && item.Region != null)//////////////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(d => d.Region.Contains(item.Region)).ToList());
            }

            if (item.GrandCategory != 0 && item.GrandCategory != null)////////////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.GrandCategory == item.GrandCategory).ToList());
            }
            if (item.WillChangeCategory != 0 && item.WillChangeCategory != null)//////////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.WillChangeCategory == item.WillChangeCategory).ToList());
            }

            if (item.AppealReason != 0 && item.AppealReason != null)//////////////////////////////////
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.AppealReason == item.AppealReason).ToList());
            }

            if (item.StartDate != null)////////////////////////////
            {
                appealInfoResult = appealInfoResult.Where(d => d.InsertDate >= item.StartDate).ToList();
            }

            if (item.EndDate != null)/////////////////////////////////
            {
                appealInfoResult = appealInfoResult.Where(d => d.InsertDate <= item.EndDate).ToList();
            }

            if (item.PropertType != 0 && item.PropertType != null)
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.PropertType == item.PropertType).ToList());
            }
            if (item.OrderStatus != 0 && item.OrderStatus != null)
            {
                appealInfoResult = OrderProjectsSearch(appealInfoResult, orderProjectDTO.Where(x => x.OrderStatus == item.OrderStatus).ToList());
            }
            if (item.PlaceStructureOrderStatus != 0 && item.PlaceStructureOrderStatus != null)
            {
                appealInfoResult = WorkDoneFormSearch(appealInfoResult, workDoneForms.Where(x => x.PlaceStructureOrderStatus == item.PlaceStructureOrderStatus).ToList());
            }
            appealInfoResult =  WorkDoneFormJoin(appealInfoResult, workDoneForms);
            appealInfoResult =  MissingDocsJoin(appealInfoResult, missingDocs);
            appealInfoResult = OrderProjectsJoin(appealInfoResult, orderProjectDTO);
            appealInfoResult = WorkDoneTableJoin(appealInfoResult, workDoneTables);

            return appealInfoResult;
        }

        public async void Delete(int id)
        {
            AppealInfo appealInfo = await _efAppealInfoDal.Get(d => d.A_ID == id && d.DeleteDate == null);
            appealInfo.DeleteDate = DateTime.Now;
            await _efAppealInfoDal.DeleteAsync(appealInfo);
        }

        public async Task<AppealInfoDTO> GetByID(decimal id)
        {
            AppealInfo appealInfo = await _efAppealInfoDal.Get(d => d.A_ID == id && d.DeleteDate == null);
            AppealInfoDTO appealInfoDTO = _mapper.Map<AppealInfoDTO>(appealInfo);
            return appealInfoDTO;
        }

        public async Task<List<AppealInfoDTO>> GetList()
        {
            List<AppealInfo> appealInfo = await _efAppealInfoDal.GetAll(x => x.DeleteDate == null);
            List<AppealInfoDTO> appealInfoDTO = _mapper.Map<List<AppealInfoDTO>>(appealInfo);
            return appealInfoDTO;
        }

        public async Task<AppealInfoDTO> Update(AppealInfoDTO item)
        {
            AppealInfo appealInfoGetID = await _efAppealInfoDal.Get(x => x.A_ID == item.A_ID);

            if (appealInfoGetID == null)
                return null;

            AppealInfo appealInfo = _mapper.Map<AppealInfo>(item);
            appealInfo.UpadateDate = DateTime.Now;
            appealInfo.InsertDate = appealInfoGetID.InsertDate;
            appealInfo.A_ID = appealInfo.A_ID;

            AppealInfo appealInfoResult = await _efAppealInfoDal.UpdateAsync(appealInfo);
            AppealInfoDTO appealInfoDTO = _mapper.Map<AppealInfoDTO>(appealInfoResult);
            return appealInfoDTO;
        }

        public async Task<AppealInfoDTO> UpdateDate(int id)
        {

            AppealInfo appealInfoGetID = await _efAppealInfoDal.Get(x => x.A_ID == id);

            if (appealInfoGetID == null)
                return null;

            appealInfoGetID.UpadateDate = DateTime.Now;

            AppealInfo appealInfoResult = await _efAppealInfoDal.UpdateAsync(appealInfoGetID);
            AppealInfoDTO appealInfoDTO = _mapper.Map<AppealInfoDTO>(appealInfoResult);
            return appealInfoDTO;
        }
    }
}
