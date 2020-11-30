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
    public class LoggerBLL : ILoggerBLL
    {
        private readonly IEfLoggerDal _efLoggerDal;
        private readonly IMapper _mapper;

        public LoggerBLL(IEfLoggerDal efLoggerDal, IMapper mapper)
        {
            _efLoggerDal = efLoggerDal;
            _mapper = mapper;
        }
        public async Task<LoggerDTO> Add(LoggerDTO item)
        {
            Logger Logger = _mapper.Map<Logger>(item);
            Logger LoggerResult = await _efLoggerDal.AddAsync(Logger);
            LoggerDTO LoggerDTO = _mapper.Map<LoggerDTO>(LoggerResult);
            return LoggerDTO;
        }

        public async void Delete(int id)
        {
            Logger Logger = await _efLoggerDal.Get(d => d.L_ID == id);
            await _efLoggerDal.DeleteAsync(Logger);
        }

        public async Task<LoggerDTO> GetByID(decimal id)
        {
            Logger Logger = await _efLoggerDal.Get(d => d.L_ID == id);
            LoggerDTO LoggerDTO = _mapper.Map<LoggerDTO>(Logger);
            return LoggerDTO;
        }

        public async Task<List<LoggerDTO>> GetList()
        {
            List<Logger> Logger = await _efLoggerDal.GetAll();
            List<LoggerDTO> LoggerDTO = _mapper.Map<List<LoggerDTO>>(Logger);
            return LoggerDTO;
        }

        public async Task<LoggerDTO> Update(LoggerDTO item)
        {
            Logger Logger = _mapper.Map<Logger>(item);
            Logger LoggerResult = await _efLoggerDal.UpdateAsync(Logger);
            LoggerDTO LoggerDTO = _mapper.Map<LoggerDTO>(LoggerResult);
            return LoggerDTO;
        }
    }
}
