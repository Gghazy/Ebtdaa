using AutoMapper;
using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Application.Units.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Units.Handlers
{
    public class UnitService : IUnitService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public UnitService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<UnitResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<UnitResultDto>>(await _dbContext.Units.ToListAsync());

            return new BaseResponse<List<UnitResultDto>>
            {
                Data = respose
            };
        }
    }
}
