using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Interfaces
{
    public interface IActualProductionAttachService
    {
        Task<BaseResponse<ActualProductionAttacResultDto>> AddAsync(ActualProductionAttacRequestDto result);
        Task<BaseResponse<ActualProductionAttacResultDto>> DeleteAsync(int id);
        Task<BaseResponse<List<ActualProductionAttacResultDto>>> GetAll(int factoryId);

    }
}
