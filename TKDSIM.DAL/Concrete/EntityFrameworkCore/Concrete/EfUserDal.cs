using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Concrete;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore
{
    public class EfUserDal : EfEntityRepositoryBase<User, TKDSIMDBContext>, IEfUserDal
    {
        public async Task<AuthDto> login(string username, string password)
        {
            using (var context = new TKDSIMDBContext())
            {
                var result = from u in context.Users
                             where u.UserName == username && u.Password == password
                             select new AuthDto
                             {
                                 UserName = u.UserName,
                                 Name = u.FirstName,
                                 Surname = u.LastName,
                                 Role = u.Position,
                                 UserId = u.U_ID

                             };

                return await result.FirstOrDefaultAsync();
            }
        }
    }
}
