﻿using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Common.Dtos;

namespace Ebtdaa.Application.ActualRawMaterials.Interfaces
{
    public interface IActualRawFileService
    {
        Task<BaseResponse<List<ActualRawFileResultDto>>> GetByFactory(int actualRawId);
        Task<BaseResponse<ActualRawFileResultDto>> AddAsync(ActualRawFileRequestDto req);
        Task<BaseResponse<ActualRawFileResultDto>> DeleteAsync(int id);
    }
}
