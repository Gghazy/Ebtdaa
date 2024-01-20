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
            CreateMap<Factory, FactoryResualtDto>();

            CreateMap<FactoryRequestDto, Factory>();
            CreateMap<QueryResult<Factory>, QueryResult<FactoryResualtDto>>();

            CreateMap<FactoryFile, FactoryFileResultDto>()
                       .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path));

            CreateMap<FactoryFileRequestDto, FactoryFile>();

        }
    }
}
