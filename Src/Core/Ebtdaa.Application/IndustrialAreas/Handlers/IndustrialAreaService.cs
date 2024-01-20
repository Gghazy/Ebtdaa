using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.IndustrialAreas.Dtos;
using Ebtdaa.Application.IndustrialAreas.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustrialAreas.Handlers
{
    public class IndustrialAreaService : IIndustrialAreaService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public IndustrialAreaService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<IndustrialAreaResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<IndustrialAreaResultDto>>(await _dbContext.IndustrialAreas.ToListAsync());

            return new BaseResponse<List<IndustrialAreaResultDto>>
            {
                Data = respose
            };
        }
    }
}
