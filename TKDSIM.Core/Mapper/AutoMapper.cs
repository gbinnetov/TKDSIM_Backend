using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.DTO.DTO;
using TKDSIM.Entity.Entity;

namespace TKDSIM.Core.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<AppealInfo, AppealInfoDTO>();
            CreateMap<AppealInfoDTO, AppealInfo>();

            CreateMap<TKDSIM.Entity.Entity.Enum, EnumDTO>();
            CreateMap<EnumDTO, TKDSIM.Entity.Entity.Enum>();

            CreateMap<EnumValue, EnumValueDTO>();
            CreateMap<EnumValueDTO, EnumValue>();

            CreateMap<Logger, LoggerDTO>();
            CreateMap<LoggerDTO, Logger>();

            CreateMap<MissingDocs, MissingDocsDTO>();
            CreateMap<MissingDocsDTO, MissingDocs>();

            CreateMap<OrderProject, OrderProjectDTO>();
            CreateMap<OrderProjectDTO, OrderProject>();

            CreateMap<SubmittedDocs, SubmittedDocsDTO>();
            CreateMap<SubmittedDocsDTO, SubmittedDocs>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<WorkDoneForm, WorkDoneFormDTO>();
            CreateMap<WorkDoneFormDTO, WorkDoneForm>();

            CreateMap<WorkDoneTable, WorkDoneTableDTO>();
            CreateMap<WorkDoneTableDTO, WorkDoneTable>();

            CreateMap<AdminUnit, AdminUnitDto>();
            CreateMap<AdminUnitDto, AdminUnit>();

            CreateMap<AppealInfoDetail, AppealInfoDetailDto>();
            CreateMap<AppealInfoDetailDto, AppealInfoDetail>();
        }
    }
}
