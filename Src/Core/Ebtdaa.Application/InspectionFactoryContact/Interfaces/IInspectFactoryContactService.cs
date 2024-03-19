using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Application.InspectionFactoryContact.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryContact.Interfaces
{
    public interface IInspectFactoryContactService
    {
        Task<BaseResponse<InspectFactContactResultDto>> GetOne(int factoryId,int periodId, string ownerIdentity);
        Task<BaseResponse<InspectFactContactResultDto>> UpdateAsync(InspectFactContactRequestDto req);
        Task<BaseResponse<InspectFactContactResultDto>> AddAsync(InspectFactContactRequestDto req);
    }
}
