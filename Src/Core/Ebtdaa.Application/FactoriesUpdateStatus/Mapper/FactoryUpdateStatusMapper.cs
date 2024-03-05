using AutoMapper;
using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoriesUpdateStatus.Mapper
{
    public class FactoryUpdateStatusMapper : Profile
    {
        public FactoryUpdateStatusMapper() 
        {
            CreateMap<FactoryUpdateStatus, FactUpdateStatusResultDto>();
            CreateMap<FactUpdateStatusRequestDto, FactoryUpdateStatus>();
        }
    }
}
