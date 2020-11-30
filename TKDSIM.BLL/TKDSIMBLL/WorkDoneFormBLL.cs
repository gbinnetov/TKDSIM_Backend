using AutoMapper;
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
    public class WorkDoneFormBLL : IWorkDoneFormBLL
    {
        private readonly IEfWorkDoneFormDal _efWorkDoneFormDal;
        private readonly IMapper _mapper;

        public WorkDoneFormBLL(IEfWorkDoneFormDal efWorkDoneFormDal, IMapper mapper)
        {
            _efWorkDoneFormDal = efWorkDoneFormDal;
            _mapper = mapper;
        }
        public async Task<WorkDoneFormDTO> Add(WorkDoneFormDTO item)
        {
            WorkDoneForm WorkDoneForm = _mapper.Map<WorkDoneForm>(item);
            WorkDoneForm.InsertDate = DateTime.Now;
            WorkDoneForm WorkDoneFormResult = await _efWorkDoneFormDal.AddAsync(WorkDoneForm);
            WorkDoneFormDTO WorkDoneFormDTO = _mapper.Map<WorkDoneFormDTO>(WorkDoneFormResult);
            return WorkDoneFormDTO;
        }

        public async void Delete(int id)
        {
            WorkDoneForm WorkDoneForm = await _efWorkDoneFormDal.Get(d => d.WF_ID == id && d.DeleteDate == null);
            WorkDoneForm.DeleteDate = DateTime.Now;
            await _efWorkDoneFormDal.DeleteAsync(WorkDoneForm);
        }

        public async Task<WorkDoneFormDTO> GetByID(decimal id)
        {
            WorkDoneFormDTO WorkDoneFormDTO = await _efWorkDoneFormDal.GetByID((int)id);
            return WorkDoneFormDTO;
        }

        public async Task<List<WorkDoneFormDTO>> GetByAppealInfoID(decimal id)
        {
            List<WorkDoneFormDTO> itemDto = await _efWorkDoneFormDal.GetByAppealID((int)id); 
            return itemDto;
        }

        public async Task<List<WorkDoneFormDTO>> GetList()
        {
            List<WorkDoneFormDTO> WorkDoneFormDTO = await _efWorkDoneFormDal.GetAll();
            return WorkDoneFormDTO;
        }


        public async Task<WorkDoneFormDTO> Update(WorkDoneFormDTO item)
        {
            WorkDoneForm WorkDoneFormGet = await _efWorkDoneFormDal.Get(x => x.WF_ID == item.WF_ID);
            if (WorkDoneFormGet == null)
                return null;

            WorkDoneForm WorkDoneForm = _mapper.Map<WorkDoneForm>(item);
            WorkDoneForm.UpadateDate = DateTime.Now;
            WorkDoneForm.InsertDate = WorkDoneFormGet.InsertDate;
            WorkDoneForm.A_ID = WorkDoneFormGet.A_ID;
            WorkDoneForm WorkDoneFormResult = await _efWorkDoneFormDal.UpdateAsync(WorkDoneForm);
            WorkDoneFormDTO WorkDoneFormDTO = _mapper.Map<WorkDoneFormDTO>(WorkDoneFormResult);
            return WorkDoneFormDTO;
        }
    }
}
