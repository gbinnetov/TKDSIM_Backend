using AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class EnumValueBLL : IEnumValueBLL
    {
        private readonly IEfEnumValueDal _efEnumValueDal;
        private readonly IMapper _mapper;

        public EnumValueBLL(IEfEnumValueDal efEnumValueDal, IMapper mapper)
        {
            _efEnumValueDal = efEnumValueDal;
            _mapper = mapper;
        }
        public async Task<EnumValueDTO> Add(EnumValueDTO item)
        {
            EnumValue EnumValue = _mapper.Map<EnumValue>(item);
            EnumValue.InsertDate = DateTime.Now;
            EnumValue EnumValueResult = await _efEnumValueDal.AddAsync(EnumValue);
            EnumValueDTO EnumValueDTO = _mapper.Map<EnumValueDTO>(EnumValueResult);
            return EnumValueDTO;
        }

        public async void Delete(int id)
        {
            EnumValue EnumValue = await _efEnumValueDal.Get(d => d.EV_ID == id && d.DeleteDate == null);
            EnumValue.DeleteDate = DateTime.Now;
            await _efEnumValueDal.DeleteAsync(EnumValue);
        }

        public async Task<List<EnumValueDTO>> EnumValueByEnumID(int id)
        {
            List<EnumValueDTO> resultDto = await _efEnumValueDal.EnumValueByEnumID(id);
            return resultDto;//.OrderBy(x => x.Value).ToList();
        }

        public async Task<List<EnumValueDTO>> EnumValueJoinEnumGetAll()
        {
            return await _efEnumValueDal.EnumValueJoinEnumGetAll();
        }

        public async Task<EnumValueDTO> GetByID(decimal id)
        {
            EnumValue EnumValue = await _efEnumValueDal.Get(d => d.EV_ID == id && d.DeleteDate == null);
            EnumValueDTO EnumValueDTO = _mapper.Map<EnumValueDTO>(EnumValue);
            return EnumValueDTO;
        }

        public async Task<List<EnumValueDTO>> GetList()
        {
            List<EnumValue> EnumValue = await _efEnumValueDal.GetAll(d => d.DeleteDate == null);
            List<EnumValueDTO> EnumValueDTO = _mapper.Map<List<EnumValueDTO>>(EnumValue);
            return EnumValueDTO;
        }

        public async Task<EnumValueDTO> Update(EnumValueDTO item)
        {
            EnumValue EnumValueGet = await _efEnumValueDal.Get(x => x.EV_ID == item.EV_ID);
            if (EnumValueGet == null)
                return null;

            EnumValue EnumValue = _mapper.Map<EnumValue>(item);

            EnumValue.UpadateDate = DateTime.Now;
            EnumValue.EV_ID = EnumValueGet.EV_ID;
            EnumValue.InsertDate = EnumValueGet.InsertDate;

            EnumValue EnumValueResult = await _efEnumValueDal.UpdateAsync(EnumValue);
            EnumValueDTO EnumValueDTO = _mapper.Map<EnumValueDTO>(EnumValueResult);
            return EnumValueDTO;
        }
    }
}
