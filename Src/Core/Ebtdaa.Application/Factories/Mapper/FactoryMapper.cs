using AutoMapper;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Mapper
{
    public class FactoryMapper:Profile
    {
        public FactoryMapper()
        {
            CreateMap<Factory, FactoryResualtDto>()
                .ForMember(d => d.CityNameAr, opt => opt.MapFrom(src => src.FactoryLocations.Any()? src.FactoryLocations.FirstOrDefault().City.NameAr:""))
                .ForMember(d => d.CityNameEn, opt => opt.MapFrom(src => src.FactoryLocations.Any() ? src.FactoryLocations.FirstOrDefault().City.NameEn:""));

            CreateMap<FactoryRequestDto, Factory>();
            CreateMap<QueryResult<Factory>, QueryResult<FactoryResualtDto>>();

            CreateMap<FactoryFile, FactoryFileResultDto>()
                       .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path))
                       .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.Attachment.Extension));

            CreateMap<FactoryFileRequestDto, FactoryFile>();

        }
    }
}
