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
    public class AdminUnitBLL : IAdminUnitBLL
    {
        private readonly IEFAdminUnitDal _eFAdminUnitDal;
        private readonly IMapper _mapper;
        public AdminUnitBLL(IEFAdminUnitDal eFAdminUnitDal, IMapper mapper)
        {
            _eFAdminUnitDal = eFAdminUnitDal;
            _mapper = mapper;
        }
        public async Task<List<AdminUnitDto>> AdminUnitAll()
        {
            List<AdminUnit> adminUnit = await _eFAdminUnitDal.GetAll(); 
            List<AdminUnitDto> appealInfo = _mapper.Map<List<AdminUnitDto>>(adminUnit);
            return appealInfo;
        }

        public async Task<List<AdminUnitDto>> AdminUnitByCode(string code)
        {
            List<AdminUnit> adminUnit = await _eFAdminUnitDal.GetAll(x=>x.Code == code);
            List<AdminUnitDto> appealInfo = _mapper.Map<List<AdminUnitDto>>(adminUnit);
            return appealInfo;
        }

        public async Task<AdminUnitDto> AdminUnitByID(string id)
        {
            AdminUnit adminUnit = await _eFAdminUnitDal.Get(x => x.Admin_Unit_ID == id);
            AdminUnitDto appealInfo = _mapper.Map<AdminUnitDto>(adminUnit);
            return appealInfo;
        }

        public async Task<List<AdminUnitDto>> AdminUnitByParentCode(string parentCode)
        {
            List<AdminUnit> adminUnit = await _eFAdminUnitDal.GetAll(x => x.ParentCode == parentCode);
            List<AdminUnitDto> appealInfo = _mapper.Map<List<AdminUnitDto>>(adminUnit);
            return appealInfo;
        }
        public async Task<List<AdminUnitDto>> AdminUnitChildByCode(string code)
        {
            List<AdminUnit> adminUnit = await _eFAdminUnitDal.GetAll(x => x.ParentCode == code);
            List<AdminUnitDto> appealInfo = _mapper.Map<List<AdminUnitDto>>(adminUnit);
            return appealInfo;
        }

        public async Task<List<AdminUnitDto>> AdminUnitChildByID(string id)
        {
            AdminUnit adminUnit = await _eFAdminUnitDal.Get(x => x.Admin_Unit_ID == id);
            List<AdminUnit> adminUnitList = await _eFAdminUnitDal.GetAll(x => x.ParentCode == adminUnit.Code);
            List<AdminUnitDto> appealInfo = _mapper.Map<List<AdminUnitDto>>(adminUnitList);
            return appealInfo;
        }
    }
}
