using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ReasoneIncreasDesingCapacity.Dtos;
using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ReasoneIncreasDesingCapacity.Interfaces
{
    public interface IReasoneIncreasCapacityService
    {
        Task<BaseResponse<QueryResult<ReasoneIncreaseCapacityResultDto>>> GetAll (ReasoneIncreaseSearch request);
    }
}
