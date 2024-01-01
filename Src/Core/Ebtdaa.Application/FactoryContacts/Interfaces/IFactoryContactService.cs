using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryContacts.Dtos;


namespace Ebtdaa.Application.FactoryContacts.Interfaces
{
    public interface IFactoryContactService
    {
        Task<BaseResponse<FactoryContactResultDto>> GetOne(int id);
        Task<BaseResponse<FactoryContactResultDto>> UpdateAsync(FactoryContactRequestDto req);
        Task<BaseResponse<FactoryContactResultDto>> AddAsync(FactoryContactRequestDto req);
    }
}
