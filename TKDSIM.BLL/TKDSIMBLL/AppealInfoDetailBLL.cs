using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class AppealInfoDetailBLL : IAppealInfoDetailBLL
    {
        private readonly IEfAppealInfoDetailDal _appealInfoDetailDal;
        private readonly IMapper _mapper;

        public AppealInfoDetailBLL(IEfAppealInfoDetailDal appealInfoDetailDal, IMapper mapper)
        {
            _appealInfoDetailDal = appealInfoDetailDal;
            _mapper = mapper;
        }

        public async Task<List<AppealInfoDetailDto>> Add(AppealInfoDetailDto item)
        {
            AppealInfoDetail appealInfodetail = _mapper.Map<AppealInfoDetail>(item);
            appealInfodetail.InsertDate = DateTime.Now;
            AppealInfoDetail appealInfoDetailResult = await _appealInfoDetailDal.AddAsync(appealInfodetail);
            List<AppealInfoDetailDto> appealInfoDetailDTO = await _appealInfoDetailDal.AppealInfoDetailsGetByAppealID(appealInfodetail.A_ID);
            return appealInfoDetailDTO;
        }

        public async Task<List<AppealInfoDetailDto>> Delete(int id)
        {

            AppealInfoDetail appealInfodetail = await _appealInfoDetailDal.Get(d => d.ID == id);
            if (appealInfodetail != null)
            {
                appealInfodetail.DeleteDate = DateTime.Now;
                await _appealInfoDetailDal.DeleteAsync(appealInfodetail);
            }

            return await  _appealInfoDetailDal.AppealInfoDetailsGetByAppealID(appealInfodetail.A_ID);
        }

        public async Task<List<AppealInfoDetailDto>> GetList()
        {
            List<AppealInfoDetailDto> appealInfodetailDTO = await _appealInfoDetailDal.AppealInfoDetailsGetAll();
            return appealInfodetailDTO;
        }

        public async Task<List<AppealInfoDetailDto>> GetListByAppealID(int appealID)
        {
            List<AppealInfoDetailDto> appealInfodetailDTO = await _appealInfoDetailDal.AppealInfoDetailsGetByAppealID(appealID);
            return appealInfodetailDTO;
        }

        public async Task<AppealInfoDetailDto> GetByID(int ID)
        {
            AppealInfoDetailDto appealInfodetailDTO = await _appealInfoDetailDal.AppealInfoDetailsGetByID(ID);
            return appealInfodetailDTO;
        }

        public async Task<List<AppealInfoDetailDto>> Update(AppealInfoDetailDto item)
        {
            AppealInfoDetail appealInfodetailgetById = await _appealInfoDetailDal.Get(x => x.ID == item.ID && x.DeleteDate == null);
            if (appealInfodetailgetById == null)
                return null;

            AppealInfoDetail appealInfodetail = _mapper.Map<AppealInfoDetail>(item);

            appealInfodetail.UpadateDate = DateTime.Now;
            appealInfodetail.InsertDate = appealInfodetailgetById.InsertDate;
            appealInfodetail.A_ID = appealInfodetailgetById.A_ID;


            AppealInfoDetail appealInfoDetailResult = await _appealInfoDetailDal.UpdateAsync(appealInfodetail);
            List<AppealInfoDetailDto> appealInfoDetailDTO = await _appealInfoDetailDal.AppealInfoDetailsGetByAppealID(appealInfodetail.A_ID);
            return appealInfoDetailDTO;
        }
    }
}
