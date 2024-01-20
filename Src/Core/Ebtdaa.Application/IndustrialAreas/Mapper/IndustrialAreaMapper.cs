using AutoMapper;
using Ebtdaa.Application.IndustrialAreas.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustrialAreas.Mapper
{
    public class IndustrialAreaMapper:Profile
    {
        public IndustrialAreaMapper()
        {
            CreateMap<IndustrialArea, IndustrialAreaResultDto>();
            CreateMap<IndustrialAreaRequestDto, IndustrialArea>();
        }
    }
}
