﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface
{
    public interface IEfEnumValueDal : IEfEntityRepositoryBase<EnumValue>
    {
        Task<List<EnumValueDTO>> EnumValueJoinEnumGetAll();
        Task<List<EnumValueDTO>> EnumValueByEnumID(int id);
    }
}
