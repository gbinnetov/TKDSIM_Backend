using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.BLL.Interface;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.BLL.TKDSIMBLL
{
    public class SubmittedDocsBLL : ISubmittedDocsBLL
    {
        private readonly IEfSubmittedDocsDal _efSubmittedDocsDal;
        private readonly IMapper _mapper;

        public SubmittedDocsBLL(IEfSubmittedDocsDal efSubmittedDocsDal, IMapper mapper)
        {
            _efSubmittedDocsDal = efSubmittedDocsDal;
            _mapper = mapper;
        }
        public async Task<List<SubmittedDocsListDTO>> Add(SubmittedDocsDTO item)
        {

            SubmittedDocs SubmittedDocsResult = new SubmittedDocs();
            if (item.File != null)
            {
                for (int j = 0; j < item.DocName.Count; j++)
                {
                    SubmittedDocs SubmittedDocs = new SubmittedDocs();

                    SubmittedDocs.DocName = item.DocName[j];
                    SubmittedDocs.A_ID = item.A_ID;
                    SubmittedDocs.PresentationDate = item.PresentationDate;
                    SubmittedDocs.DeqkisNo = item.DeqkisNo;

                    for (int i = 0; i < item.File.Count; i++)
                    {
                        SubmittedDocs.S_ID = 0;
                        SubmittedDocs.FileName = item.File[i].FileName;
                        SubmittedDocs.FilePath = await GetByteArrayFromImage(item.File[i]);
                        SubmittedDocs.InsertDate = DateTime.Now;

                        await _efSubmittedDocsDal.AddAsync(SubmittedDocs);
                    }
                }

            }
            else
            {
                for (int j = 0; j < item.DocName.Count; j++)
                {
                    SubmittedDocs SubmittedDocs = new SubmittedDocs();

                    SubmittedDocs.DocName = item.DocName[j];
                    SubmittedDocs.A_ID = item.A_ID;
                    SubmittedDocs.PresentationDate = item.PresentationDate;
                    SubmittedDocs.DeqkisNo = item.DeqkisNo;

                    SubmittedDocs.S_ID = 0;
                    SubmittedDocs.FileName = "";
                    SubmittedDocs.FilePath = "";
                    SubmittedDocs.InsertDate = DateTime.Now;

                    await _efSubmittedDocsDal.AddAsync(SubmittedDocs);
                }
            }

            List<SubmittedDocsListDTO> SubmittedDocsDTO = await _efSubmittedDocsDal.SubmittedDocsJsonEnumValListByAppealID(item.A_ID);
            return SubmittedDocsDTO;
        }

        public async void Delete(int id)
        {
            SubmittedDocs SubmittedDocs = await _efSubmittedDocsDal.Get(d => d.S_ID == id);
            SubmittedDocs.DeleteDate = DateTime.Now;
            await _efSubmittedDocsDal.DeleteAsync(SubmittedDocs);
        }

        public async Task<List<SubmittedDocsListDTO>> GetByAppealInfoID(int id)
        {
            List<SubmittedDocsListDTO> submittedDocs = await _efSubmittedDocsDal.SubmittedDocsJsonEnumValListByAppealID(id);
            return submittedDocs;
        }

        public async Task<SubmittedDocsListDTO> GetByID(decimal id)
        {
            //SubmittedDocs SubmittedDocs = await _efSubmittedDocsDal.Get(d => d.S_ID == id && d.DeleteDate == null);
            SubmittedDocsListDTO SubmittedDocs = await _efSubmittedDocsDal.SubmittedDocsJsonEnumVal((int)id);
            //  SubmittedDocsDTO SubmittedDocsDTO = _mapper.Map<SubmittedDocsDTO>(SubmittedDocs);
            return SubmittedDocs;
        }

        public async Task<string> GetByteArrayFromImage(IFormFile file)
        {
            string parentPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
            string folderPath = Path.Combine(parentPath, "ProjectFiles");
            bool exists = Directory.Exists(folderPath);

            if (!exists)
                Directory.CreateDirectory(folderPath);
            if (file != null)
            {

                var path = Path.Combine(folderPath, Guid.NewGuid().ToString() + file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return path;
            }
            return null;
        }

        public async Task<List<SubmittedDocsDTO>> GetList()
        {
            List<SubmittedDocs> SubmittedDocs = await _efSubmittedDocsDal.GetAll(d => d.DeleteDate == null);
            List<SubmittedDocsDTO> SubmittedDocsDTO = _mapper.Map<List<SubmittedDocsDTO>>(SubmittedDocs);
            return SubmittedDocsDTO;
        }

        public async Task<SubmittedDocsListDTO> SubmittedDocsJsonEnumVal(int id)
        {
            return await _efSubmittedDocsDal.SubmittedDocsJsonEnumVal(id);
        }

        public async Task<List<SubmittedDocsListDTO>> SubmittedDocsJsonEnumValListByAppealID(int id)
        {
            return await _efSubmittedDocsDal.SubmittedDocsJsonEnumValListByAppealID(id);
        }

        public async Task<SubmittedDocsListDTO> Update(SubmittedDocsDTO item)
        {
            SubmittedDocs SubmittedDocsGet = await _efSubmittedDocsDal.Get(x => x.S_ID == item.S_ID);
            if (SubmittedDocsGet == null)
                return null;


            SubmittedDocs SubmittedDocs = new SubmittedDocs();

            SubmittedDocs.FileName = SubmittedDocsGet.FileName;
            SubmittedDocs.FilePath = SubmittedDocsGet.FilePath;

            if (item.File != null)
            {

                SubmittedDocs.FileName = item.File[0].FileName;
                SubmittedDocs.FilePath = await GetByteArrayFromImage(item.File[0]);

            }

            SubmittedDocs.DocName = item.DocName[0];
            SubmittedDocs.PresentationDate = item.PresentationDate;
            SubmittedDocs.DeqkisNo = item.DeqkisNo;
            SubmittedDocs.S_ID = item.S_ID;
            SubmittedDocs.UpadateDate = DateTime.Now;
            SubmittedDocs.InsertDate = SubmittedDocsGet.InsertDate;
            SubmittedDocs.A_ID = SubmittedDocsGet.A_ID;
            SubmittedDocs SubmittedDocsResult = await _efSubmittedDocsDal.UpdateAsync(SubmittedDocs);
            SubmittedDocsListDTO SubmittedDocsDTO = await _efSubmittedDocsDal.SubmittedDocsJsonEnumVal(SubmittedDocsResult.S_ID);
            return SubmittedDocsDTO;
        }
    }
}
