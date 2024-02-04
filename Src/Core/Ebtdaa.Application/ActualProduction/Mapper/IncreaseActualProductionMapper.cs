using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Domain.ActualProduction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Mapper
{
    public class IncreaseActualProductionMapper :Profile
    {
        public IncreaseActualProductionMapper()
        {
            CreateMap<IncreaseActualProductionRequestDto, IncreaseActualProduction>();
            CreateMap<IncreaseActualProduction, IncreaseActualProductionResultDto>();
        }
    }
}
