using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Interfaces
{
    public interface IFactoryFileService
    {
        Task<BaseResponse<List<FactoryFileResultDto>>> GetAll();
        Task<BaseResponse<FactoryFileResultDto>> AddAsync(FactoryFileRequestDto req);
        Task<BaseResponse<FactoryFileResultDto>> DeleteAsync(int id);
    }
}
