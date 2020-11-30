using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class EnumBLL : IEnumBLL
    {

        private readonly IEfEnumDal _efEnumDal;
        private readonly IMapper _mapper;

        public EnumBLL(IEfEnumDal efEnumDal, IMapper mapper)
        {
            _efEnumDal = efEnumDal;
            _mapper = mapper;
        }

        public async Task<EnumDTO> Add(EnumDTO item)
        {
            TKDSIM.Entity.Entity.Enum enumEntity = _mapper.Map<TKDSIM.Entity.Entity.Enum>(item);
            enumEntity.InsertDate = DateTime.Now;
            TKDSIM.Entity.Entity.Enum EnumResut = await _efEnumDal.AddAsync(enumEntity);
            EnumDTO enumDTO = _mapper.Map<EnumDTO>(EnumResut);
            return enumDTO;
        }

        public async void Delete(int id)
        {
            TKDSIM.Entity.Entity.Enum enumEntity = await _efEnumDal.Get(d => d.E_ID == id && d.DeleteDate == null);
            enumEntity.DeleteDate = DateTime.Now;
            await _efEnumDal.DeleteAsync(enumEntity);
        }

        public async Task<EnumDTO> GetByID(decimal id)
        {
            TKDSIM.Entity.Entity.Enum enumEntity = await _efEnumDal.Get(d => d.E_ID == id && d.DeleteDate == null);
            EnumDTO enumDTO = _mapper.Map<EnumDTO>(enumEntity);
            return enumDTO;
        }

        public async Task<List<EnumDTO>> GetList()
        {
            List<TKDSIM.Entity.Entity.Enum> enumEntity = await _efEnumDal.GetAll();
            List<EnumDTO> enumDTO = _mapper.Map<List<EnumDTO>>(enumEntity);
            return enumDTO;
        }

        public async Task<EnumDTO> Update(EnumDTO item)
        {
            TKDSIM.Entity.Entity.Enum enumEntity = _mapper.Map<TKDSIM.Entity.Entity.Enum>(item);
            enumEntity.InsertDate = DateTime.Now;
            TKDSIM.Entity.Entity.Enum EnumResut = await _efEnumDal.UpdateAsync(enumEntity);
            EnumDTO enumDTO = _mapper.Map<EnumDTO>(EnumResut);
            return enumDTO;
        }
    }
}
