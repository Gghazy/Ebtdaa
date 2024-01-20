using AutoMapper;
using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.Cities.Interfaces;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.IndustrialAreas.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Cities.Handlers
{
    public class CityService : ICityService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public CityService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<CityResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<CityResultDto>>(await _dbContext.Cities.ToListAsync());

            return new BaseResponse<List<CityResultDto>>
            {
                Data = respose
            };
        }
    }
}
