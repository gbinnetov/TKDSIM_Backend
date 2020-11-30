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
    public class MissingDocsBLL : IMissingDocsBLL
    {
        private readonly IEfMissingDocsDal _efMissingDocsDal;
        private readonly IMapper _mapper;

        public MissingDocsBLL(IEfMissingDocsDal efMissingDocsDal, IMapper mapper)
        {
            _efMissingDocsDal = efMissingDocsDal;
            _mapper = mapper;
        }
        public async Task<List<MissingDocsDTO>> Add(MissingDocsDTO item)
        {
            if (item!=null)
            {
                for (int i = 0; i < item.DocName.Count; i++)
                {
                    MissingDocs missingDocs = new MissingDocs();

                    missingDocs.A_ID = item.A_ID;
                    missingDocs.DocName = item.DocName[i];
                    missingDocs.InsertDate = DateTime.Now;
                    MissingDocs MissingDocsResult = await _efMissingDocsDal.AddAsync(missingDocs);
                }
            }
            List<MissingDocsDTO> MissingDocsDTO = await _efMissingDocsDal.MissingDocByAppealID(item.A_ID);
            return MissingDocsDTO;
        }

        public async void Delete(int id)
        {
            MissingDocs MissingDocs = await _efMissingDocsDal.Get(d => d.M_ID == id);
            MissingDocs.DeleteDate = DateTime.Now;
            await _efMissingDocsDal.DeleteAsync(MissingDocs);
        }

        public async Task<MissingDocsDTO> GetByID(decimal id)
        {
            MissingDocs MissingDocs = await _efMissingDocsDal.Get(d => d.M_ID == id && d.DeleteDate == null);
            MissingDocsDTO MissingDocsDTO = _mapper.Map<MissingDocsDTO>(MissingDocs);
            return MissingDocsDTO;
        }

        public async Task<List<MissingDocsDTO>> GetByAppealInfoID(decimal id)
        {
            List<MissingDocsDTO> itemDto = await _efMissingDocsDal.MissingDocByAppealID((int)id);

            return itemDto;
        }

        public async Task<List<MissingDocsDTO>> GetList()
        {
            List<MissingDocs> MissingDocs = await _efMissingDocsDal.GetAll(d => d.DeleteDate == null);
            List<MissingDocsDTO> MissingDocsDTO = _mapper.Map<List<MissingDocsDTO>>(MissingDocs);
            return MissingDocsDTO;
        }

    }
}
