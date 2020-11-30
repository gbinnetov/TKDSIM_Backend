using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM;
using TKDSIM.DTO.DTO;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.Core.Mapping;
using TKDSIM.Entity.Entity;
using AutoMapper;
using System.Linq;
using System.Threading;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class AppealInfoBLL : IAppealInfoBLL
    {
        private readonly IEfAppealInfoDal _efAppealInfoDal;
        private readonly IEfAppealInfoDetailDal _efAppealInfoDetailDal;
        private readonly IEfOrderProjectDal _efOrderProjectDal;
        private readonly IMapper _mapper;

        public AppealInfoBLL(IEfAppealInfoDal efAppealInfoDal, IEfAppealInfoDetailDal efAppealInfoDetailDal, IEfOrderProjectDal efOrderProjectDal, IMapper mapper)
        {
            _efAppealInfoDetailDal = efAppealInfoDetailDal;
            _efAppealInfoDal = efAppealInfoDal;
            _efOrderProjectDal = efOrderProjectDal;
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

        public async Task<List<AppealInfoDTO>> AppealInfoSearch(AppealInfoDTO item)
        {
            List<AppealInfo> appealInfo = await _efAppealInfoDal.GetAll(x => x.DeleteDate == null);
            List<AppealInfoDTO> appealInfoResult = _mapper.Map<List<AppealInfoDTO>>(appealInfo);

            List<AppealInfoDetail> appealInfoDetail = await _efAppealInfoDetailDal.GetAll(x => x.DeleteDate == null);
            List<OrderProject> orderProjectDTO = await _efOrderProjectDal.GetAll(x => x.DeleteDate == null);


            if (item.AppealNo != null && item.AppealNo != "")
                appealInfoResult = appealInfoResult.Where(d => d.AppealNo == item.AppealNo).ToList();
            if (item.DeqkisNo != null && item.DeqkisNo != "")
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.DeqkisNo == item.DeqkisNo).ToList());
            }
            if (item.ApplicantName != null && item.ApplicantName != "")
                appealInfoResult = appealInfoResult.Where(d => d.ApplicantName == item.ApplicantName).ToList();
            if (item.GrandAreaSize != null && item.GrandAreaSize != "")
                appealInfoResult = appealInfoResult.Where(d => d.GrandAreaSize == item.GrandAreaSize).ToList();
            if (item.Region != "" && item.Region != null)
                appealInfoResult = appealInfoResult.Where(d => d.Region.Contains(item.Region)).ToList();
            if (item.GrandCategory != 0 && item.GrandCategory != null)
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.GrandCategory == item.GrandCategory).ToList());
            }
            if (item.WillChangeCategory != 0 && item.WillChangeCategory != null)
                appealInfoResult = appealInfoResult.Where(d => d.WillChangeCategory == item.WillChangeCategory).ToList();
            if (item.AppealReason != 0 && item.AppealReason != null)
                appealInfoResult = appealInfoResult.Where(d => d.AppealReason == item.AppealReason).ToList();
            if (item.StartDate != null)
                appealInfoResult = appealInfoResult.Where(d => d.InsertDate >= item.StartDate).ToList();
            if (item.EndDate != null)
                appealInfoResult = appealInfoResult.Where(d => d.InsertDate <= item.EndDate).ToList();
            if (item.PropertType != 0 && item.PropertType != null)
            {
                appealInfoResult = AppealInfoDetailSearch(appealInfoResult, appealInfoDetail.Where(x => x.PropertType == item.PropertType).ToList());
            }
            if (item.OrderStatus != 0 && item.OrderStatus != null)
            {
                appealInfoResult = OrderProjectsSearch(appealInfoResult, orderProjectDTO.Where(x => x.OrderStatus == item.OrderStatus).ToList());
            }

            List<AppealInfoDTO> appealInfoDTO = _mapper.Map<List<AppealInfoDTO>>(appealInfoResult);

            return appealInfoDTO;
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
    }
}
