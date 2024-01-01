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
    public interface IFactoryFinancialService
    {
        Task<BaseResponse<FactoryFinancialResultDto>> GetOne(int id);
        Task<BaseResponse<FactoryFinancialResultDto>> UpdateAsync(FactoryFinancialRequestDto req);
        Task<BaseResponse<FactoryFinancialResultDto>> AddAsync(FactoryFinancialRequestDto req);
    }
}
