using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryLocation.Interfaces
{
    public interface IInspectFactoryLocationService
    {
        Task<BaseResponse<InspectFactoryLocationResDto>> GetAll(int factoryId, int periodId);
        Task<BaseResponse<InspectFactoryLocationResDto>> UpdateAsync(InspectFactoryLocationReqDto req);
        Task<BaseResponse<InspectFactoryLocationResDto>> AddAsync(InspectFactoryLocationReqDto req);
    }
}
