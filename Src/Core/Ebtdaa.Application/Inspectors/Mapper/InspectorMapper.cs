using AutoMapper;
using Ebtdaa.Application.Inspectors.Dtos;
using Ebtdaa.Domain.Inspectors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Inspectors.Mapper
{
    public class InspectorMapper : Profile
    {
        public InspectorMapper()
        {
            CreateMap<Inspector, InspectorRequestDto>();
            CreateMap<InspectorRequestDto, Inspector>();

        }
    }
}
