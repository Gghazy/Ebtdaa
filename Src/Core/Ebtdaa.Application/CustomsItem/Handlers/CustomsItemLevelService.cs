using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Application.CustomsItem.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItem.Handlers
{
    public class CustomsItemLevelService : ICustomsItemLevelService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public CustomsItemLevelService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<QueryResult<CUstomsItemLevelResultDto>>> GetAll(CustomsItemSearch searsh)
        {
            var result = _mapper.Map<QueryResult<CUstomsItemLevelResultDto>>( _dbContext.CustomsItemLevels.Where(c => c.LevelId == CustomsItemLevelEnum.Level12).ToQueryResult());
            return new BaseResponse<QueryResult<CUstomsItemLevelResultDto>>
            {
                Data = result
            };
        }

    }
}
