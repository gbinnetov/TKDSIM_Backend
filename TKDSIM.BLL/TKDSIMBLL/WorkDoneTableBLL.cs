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
    public class WorkDoneTableBLL : IWorkDoneTableBLL
    {
        private readonly IEfWorkDoneTableDal _efWorkDoneTableDal;
        private readonly IMapper _mapper;

        public WorkDoneTableBLL(IEfWorkDoneTableDal efWorkDoneTableDal, IMapper mapper)
        {
            _efWorkDoneTableDal = efWorkDoneTableDal;
            _mapper = mapper;
        }
        public async Task<WorkDoneTableDTO> Add(WorkDoneTableDTO item)
        {
            WorkDoneTable WorkDoneTable = _mapper.Map<WorkDoneTable>(item);
            WorkDoneTable.InsertDate = DateTime.Now;
            WorkDoneTable WorkDoneTableResult = await _efWorkDoneTableDal.AddAsync(WorkDoneTable);
            WorkDoneTableDTO WorkDoneTableDTO = _mapper.Map<WorkDoneTableDTO>(WorkDoneTableResult);
            return WorkDoneTableDTO;
        }

        public async void Delete(int id)
        {
            WorkDoneTable WorkDoneTable = await _efWorkDoneTableDal.Get(d => d.WT_ID == id && d.DeleteDate == null);
            WorkDoneTable.DeleteDate = DateTime.Now;
            await _efWorkDoneTableDal.DeleteAsync(WorkDoneTable);
        }

        public async Task<WorkDoneTableDTO> GetByID(decimal id)
        {
            WorkDoneTable WorkDoneTable = await _efWorkDoneTableDal.Get(d => d.WT_ID == id && d.DeleteDate == null);
            WorkDoneTableDTO WorkDoneTableDTO = _mapper.Map<WorkDoneTableDTO>(WorkDoneTable);
            return WorkDoneTableDTO;
        }

        public async Task<List<WorkDoneTableDTO>> GetByAppealInfoID(decimal id)
        {
            List<WorkDoneTable> item = await _efWorkDoneTableDal.GetAll(d => d.A_ID == id && d.DeleteDate == null);
            List<WorkDoneTableDTO> itemDto = _mapper.Map<List<WorkDoneTableDTO>>(item);
            return itemDto;
        }

        public async Task<List<WorkDoneTableDTO>> GetList()
        {
            List<WorkDoneTable> WorkDoneTable = await _efWorkDoneTableDal.GetAll(d => d.DeleteDate == null);
            List<WorkDoneTableDTO> WorkDoneTableDTO = _mapper.Map<List<WorkDoneTableDTO>>(WorkDoneTable);
            return WorkDoneTableDTO;
        }

        public async Task<WorkDoneTableDTO> Update(WorkDoneTableDTO item)
        {
            WorkDoneTable WorkDoneTableGet = _mapper.Map<WorkDoneTable>(item);
            if (WorkDoneTableGet == null)
                return null;

            WorkDoneTable WorkDoneTable = _mapper.Map<WorkDoneTable>(item);
            WorkDoneTable.UpadateDate = DateTime.Now;
            WorkDoneTable.InsertDate =WorkDoneTableGet.InsertDate;
            WorkDoneTable.A_ID = WorkDoneTableGet.A_ID;
            WorkDoneTable WorkDoneTableResult = await _efWorkDoneTableDal.UpdateAsync(WorkDoneTable);
            WorkDoneTableDTO WorkDoneTableDTO = _mapper.Map<WorkDoneTableDTO>(WorkDoneTableResult);
            return WorkDoneTableDTO;
        }
    }
}
