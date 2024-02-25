using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.CustomItemRawMaterials.Dtos;

namespace Ebtdaa.Application.CustomItemRawMaterials.Interfaces
{
    public interface ICustomItemRawMaterialServices
    {
        Task<BaseResponse<List<CustomItemRawMaterialResultDto>>> GetAll();
    }
}
