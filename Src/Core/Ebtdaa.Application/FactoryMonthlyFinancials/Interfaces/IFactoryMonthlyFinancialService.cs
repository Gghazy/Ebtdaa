using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryMonthlyFinancials.Dtos;


namespace Ebtdaa.Application.FactoryMonthlyFinancials.Interfaces
{
    public interface IFactoryMonthlyFinancialService
    {
        Task<BaseResponse<FactoryMonthlyFinancialResultDto>> GetOne(int id, int periodId);
        Task<BaseResponse<FactoryMonthlyFinancialResultDto>> UpdateAsync(FactoryMonthlyFinancialRequestDto req);
        Task<BaseResponse<FactoryMonthlyFinancialResultDto>> AddAsync(FactoryMonthlyFinancialRequestDto req);
    }
}
