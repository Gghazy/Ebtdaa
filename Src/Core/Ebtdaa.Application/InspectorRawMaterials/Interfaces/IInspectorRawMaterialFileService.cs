using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectorRawMaterials.Interfaces
{
    public interface IInspectorRawMaterialFileService
    {
        Task<BaseResponse<List<InspectorRawMaterialFileResultDto>>> GetAll(int factoryId, int periodId);
        Task<BaseResponse<InspectorRawMaterialFileResultDto>> AddAsync(InspectorRawMaterialFileRequestDto req);

    }
}
