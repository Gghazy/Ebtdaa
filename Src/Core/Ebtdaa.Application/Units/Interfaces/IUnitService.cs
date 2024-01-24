using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Units.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Units.Interfaces
{
    public interface IUnitService
    {
        Task<BaseResponse<List<UnitResultDto>>> GetAll();

    }
}
