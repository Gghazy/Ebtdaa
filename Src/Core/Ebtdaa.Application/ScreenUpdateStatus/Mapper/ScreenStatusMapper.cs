using AutoMapper;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.ScreenStatus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ScreenUpdateStatus.Mapper
{
    public class ScreenStatusMapper : Profile
    {
        public ScreenStatusMapper() 
        {
            CreateMap<ScreenStatus, ScreenStatusResultDto>();
            CreateMap<ScreenStatusRequestDto, ScreenStatus>();
        }
    }
}
