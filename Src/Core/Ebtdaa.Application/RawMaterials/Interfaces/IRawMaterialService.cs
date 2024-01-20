using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.RawMaterials.Interfaces
{
    public interface IRawMaterialService
    {
        Task<BaseResponse<List<RawMaterialResultDto>>> GetAll();
        Task<BaseResponse<List<RawMaterialResultDto>>> GetAllByFactory(int id);
        Task<BaseResponse<RawMaterialResultDto>> GetOne(int id);
        Task<BaseResponse<RawMaterialResultDto>> AddAsync(RawMaterialRequestDto req);
        Task<BaseResponse<RawMaterialResultDto>> UpdateAsync(RawMaterialRequestDto req);
      
    }
}
