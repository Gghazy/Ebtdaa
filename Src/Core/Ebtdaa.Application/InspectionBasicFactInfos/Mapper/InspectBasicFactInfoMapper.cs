using AutoMapper;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using Ebtdaa.Domain.InspectorBasicFactoryInfo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Mapper
{
    public class InspectBasicFactInfoMapper : Profile
    {
        public InspectBasicFactInfoMapper() 
        {
            CreateMap<InspectBasicFactoryInfo, InspectBasicFactInfoResultDto>();
            CreateMap<InspectBasicFactInfoRequestDto, InspectBasicFactoryInfo>();


            CreateMap<InspectFactoryFile, InspectFactoryFlieResultDto>()
                       .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path))
                       .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.Attachment.Extension));

            CreateMap<InspectFactoryFlieRequestDto, InspectFactoryFile>();
        }
    }
}
