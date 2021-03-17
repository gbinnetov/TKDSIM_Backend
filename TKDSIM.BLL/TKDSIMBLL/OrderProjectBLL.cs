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
    public class OrderProjectBLL : IOrderProjectBLL
    {
        private readonly IEfOrderProjectDal _efOrderProjectDal;
        private readonly IMapper _mapper;

        public OrderProjectBLL(IEfOrderProjectDal efOrderProjectDal, IMapper mapper)
        {
            _efOrderProjectDal = efOrderProjectDal;
            _mapper = mapper;
        }
        public async Task<List<OrderProjectDTO>> Add(OrderProjectDTO item)
        {
            OrderProject OrderProject = _mapper.Map<OrderProject>(item);
            OrderProject.InsertDate = DateTime.Now;
            OrderProject OrderProjectResult = await _efOrderProjectDal.AddAsync(OrderProject);
            List<OrderProjectDTO> OrderProjectDTO = await _efOrderProjectDal.OrderProjectsByAppealID(item.A_ID);
            return OrderProjectDTO;
        }

        public async void Delete(int id)
        {
            OrderProject OrderProject = await _efOrderProjectDal.Get(d => d.O_ID == id);
            OrderProject.DeleteDate = DateTime.Now;
            await _efOrderProjectDal.DeleteAsync(OrderProject);
        }

        public async Task<OrderProjectDTO> GetByID(decimal id)
        {
            OrderProjectDTO OrderProjectDTO = await _efOrderProjectDal.OrderProjectsByID((int)id);
            return OrderProjectDTO;
        }

        public async Task<List<OrderProjectDTO>> GetByAppealInfoID(decimal id)
        {
            List<OrderProjectDTO> itemDto = await _efOrderProjectDal.OrderProjectsByAppealID((int)id);
            return itemDto;
        }

        public async Task<List<OrderProjectDTO>> GetList()
        {
            List<OrderProject> OrderProject = await _efOrderProjectDal.GetAll(d => d.DeleteDate == null);
            List<OrderProjectDTO> OrderProjectDTO = _mapper.Map<List<OrderProjectDTO>>(OrderProject);
            return OrderProjectDTO;
        }

        public async Task<List<OrderProjectDTO>> Update(OrderProjectDTO item)
        {
            OrderProject OrderProjectGet = await _efOrderProjectDal.Get(x => x.O_ID == item.O_ID);
            if (OrderProjectGet == null)
                return null;

            OrderProject OrderProject = _mapper.Map<OrderProject>(item);
            OrderProject.UpadateDate = DateTime.Now;
            OrderProject.InsertDate = OrderProjectGet.InsertDate;
            OrderProject.A_ID = OrderProjectGet.A_ID;
            OrderProject OrderProjectResult = await _efOrderProjectDal.UpdateAsync(OrderProject);
            List<OrderProjectDTO> OrderProjectDTO = await _efOrderProjectDal.OrderProjectsByAppealID(item.A_ID);
            return OrderProjectDTO;
        }
    }
}
