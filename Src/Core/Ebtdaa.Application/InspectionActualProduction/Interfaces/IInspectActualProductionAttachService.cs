using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Interfaces
{
    public interface IInspectActualProductionAttachService
    {
        Task<BaseResponse<InspectActualProductionAttachResDto>> AddAsync(InspectActualProductionAttachReqDto result);
        Task<BaseResponse<List<InspectActualProductionAttachResDto>>> GetAll(int factoryId, int periodId, string OwnerIdentity);
        Task<BaseResponse<InspectActualProductionAttachResDto>> DeleteAsync(int id);

    }
}
