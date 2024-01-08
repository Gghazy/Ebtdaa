using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Interfaces
{
    public interface IActualProductionService
    {
        Task<BaseResponse<ActualProductionResultDto>> AddAsync(ActualProductionRequestDto result);
        Task<BaseResponse<ActualProductionResultDto>>UpdateAsync(ActualProductionRequestDto result);
        Task<BaseResponse<ActualProductionResultDto>> GetOne (int id);
    }
}
