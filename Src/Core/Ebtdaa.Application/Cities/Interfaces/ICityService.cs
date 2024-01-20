using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.IndustrialAreas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Cities.Interfaces
{
    public interface ICityService
    {
        Task<BaseResponse<List<CityResultDto>>> GetAll();

    }
}
