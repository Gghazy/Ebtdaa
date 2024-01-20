using AutoMapper;
using Ebtdaa.Application.FactoryEntities.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryEntities.Mapper
{
    public class FactoryEntityMapper :Profile
    {
        public FactoryEntityMapper()
        {
            CreateMap<FactoryEntity, FactoryEntityResultDto>();
            CreateMap<FactoryEntityRequestDto, FactoryEntity>();
        }
    }
}
