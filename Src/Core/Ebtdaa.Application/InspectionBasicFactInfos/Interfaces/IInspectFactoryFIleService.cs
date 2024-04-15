using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Interfaces
{
    public interface IInspectFactoryFIleService
    {
        Task<BaseResponse<List<InspectFactoryFlieResultDto>>> GetAll(int factoryId, int periodId);
        Task<BaseResponse<InspectFactoryFlieResultDto>> AddAsync(InspectFactoryFlieRequestDto req);
    }
}
