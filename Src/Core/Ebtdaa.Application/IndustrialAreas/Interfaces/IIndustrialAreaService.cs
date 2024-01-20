using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.IndustrialAreas.Dtos;

namespace Ebtdaa.Application.IndustrialAreas.Interfaces
{
    public interface IIndustrialAreaService
    {

        Task<BaseResponse<List<IndustrialAreaResultDto>>> GetAll();

    }
}
