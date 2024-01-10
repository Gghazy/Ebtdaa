using AutoMapper;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Units.Mapper
{
    public class UnitMapper : Profile
    {
        public UnitMapper()
        {
            CreateMap<Unit, UnitRequestDto>();
            CreateMap<UnitRequestDto, Unit>();

            CreateMap<Unit , UnitResultDto>();
            CreateMap<UnitResultDto, Unit>();
        }

    }
}
