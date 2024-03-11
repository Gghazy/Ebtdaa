using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoriesUpdateStatus.Interfaces
{
    public interface IFactoryUpdateStatusService
    {
        Task<BaseResponse<FactUpdateStatusResultDto>> AddAsync(FactUpdateStatusRequestDto req);
        Task<BaseResponse<FactUpdateStatusResultDto>> GetOne(int factoryId, int periodId);
        Task<BaseResponse<FactUpdateStatusResultDto>> UpdateAsync(FactUpdateStatusRequestDto req);
    }
}
