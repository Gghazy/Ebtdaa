using AutoMapper;
using Ebtdaa.Application.InspectionFactoryContact.Dtos;
using Ebtdaa.Domain.InpectorFactoryContact.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryContact.Mapper
{
    public class InspectFactoryContactMapper : Profile
    {
        public InspectFactoryContactMapper() 
        { 
          CreateMap<InspectFactoryContact , InspectFactContactResultDto>();
            CreateMap< InspectFactContactRequestDto  , InspectFactoryContact>();
        }
    }
}
