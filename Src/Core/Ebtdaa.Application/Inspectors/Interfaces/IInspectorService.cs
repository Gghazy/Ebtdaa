using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Inspectors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Inspectors.Interfaces
{
    public interface IInspectorService
    {
        Task<BaseResponse<List<InspectorResultDto>>> GetAll();
        Task<BaseResponse<InspectorResultDto>> GetOne(int id);
        Task<BaseResponse<InspectorResultDto>> AddAsync(InspectorRequestDto req);
        Task<BaseResponse<InspectorResultDto>> UpdateAsync(InspectorRequestDto req);
        Task<BaseResponse<InspectorResultDto>> DeleteAsync(int id);
        Task<BaseResponse<InspectorFactoriesResultDto>> AssingFactoriesAsync(InspectorFactoriesRequestDto req);
    }
}
