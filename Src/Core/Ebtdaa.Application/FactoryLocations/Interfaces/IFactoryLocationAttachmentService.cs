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
    public interface IFactoryLocationAttachmentService
    {
        Task<BaseResponse<List<FactoryLocationAttachmentResultDto>>> GetAll(int id);
        Task<BaseResponse<FactoryLocationAttachmentResultDto>> AddAsync(FactoryLocationAttachmentRequestDto req);
        Task<BaseResponse<FactoryLocationAttachmentResultDto>> DeleteAsync(int id);
    }
}
