using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ActualProduction.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Handlers
{
    public class ReasonService : IReasonService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public ReasonService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<ReasonResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<ReasonResultDto>>(await _dbContext.Reasons.ToListAsync());

            return new BaseResponse<List<ReasonResultDto>>
            {
                Data = respose
            };
        }


    }
}
