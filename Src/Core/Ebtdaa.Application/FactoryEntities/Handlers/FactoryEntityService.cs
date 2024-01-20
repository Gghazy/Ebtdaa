using AutoMapper;
using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryEntities.Dtos;
using Ebtdaa.Application.FactoryEntities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryEntities.Handlers
{
    public class FactoryEntityService : IFactoryEntityService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public FactoryEntityService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<FactoryEntityResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<FactoryEntityResultDto>>(await _dbContext.FactoryEntities.ToListAsync());

            return new BaseResponse<List<FactoryEntityResultDto>>
            {
                Data = respose
            };
        }
    }
}
