using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ScreenUpdateStatus.Interfaces
{
    public interface IScreenStatusService
    {
        Task<BaseResponse<ScreenStatusResultDto>> GetAll( int periodId , int factoryId);
        Task<BaseResponse<ScreenStatusResultDto>> AddAsync(ScreenStatusRequestDto req);
        Task<BaseResponse<ScreenStatusResultDto>> UpdateAsync(ScreenStatusRequestDto req);
        Task<BaseResponse<ScreenStatusResultDto>> ReverseApproval(ScreenStatusRequestDto req);
        Task CheckBasicInfoScreenStatus(int periodId, int factoryId);
        Task CheckFactoryFinanicailScreenStatus(int factoryId);
        Task CheckFactoryLocationScreenStatus(int factoryId);
        Task CheckFactoryContactScreenStatus(int factoryId);
    }
}
