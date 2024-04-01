using AutoMapper;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryLocation.Mapper
{
    public class InspectFactoryLocationMapper : Profile
    {
        public InspectFactoryLocationMapper() 
        {
            CreateMap<InspectFactoryLocation,InspectFactoryLocationResDto>();
            CreateMap<InspectFactoryLocationReqDto, InspectFactoryLocation>();
        }
    }
}
