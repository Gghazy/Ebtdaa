using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Periods.Dtos;
using Ebtdaa.Application.Periods.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.Periods.Handlers
{
    public class PeriodService : IPeriodService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public PeriodService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<QueryResult<PeriodResultDto>>> GetAll(PeriodSearch search)
        {
            var resualt = 
                await _dbContext.Periods
                .Include(x=>x.FactoryUpdateStatuses)
                .Include(x=>x.InspectorUpdateStatuses)
                .OrderByDescending(x=>x.PeriodStartDate.Year)
                .ThenByDescending(x=>x.PeriodStartDate.Month)
                .ToQueryResult(search.PageNumber, search.PageSize);

         

            var response = _mapper.Map<QueryResult<PeriodResultDto>>(resualt);

            foreach (var item in resualt.Items)
            {
                   response.Items.FirstOrDefault(x => x.Id == item.Id).Status =
                   item.FactoryUpdateStatuses.FirstOrDefault(x=>x.FactoryId== search.FactoryId) !=null?
                   item.FactoryUpdateStatuses.FirstOrDefault(x => x.FactoryId == search.FactoryId).DataStatus:DataStatus.New;

                response.Items.FirstOrDefault(x => x.Id == item.Id).InspectorStatus =
                   item.InspectorUpdateStatuses.FirstOrDefault(x => x.FactoryId == search.FactoryId) != null ?
                   item.InspectorUpdateStatuses.FirstOrDefault(x => x.FactoryId == search.FactoryId).DataStatus== DataStatus.Added : false;

            }

            return new BaseResponse<QueryResult<PeriodResultDto>>
            {
                Data = response
            };
        }

        public async Task<BaseResponse<PeriodResultDto>> GetOne(int id)
        {
            var resualt = await _dbContext.Periods.FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<PeriodResultDto>
            {
                Data = _mapper.Map<PeriodResultDto>(resualt)
            };
        }
    }
}
