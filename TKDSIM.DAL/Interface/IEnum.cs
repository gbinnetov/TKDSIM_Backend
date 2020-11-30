using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Core.DataAccess.Interface;
using EntityUsing = TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Interface
{
    public interface IEnum : IEfEntityRepositoryBase<EntityUsing.Enum>
    {
    }
}
