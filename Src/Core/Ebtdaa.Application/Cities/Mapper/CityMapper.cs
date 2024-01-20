using AutoMapper;
using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.IndustrialAreas.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Cities.Mapper
{
    public class CityMapper :Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityResultDto>();
            CreateMap<CityRequestDto, City>();
        }
    }
}
