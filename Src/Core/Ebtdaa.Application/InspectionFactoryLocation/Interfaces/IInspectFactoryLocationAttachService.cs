using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryLocation.Interfaces
{
    public interface IInspectFactoryLocationAttachService
    {
        Task<BaseResponse<List<InspectFactoryLocationAttachResDto>>> GetAll(int factoryId, int periodId);
        Task<BaseResponse<InspectFactoryLocationAttachResDto>> AddAsync(InspectFactoryLocationAttachReqDto req);
    }
}
