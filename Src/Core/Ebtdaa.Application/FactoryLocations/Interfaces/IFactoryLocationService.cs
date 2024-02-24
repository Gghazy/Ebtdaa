using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryLocations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Interfaces
{
    public interface IFactoryLocationService
    {
        Task<BaseResponse<FactoryLocationResultDto>> GetOne(int factoryId, int periodId);
        Task<BaseResponse<FactoryLocationResultDto>> UpdateAsync(FactoryLocationRequestDto req);
        Task<BaseResponse<FactoryLocationResultDto>> AddAsync(FactoryLocationRequestDto req);
    }
}
