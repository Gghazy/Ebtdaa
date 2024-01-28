using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.CustomsItemUpdateData.Dtos;
using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItemUpdateData.Interfaces
{
    public interface ICustomsItemUpdateDataService
    {
        Task<BaseResponse<CustomsItemUpdateResultDto>> AddAsync(CustomsItemUpdateRequestDto request);
        Task<BaseResponse<CustomsItemUpdateResultDto>> UpdateAsync(CustomsItemUpdateRequestDto request);
        Task<BaseResponse<CustomsItemUpdateResultDto>> GetOne(int Id);
    }
}
