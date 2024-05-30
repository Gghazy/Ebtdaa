using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryContacts.Dtos;


namespace Ebtdaa.Application.FactoryContacts.Interfaces
{
    public interface IFactoryContactService
    {
        Task<BaseResponse<FactoryContactResultDto>> GetOne(int factoryId , int periodId);
        Task<BaseResponse<FactoryContactResultDto>> UpdateAsync(FactoryContactRequestDto req);
        Task<BaseResponse<FactoryContactResultDto>> AddAsync(FactoryContactRequestDto req);
        Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId);
    }
}
