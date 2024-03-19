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
        }
    }
}
