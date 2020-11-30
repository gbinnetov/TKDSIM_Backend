using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Core.DataAccess.Concrete;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Concrete
{
    public class EFAdminUnitDal : EfEntityRepositoryBase<AdminUnit, TKDSIMDBContext>, IEFAdminUnitDal
    {

    }
}
