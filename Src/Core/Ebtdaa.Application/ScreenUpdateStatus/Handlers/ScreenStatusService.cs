using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ScreenStatus.Entity;
using Microsoft.EntityFrameworkCore;


namespace Ebtdaa.Application.ScreenUpdateStatus.Handlers
{
    public class ScreenStatusService : IScreenStatusService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public ScreenStatusService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ScreenStatusResultDto>> GetAll( int periodId , int factoryId)
        {
            var response = await _dbContext.ScreenStatuses
                .Where(x=> (x.PeriodId == periodId || x.PeriodId==null) && x.FactoryId == factoryId).ToListAsync();

            var result = new ScreenStatusResultDto();

            result.BasicFactoryInfo = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.BasicFactoryInfo)?.UpdateStatus;
            result.FinancialData = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.FinancialData)?.UpdateStatus;
            result.MonthlyFinancialData = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.MonthlyFinancialData)?.UpdateStatus;
            result.FactoryLocation = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.FactoryLocation)?.UpdateStatus;
            result.FactoryContact = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.FactoryContact)?.UpdateStatus;
            result.CustomItemsUpdated = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.CustomItemsUpdated)?.UpdateStatus;
            result.CustomItemValidity = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.CustomItemValidity)?.UpdateStatus;
            result.ProductData = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.ProductData)?.UpdateStatus;
            result.ActualProduction = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.ActualProduction)?.UpdateStatus;
            result.RawMaterial = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.RawMaterial)?.UpdateStatus;
            result.ActualRawMaterila = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.ActualRawMaterila)?.UpdateStatus;



            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = result
            };
        }

        public async Task<BaseResponse<ScreenStatusResultDto>> AddAsync(ScreenStatusRequestDto req)
        {
            var screenStatus = await _dbContext.ScreenStatuses
                .FirstOrDefaultAsync(x => x.FactoryId == req.FactoryId && x.PeriodId == req.PeriodId && x.ScreenStatusId == req.ScreenStatusId);


            if (screenStatus!=null)
            {
                await UpdateAsync(req);
            }
            else
            {
                var newScreenStatus = _mapper.Map<ScreenStatus>(req);

                await _dbContext.ScreenStatuses.AddAsync(newScreenStatus);
            }
           

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        }

        public async Task<BaseResponse<ScreenStatusResultDto>> UpdateAsync(ScreenStatusRequestDto req)
        {
            var screenStatus = await _dbContext.ScreenStatuses
                .FirstOrDefaultAsync(x => x.FactoryId == req.FactoryId && x.PeriodId == req.PeriodId &&x.ScreenStatusId==req.ScreenStatusId);
            screenStatus.PeriodId= req.PeriodId;
            screenStatus.FactoryId= req.FactoryId;
            screenStatus.ScreenStatusId= req.ScreenStatusId;
            screenStatus.UpdateStatus= req.UpdateStatus;

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        } 
        public async Task<BaseResponse<ScreenStatusResultDto>> ReverseApproval(ScreenStatusRequestDto req)
        {
            var screenStatus = await _dbContext.ScreenStatuses.FirstOrDefaultAsync(x => x.FactoryId == req.FactoryId && x.PeriodId == req.PeriodId);
            var screenStatusUpdated = _mapper.Map(req, screenStatus);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        }

        public async Task CheckBasicInfoScreenStatus(int periodId, int factoryId)
        {
            var result = await _dbContext.FactoryFiles.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);


            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = factoryId;
            screenStatus.PeriodId = periodId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.BasicFactoryInfo;
            screenStatus.UpdateStatus = result ? true : false;

            await AddAsync(screenStatus);
        }

        public async Task CheckFactoryFinanicailScreenStatus(int factoryId)
        {
            var result = await _dbContext.FactoryFinancials.AnyAsync(x => x.FactoryId == factoryId);

            var attachment = await _dbContext.FactoryFinancialAttachments
                .Include(x => x.FactoryFinancial)
                .Where(x => x.FactoryFinancial.FactoryId == factoryId).ToListAsync();


            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = factoryId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.FinancialData;
            screenStatus.UpdateStatus = result ? true : false;
            if (attachment.Any(x=>x.Type==FactoryFinancialFileType.FinancialStatement) && attachment.Any(x => x.Type == FactoryFinancialFileType.zakat))
            {
                screenStatus.UpdateStatus = true;
            }
            else
            {
                screenStatus.UpdateStatus = false;
            }

            await AddAsync(screenStatus);
        }

        public async Task CheckMonthlyFactoryFinanicailScreenStatus(int factoryId, int periodId )
        {
            var result = await _dbContext.FactoryMonthlyFinancials.AnyAsync(x => x.FactoryId == factoryId&&x.PeriodId==periodId);


            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = factoryId;
            screenStatus.PeriodId = periodId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.MonthlyFinancialData;
            screenStatus.UpdateStatus = result ? true : false;
           

            await AddAsync(screenStatus);
        }

        public async Task CheckFactoryLocationScreenStatus(int factoryId)
        {
            var result = await _dbContext.FactoryLocations.AnyAsync(x => x.FactoryId == factoryId);

            var attachment= await _dbContext.FactoryLocationAttachments.Include(x=>x.FactoryLocation).AnyAsync(x => x.FactoryLocation.FactoryId ==factoryId);

            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = factoryId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.FactoryLocation;
            screenStatus.UpdateStatus = result && attachment ? true : false;

            await AddAsync(screenStatus);
        }

        public async Task CheckFactoryContactScreenStatus(int factoryId)
        {
            var result = await _dbContext.FactoryContacts.AnyAsync(x => x.FactoryId == factoryId);


            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = factoryId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.FactoryContact;
            screenStatus.UpdateStatus = result ? true : false;

            await AddAsync(screenStatus);
        }

        public async Task CheckFactoryProductScreenStatus(int factoryId,int periodId)
        {

            var activeProduct = await _dbContext.ProductPeriodActives
                .Include(x => x.Product)
                .Where(x => x.PeriodId == periodId && x.Product.FactoryId == factoryId)
                .Select(x=>x.ProductId)
                .ToListAsync();

            var result = await _dbContext.Products
                .AnyAsync(x => activeProduct.Contains(x.Id)&&x.PeperId!=null);


            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = factoryId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.ProductData;
            screenStatus.PeriodId = periodId;
            screenStatus.UpdateStatus = result ? true : false;

            await AddAsync(screenStatus);
        }

        public async Task CheckActualProductionScreenStatus(int? factoryId, int periodId,FactoryStatusEnum? status)
        {
            ScreenStatusRequestDto screenStatus = new ScreenStatusRequestDto();
            screenStatus.FactoryId = (int)factoryId;
            screenStatus.PeriodId = (int)periodId;
            screenStatus.ScreenStatusId = ScreenStatusEnums.ActualProduction;

            var activeProduct = await _dbContext.ProductPeriodActives
                .Include(x => x.Product)
                .Where(x => x.PeriodId == periodId && x.Product.FactoryId == factoryId)
                .Select(x => x.ProductId)
                .ToListAsync();

            bool result;
            if (status==FactoryStatusEnum.Productive)
            {
                try
                {
                    result = await _dbContext.ActualProductionAndCapacities
                                    .AnyAsync(x => activeProduct.Contains(x.ProductId) && x.ActualProduction != null);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
                screenStatus.UpdateStatus = result ? true : false;

                var attachment = await _dbContext.ActualProductionAttachments
              .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).ToListAsync();
                if (attachment
                    .Any(x => x.Type == ActualProductionFileType.SalesQuantity) &&
                    attachment.Any(x => x.Type == ActualProductionFileType.AuditedFinancialStatements) &&
                    attachment.Any(x => x.Type == ActualProductionFileType.ProductionRecord)
                    )

                {
                    screenStatus.UpdateStatus = true;
                }
                else
                {
                    screenStatus.UpdateStatus = false;
                }
            }
            else
            {
                result = await _dbContext.ActualProductionAndCapacities
                .AnyAsync(x => activeProduct.Contains(x.ProductId));
                screenStatus.UpdateStatus = result ? true : false;
            }
           

            await AddAsync(screenStatus);
        }
    }
}
