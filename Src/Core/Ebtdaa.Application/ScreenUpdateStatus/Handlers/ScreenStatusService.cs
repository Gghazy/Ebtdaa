using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Handlers;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ActualProduction.Entity;
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

        public async Task<BaseResponse<ScreenStatusResultDto>> GetAll(int periodId, int factoryId)
        {
            var factory = await GetFactory(factoryId, periodId);

            var response = await _dbContext.ScreenStatuses
                .Where(x => (x.PeriodId == periodId || x.PeriodId == null) && x.FactoryId == factoryId).ToListAsync();

            var result = new ScreenStatusResultDto();

            result.BasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);
            result.FinancialData = await CheckFactoryFinanicailScreenStatus(factoryId);
            result.MonthlyFinancialData = await CheckMonthlyFactoryFinanicailScreenStatus(factoryId, periodId);
            result.FactoryLocation = await CheckFactoryLocationScreenStatus(factoryId);
            result.FactoryContact = await CheckFactoryContactScreenStatus(factoryId);
            result.CustomItemsUpdated = await CheckCustomItemsUpdatedScreenStatus(factoryId, periodId);
            result.ActualProduction = await CheckActualProductionScreenStatus(factoryId, periodId, (FactoryStatusEnum)factory.Data.Status);
            result.ProductData = await CheckFactoryProductScreenStatus(factoryId, periodId);
            result.RawMaterial = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.RawMaterial)?.UpdateStatus;
            result.ActualRawMaterila = response.FirstOrDefault(x => x.ScreenStatusId == ScreenStatusEnums.ActualRawMaterila)?.UpdateStatus;



            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = result
            };
        }

        private async Task<bool> CheckBasicInfoScreenStatus(int periodId, int factoryId)
        {
            var result = await _dbContext.FactoryFiles.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);


            bool screenStatus = false;

            screenStatus = result ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryFinanicailScreenStatus(int factoryId)
        {
            var result = await _dbContext.FactoryFinancials.AnyAsync(x => x.FactoryId == factoryId);

            var attachment = await _dbContext.FactoryFinancialAttachments
                .Include(x => x.FactoryFinancial)
                .Where(x => x.FactoryFinancial.FactoryId == factoryId).ToListAsync();


            bool screenStatus = false;

            screenStatus = result ? true : false;
            if (attachment.Any(x => x.Type == FactoryFinancialFileType.FinancialStatement) && attachment.Any(x => x.Type == FactoryFinancialFileType.zakat))
            {
                screenStatus = true;
            }
            else
            {
                screenStatus = false;
            }

            return screenStatus;

        }

        private async Task<bool> CheckMonthlyFactoryFinanicailScreenStatus(int factoryId, int periodId)
        {
            var result = await _dbContext.FactoryMonthlyFinancials.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);


            bool screenStatus = false;

            screenStatus = result ? true : false;


            return screenStatus;
        }

        private async Task<bool> CheckFactoryLocationScreenStatus(int factoryId)
        {
            var result = await _dbContext.FactoryLocations.AnyAsync(x => x.FactoryId == factoryId);

            var attachment = await _dbContext.FactoryLocationAttachments.Include(x => x.FactoryLocation).AnyAsync(x => x.FactoryLocation.FactoryId == factoryId);

            bool screenStatus = false;

            screenStatus = result && attachment ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryContactScreenStatus(int factoryId)
        {
            var result = await _dbContext.FactoryContacts.AnyAsync(x => x.FactoryId == factoryId);

            bool screenStatus = false;

            screenStatus = result ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryProductScreenStatus(int factoryId, int periodId)
        {
            bool screenStatus = false;

            var activeProduct = await _dbContext.ProductPeriodActives
                .Include(x => x.FactoryProduct)
                .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId)
                .Select(x => x.FactoryProductId)
                .ToListAsync();

            var result = await _dbContext.FactoryProducts
                .AnyAsync(x => activeProduct.Contains(x.Id) && x.PeperId == null);



            screenStatus = result ? false : true;

            return screenStatus;
        }
        private async Task<bool> CheckCustomItemsUpdatedScreenStatus(int factoryId, int periodId)
        {
            bool screenStatus = false;

            var activeProduct = await _dbContext.ProductPeriodActives
                .Include(x => x.FactoryProduct)
                .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId)
                .Select(x => x.FactoryProductId)
                .ToListAsync();

            screenStatus = activeProduct.Any() ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckActualProductionScreenStatus(int? factoryId, int periodId, FactoryStatusEnum? status)
        {
            bool screenStatus = false;

            var activeProducts = await _dbContext.ProductPeriodActives
                .Include(x => x.FactoryProduct)
                .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId)
                .Select(x => x.FactoryProductId)
                .ToListAsync();

            var result = await _dbContext.ActualProductionAndCapacities
                .Include(x => x.FactoryProduct)
                .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId)
                .ToListAsync();

            var differenceList = activeProducts.Except(result.Select(x => x.FactoryProductId)).ToList();

            if (status == FactoryStatusEnum.Productive)
            {
                screenStatus = IsProductiveScreenValid(differenceList, result);

                if (screenStatus)
                {
                    screenStatus = AreAttachmentsComplete(factoryId, periodId);
                }
            }
            else
            {
                screenStatus = IsNonProductiveScreenValid(differenceList, result);
            }

            return screenStatus;
        }

        private bool IsProductiveScreenValid(List<int> differenceList, List<ActualProductionAndCapacity> result)
        {
            return !(differenceList.Any() || result.Any(x => x.ActualProduction == null) || result.Count == 0);
        }

        private bool AreAttachmentsComplete(int? factoryId, int periodId)
        {
            var attachments = _dbContext.ActualProductionAttachments
                .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId)
                .ToList();

            return attachments.Any(x => x.Type == ActualProductionFileType.SalesQuantity) &&
                   attachments.Any(x => x.Type == ActualProductionFileType.AuditedFinancialStatements) &&
                   attachments.Any(x => x.Type == ActualProductionFileType.ProductionRecord);
        }

        private bool IsNonProductiveScreenValid(List<int> differenceList, List<ActualProductionAndCapacity> result)
        {
            return (!differenceList.Any() && result.Count>0 && result.Any(x=>x.DesignedCapacity!=null));
        }
        private async Task<BaseResponse<FactoryResualtDto>> GetFactory(int id, int periodId)
        {
            var resualt = await _dbContext.Factories
                                .Include(x => x.BaiscFactoryInfos)
                                .FirstOrDefaultAsync(x => x.Id == id);
            if (resualt.BaiscFactoryInfos != null)
            {

                var basicinfo = resualt.BaiscFactoryInfos.FirstOrDefault(x => x.PeriodId == periodId);
                if (basicinfo != null)
                {
                    resualt.Status = basicinfo.FactoryStatusId;
                }

            }

            return new BaseResponse<FactoryResualtDto>
            {
                Data = _mapper.Map<FactoryResualtDto>(resualt)
            };

        }

    }
}
