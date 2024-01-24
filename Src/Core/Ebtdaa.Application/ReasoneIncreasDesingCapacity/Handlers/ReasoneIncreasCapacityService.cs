using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ReasoneIncreasDesingCapacity.Dtos;
using Ebtdaa.Application.ReasoneIncreasDesingCapacity.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ReasoneIncreasDesingCapacity.Handlers
{
    public class ReasoneIncreasCapacityService : IReasoneIncreasCapacityService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public ReasoneIncreasCapacityService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<QueryResult<ReasoneIncreaseCapacityResultDto>>> GetAll(ReasoneIncreaseSearch search)
        {
            var result = _mapper.Map<QueryResult<ReasoneIncreaseCapacityResultDto>>(await _dbContext.ReasonIncreasCapacities .ToQueryResult());
            return new BaseResponse<QueryResult<ReasoneIncreaseCapacityResultDto>>
            {
                Data = result
            };
        }
    }
}
