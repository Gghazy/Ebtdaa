using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Interfaces
{
    public interface IFactoryService
    {
        Task<BaseResponse<QueryResult<FactoryResualtDto>>> GetAll(FactorySearch search);
        Task<BaseResponse<FactoryResualtDto>> GetOne(int id,int periodId);
        Task<BaseResponse<FactoryResualtDto>> UpdateAsync(FactoryRequestDto req);
    }
}
