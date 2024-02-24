using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.IndustiryalZone.Dtos;
using Ebtdaa.Application.IndustiryalZone.Interfaces;
using Ebtdaa.Application.IndustrialAreas.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustiryalZone.Handlers
{
    public class IndustiryalZoneTypeService : IIndustiryalZoneTypeService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public IndustiryalZoneTypeService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<IndustiryalZoneTypeResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<IndustiryalZoneTypeResultDto>>(await _dbContext.IndustiryalZoneTypes.ToListAsync());

            return new BaseResponse<List<IndustiryalZoneTypeResultDto>>
            {
                Data = respose
            };
        }
    }
}
