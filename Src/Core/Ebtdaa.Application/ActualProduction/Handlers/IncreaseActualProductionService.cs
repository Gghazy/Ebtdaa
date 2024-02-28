using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ActualProduction.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.ActualProduction.Handlers
{
    public class IncreaseActualProductionService : IIncreaseActualProductionService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public IncreaseActualProductionService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IncreaseActualProductionResultDto>> GetOne(int periodId, int factoryId)
        {
            var result = await _dbContext.IncreaseActualProductions
                                         .FirstOrDefaultAsync(x => x.PeriodId == periodId && x.FactoryId==factoryId);
            var response = _mapper.Map<IncreaseActualProductionResultDto>(result);

            return new BaseResponse<IncreaseActualProductionResultDto>
            {
                Data = result != null ? response : new IncreaseActualProductionResultDto()
            };
        }
        public async Task<BaseResponse<IncreaseActualProductionResultDto>> AddAsync(IncreaseActualProductionRequestDto request)
        {
            var increaseActualProduction = _mapper.Map<IncreaseActualProduction>(request);


            await _dbContext.IncreaseActualProductions.AddAsync(increaseActualProduction);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<IncreaseActualProductionResultDto>
            {
                Data = _mapper.Map<IncreaseActualProductionResultDto>(increaseActualProduction)
            };
        } 
        public async Task<BaseResponse<IncreaseActualProductionResultDto>> UpdateAsync(IncreaseActualProductionRequestDto request)
        {
            var increaseActualProduction = await _dbContext.IncreaseActualProductions.FirstOrDefaultAsync(x => x.Id == request.Id);

            var increaseActualProductionUpdated = _mapper.Map(request, increaseActualProduction);


            await _dbContext.SaveChangesAsync();


            return new BaseResponse<IncreaseActualProductionResultDto>
            {
                Data = _mapper.Map<IncreaseActualProductionResultDto>(increaseActualProductionUpdated)
            };
        }
    }
}
