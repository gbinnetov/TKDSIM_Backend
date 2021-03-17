using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface
{
    public interface IEfOrderProjectDal : IEfEntityRepositoryBase<OrderProject>
    {
        Task<List<OrderProjectDTO>> OrderProjectsGetAll();
        Task<List<OrderProjectDTO>> OrderProjectsByAppealID(int id);
        Task<OrderProjectDTO> OrderProjectsByID(int id);
    }
}
