using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.DTO.DTO;

namespace TKDSIM.BLL.Interface
{
    public interface IUserBLL
    {
        Task<UserDTO> Add(UserDTO item);
        Task<AuthDto> Login(string username, string password);
        Task<UserDTO> Update(UserDTO item);
        void Delete(int id);
        Task<UserDTO> GetByID(decimal id);
        Task<List<UserDTO>> GetList();
    }
}
