using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Core.DataAccess.Concrete;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore
{
    public class EfEnumDal : EfEntityRepositoryBase<TKDSIM.Entity.Entity.Enum, TKDSIMDBContext>, IEfEnumDal
    {
    }
}
