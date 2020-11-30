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
    public class UserBLL : IUserBLL
    {
        private readonly IEfUserDal _efUserDal;
        private readonly IMapper _mapper;

        public UserBLL(IEfUserDal efUserDal, IMapper mapper)
        {
            _efUserDal = efUserDal;
            _mapper = mapper;
        }
        public async Task<UserDTO> Add(UserDTO item)
        {
            User User = _mapper.Map<User>(item);
            User.InsertDate = DateTime.Now;
            User UserResult = await _efUserDal.AddAsync(User);
            UserDTO UserDTO = _mapper.Map<UserDTO>(UserResult);
            return UserDTO;
        }

        public async void Delete(int id)
        {
            User User = await _efUserDal.Get(d => d.U_ID == id);
            User.DeleteDate = DateTime.Now;
            await _efUserDal.DeleteAsync(User);
        }

        public async Task<UserDTO> GetByID(decimal id)
        {
            User User = await _efUserDal.Get(d => d.U_ID == id && d.DeleteDate == null);
            UserDTO UserDTO = _mapper.Map<UserDTO>(User);
            return UserDTO;
        }

        public async Task<List<UserDTO>> GetList()
        {
            List<User> User = await _efUserDal.GetAll(d => d.DeleteDate == null);
            List<UserDTO> UserDTO = _mapper.Map<List<UserDTO>>(User);
            return UserDTO;
        }

        public async Task<AuthDto> Login(string username, string password)
        {
            User userByUserName = await _efUserDal.Get(m => m.UserName == username);

            if (userByUserName == null)
            {
                AuthDto authDto = new AuthDto();
                authDto.statusCode = "-2";
                authDto.responseText = "İstifadəçi mövcud deyil";
                return authDto;
            }
            else
            {
                AuthDto userLogin = new AuthDto();
                userLogin = await _efUserDal.login(username, password);
                if (userLogin == null)
                {
                    AuthDto authDto = new AuthDto();
                    authDto.statusCode = "-1";
                    authDto.responseText = "İstifadəçi şifrəsi yanlışdır.";

                    return authDto;
                }
                else
                {
                    AuthDto user = new AuthDto();
                    user = await _efUserDal.login(username, password);
                    if (user == null)
                    {
                        AuthDto authDtoBlock = new AuthDto();
                        authDtoBlock.statusCode = "0";
                        authDtoBlock.responseText = "İstifadəçi bloklanıb.";
                        return authDtoBlock;
                    }

                    AuthDto authDto = _mapper.Map<AuthDto>(user);
                    authDto.statusCode = "1";
                    authDto.responseText = "Məlumatlar düzgündür.";

                    return authDto;
                }

          
            }
        }

        public async Task<UserDTO> Update(UserDTO item)
        {
            User UserGet = await _efUserDal.Get(x => x.U_ID == item.U_ID); 
            User User = _mapper.Map<User>(item);


            if (User.Password == null)
                User.Password = UserGet.Password;

            User.UpadateDate = DateTime.Now;
            User.InsertDate = UserGet.InsertDate;
            User UserResult = await _efUserDal.UpdateAsync(User);
            UserDTO UserDTO = _mapper.Map<UserDTO>(UserResult);
            return UserDTO;
        }
    }
}
