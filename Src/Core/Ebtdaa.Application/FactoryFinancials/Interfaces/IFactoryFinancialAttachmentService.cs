using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryFinancials.Interfaces
{
    public interface IFactoryFinancialAttachmentService
    {
        Task<BaseResponse<List<FactoryFinancialAttachmentResultDto>>> GetAll();
        Task<BaseResponse<FactoryFinancialAttachmentResultDto>> AddAsync(FactoryFinancialAttachmentRequestDto req);
        Task<BaseResponse<FactoryFinancialAttachmentResultDto>> DeleteAsync(int id);
    }
}
