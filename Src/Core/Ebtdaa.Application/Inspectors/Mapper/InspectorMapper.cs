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
            CreateMap<Inspector, InspectorResultDto>()
              .ForMember(dest => dest.FactoryIds, opt => opt.MapFrom(src => src.InspectorFactories.Select(prm => prm.FactoryId)));
               
            CreateMap<InspectorRequestDto, Inspector>();

            CreateMap<InspectorFactory, InspectorFactoriesResultDto>()
                 .ForMember(dest => dest.FactoryName, opt => opt.MapFrom(src => src.Factories.NameAr))
                 .ForMember(dest => dest.FactoryId, opt => opt.MapFrom(src => src.Factories.Id))
                 .ForMember(dest => dest.CommerialNumber, opt => opt.MapFrom(src => src.Factories.CommercialRegister));


        }
    }
}
