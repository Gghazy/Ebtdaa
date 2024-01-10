using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Application.CustomsItemUpdateData.Dtos;
using Ebtdaa.Application.CustomsItemUpdateData.Interfaces;
using Ebtdaa.Application.CustomsItemUpdateData.Validation;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.CustomsItemUpdateData.Handlers
{
    public class CustomsItemUpdateDataService : ICustomsItemUpdateDataService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly CustomItemUpdateDataValidator _customItemVaildator;

        public CustomsItemUpdateDataService(IEbtdaaDbContext dbContext, IMapper mapper , CustomItemUpdateDataValidator customItemVaildator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _customItemVaildator = customItemVaildator;
        }

        public async Task<BaseResponse<QueryResult<CUstomsItemLevelResultDto>>> GetCustomItem_12(CustomsItemSearch search)
        {

            var resualt = _mapper.Map<QueryResult<CUstomsItemLevelResultDto>>(await _dbContext.CustomsItemLevels.Where(l => l.LevelId == CustomsItemLevelEnum.Level12).ToQueryResult());


            return new BaseResponse<QueryResult<CUstomsItemLevelResultDto>>
            {
                Data = resualt
            };

        }
        public async Task<BaseResponse<CustomsItemUpdateResultDto>> GetOne(int Id)
        {
            var result = await _dbContext.CustomsItemUpdates.FirstOrDefaultAsync(x => x.Id == Id);

            return new BaseResponse<CustomsItemUpdateResultDto>
            {
                Data = _mapper.Map<CustomsItemUpdateResultDto>(result)
            };
        }
        public async Task<BaseResponse<CustomsItemUpdateResultDto>> AddAsync(CustomsItemUpdateRequestDto req)
        {
            var customItemUpdate = _mapper.Map<CustomsItemUpdate>(req);

           
            var result = await _customItemVaildator.ValidateAsync(customItemUpdate);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.CustomsItemUpdates.AddAsync(customItemUpdate);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<CustomsItemUpdateResultDto>
            {
                Data = _mapper.Map<CustomsItemUpdateResultDto>(customItemUpdate)
            };
        }

        public async Task<BaseResponse<CustomsItemUpdateResultDto>> UpdateAsync(CustomsItemUpdateRequestDto req)
        {
            var customItem = await _dbContext.CustomsItemUpdates.FirstOrDefaultAsync(x => x.Id == req.Id);
            var customItemUpdated = _mapper.Map(req, customItem);

            
            var result = await _customItemVaildator.ValidateAsync(customItemUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<CustomsItemUpdateResultDto>
            {
                Data = _mapper.Map<CustomsItemUpdateResultDto>(customItemUpdated)
            };
        }
    }
}
