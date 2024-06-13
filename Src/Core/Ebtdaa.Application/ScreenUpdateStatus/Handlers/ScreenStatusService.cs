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
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

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
            if(factory.Data.Status == FactoryStatusEnum.Under_Construction)
            {
                result.FinancialData = await CheckFactoryFinanicailScreenStatus(factoryId, periodId);
                result.BasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);
                result.MonthlyFinancialData = await CheckMonthlyFactoryFinanicailScreenStatus(factoryId, periodId);
                result.FactoryLocation = await CheckFactoryLocationScreenStatus(factoryId, periodId);
                result.FactoryContact = await CheckFactoryContactScreenStatus(factoryId, periodId);
            }
            if(factory.Data.Status == FactoryStatusEnum.Under_Production)
            {
                result.FinancialData = await CheckFactoryFinanicailScreenStatus(factoryId, periodId);
                result.MonthlyFinancialData = await CheckMonthlyFactoryFinanicailScreenStatus(factoryId, periodId);
                result.FactoryLocation = await CheckFactoryLocationScreenStatus(factoryId, periodId);
                result.FactoryContact = await CheckFactoryContactScreenStatus(factoryId, periodId);
                result.BasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);
                result.CustomItemsUpdated = await CheckCustomItemsUpdatedScreenStatus(factoryId, periodId);
                result.ActualProduction = await CheckActualProductionScreenStatus(factoryId, periodId, (FactoryStatusEnum)factory.Data.Status);
                result.ProductData = await CheckFactoryProductScreenStatus(factoryId, periodId);
                result.RawMaterial = await CheckRawMaterialScreenStatus(factoryId, periodId);
                //result.ActualRawMaterila = await CheckActualRawMaterialScreenStatus(factoryId, periodId);
            }
            if(factory.Data.Status == FactoryStatusEnum.Productive)
            {
                result.FinancialData = await CheckFactoryFinanicailScreenStatus(factoryId, periodId);
                result.MonthlyFinancialData = await CheckMonthlyFactoryFinanicailScreenStatus(factoryId, periodId);
                result.FactoryLocation = await CheckFactoryLocationScreenStatus(factoryId, periodId);
                result.FactoryContact = await CheckFactoryContactScreenStatus(factoryId, periodId);
                result.BasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);
                result.CustomItemsUpdated = await CheckCustomItemsUpdatedScreenStatus(factoryId, periodId);
                result.ActualProduction = await CheckActualProductionScreenStatus(factoryId, periodId, (FactoryStatusEnum)factory.Data.Status);
                result.ProductData = await CheckFactoryProductScreenStatus(factoryId, periodId);
                result.RawMaterial = await CheckRawMaterialScreenStatus(factoryId, periodId);
                result.ActualRawMaterila = await CheckActualRawMaterialScreenStatus(factoryId, periodId);
            }
            if (factory.Data.Status == FactoryStatusEnum.Stop)
            {
                result.FinancialData = await CheckFactoryFinanicailScreenStatus(factoryId, periodId);
                result.MonthlyFinancialData = await CheckMonthlyFactoryFinanicailScreenStatus(factoryId, periodId);
                result.FactoryLocation = await CheckFactoryLocationScreenStatus(factoryId, periodId);
                result.FactoryContact = await CheckFactoryContactScreenStatus(factoryId, periodId);
                result.BasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);
                result.CustomItemsUpdated = await CheckCustomItemsUpdatedScreenStatus(factoryId, periodId);
                result.ActualProduction = await CheckActualProductionScreenStatus(factoryId, periodId, (FactoryStatusEnum)factory.Data.Status);
                result.ProductData = await CheckFactoryProductScreenStatus(factoryId, periodId);
                result.RawMaterial = await CheckRawMaterialScreenStatus(factoryId, periodId);
                result.ActualRawMaterila = await CheckActualRawMaterialScreenStatus(factoryId, periodId);
            }
            if (factory.Data.Status == FactoryStatusEnum.Canceled)
            {
                result.FinancialData = await CheckFactoryFinanicailScreenStatus(factoryId, periodId);
                result.MonthlyFinancialData = await CheckMonthlyFactoryFinanicailScreenStatus(factoryId, periodId);
                result.BasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);

            }

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = result
            };
        }

        private async Task<bool> CheckBasicInfoScreenStatus(int periodId, int factoryId)
        {
            var resultFact = await _dbContext.BasicFactoryInfos.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            var resultFactAttach = await _dbContext.FactoryFiles.FirstOrDefaultAsync(fa => fa.FactoryId == factoryId && fa.PeriodId == periodId);

            bool screenStatus = false;
            //screenStatus = resultFact ? true : false;

            if (resultFact != null && resultFactAttach != null)
            {
                screenStatus = true;
                //bool anyBasicInfoIsNull = HasNullProperties(resultFact.FactoryStatusId);

                //bool anyFactFileIsNull = HasNullProperties(resultFactAttach.Type);

                //if (anyBasicInfoIsNull == true && anyFactFileIsNull == true)
                //{
                //    screenStatus = true;
                //}
                //else
                //{
                //    screenStatus = false;
                //}
            }
            else
            {
                screenStatus = false;
            }
            return screenStatus;
        }

        private async Task<bool> CheckFactoryFinanicailScreenStatus(int factoryId, int periodId)
        {
            var result = await _dbContext.FactoryFinancials.AnyAsync(x => x.FactoryId == factoryId);

            var attachment = await _dbContext.FactoryFinancialAttachments
                .Include(x => x.FactoryFinancial)
                .Where(x => x.FactoryId == factoryId && x. PeriodId== periodId).ToListAsync();


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

        private async Task<bool> CheckFactoryLocationScreenStatus(int factoryId , int periodId)
        {
            bool screenStatus = false;

            var resultFactoryLocation =await  _dbContext.FactoryLocations.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            //screenStatus = resultFactoryLocation ? true : false;
            var resultFLA = await _dbContext.FactoryLocationAttachments.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            if (resultFactoryLocation != null && resultFLA != null)
            {
                screenStatus = true;
            }
            else
            {
                screenStatus = false;
            }
            return screenStatus;

        }

        private async Task<bool> CheckFactoryContactScreenStatus(int factoryId , int periodId)
        {
            var result = await _dbContext.FactoryContacts.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            bool screenStatus = false;

            screenStatus = result ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryProductScreenStatus(int factoryId, int periodId)
        {

            bool screenStatus = false;

            var activeProduct = await _dbContext.ProductPeriodActives
                .Include(x => x.Product)
                .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                .Select(x => x.ProductId)
                .ToListAsync();

                var result = await _dbContext.FactoryProducts
                .Where(x => activeProduct.Contains(x.ProductId))
                .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).ToListAsync();
            //.Where(x => x.Product.Kilograms_Per_Unit == null || x.CommericalName == null).ToListAsync();

            screenStatus = result.Count>0 ? true : false;

            return screenStatus;
        }
        private async Task<bool> CheckCustomItemsUpdatedScreenStatus(int factoryId, int periodId)
        {
            bool screenStatus = false;

            var activeProduct = await _dbContext.ProductPeriodActives
                .Include(x => x.Product)
                .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                .Select(x => x.ProductId)
                .ToListAsync();

            screenStatus = activeProduct.Any() ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckActualProductionScreenStatus(int? factoryId, int periodId, FactoryStatusEnum? status)
        {

            bool screenStatus = false;
            var activeProducts = await _dbContext.ProductPeriodActives
                .Include(x => x.Product)
                .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                .Select(x => x.ProductId)
                .ToListAsync();

            var result = await _dbContext.ActualProductionAndCapacities
                .Include(x => x.FactoryProduct)
                .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId)
                .ToListAsync();

            var differenceList = activeProducts.Except(result.Select(x => x.FactoryProductId)).ToList();
            
            if (status == FactoryStatusEnum.Productive)
            {
                screenStatus = IsProductiveScreenValid(/*differenceList,*/ result);

                //if (screenStatus)
                //{
                //    screenStatus = AreAttachmentsComplete(factoryId, periodId);
                //}
            }
            else
            {
                screenStatus = IsNonProductiveScreenValid(differenceList, result);
            }

            return screenStatus;
        }

        private bool IsProductiveScreenValid(/*List<int> differenceList,*/ List<ActualProductionAndCapacity> result)
        {
            return !(/*differenceList.Any() ||*/ result.Any(x => x.ActualProduction == null || x.ActualProduction == 0) || result.Count == 0);
        }

        private bool AreAttachmentsComplete(int? factoryId, int periodId)
        {
            var attachments = _dbContext.ActualProductionAttachments
                .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId)
                .ToList();

            return true;
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
        private async Task<bool> CheckRawMaterialScreenStatus(int factoryId, int periodId)
        {

            var result = await _dbContext.RawMaterials
                .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).ToListAsync();
                
            bool screenStatus = false;

            if (result.Count > 0)
            {
                var data = !result.Any(x => x.AverageWeightKG == 0 || 
                x.MaximumMonthlyConsumption == 0||
                x.CustomItemName == null);
                screenStatus = data ? true : false;
            }
           
            return screenStatus;
        }
        private async Task<bool> CheckActualRawMaterialScreenStatus(int factoryId ,int periodId)
        {
            var result = await _dbContext.ActualRawMaterials
                 .Where(x => x.RawMaterial.FactoryId == factoryId && x.PeriodId == periodId)
               .ToListAsync();

            bool screenStatus = false;
            if (result.Count > 0)
            {
                var data = !result.Any(x => x.UsedQuantity == 0 || x.CurrentStockQuantity == 0);
                screenStatus = data ? true : false;
            }
           
            return screenStatus;
        }

        public static bool HasNullProperties(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] properties = objectType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                if (value == null)
                {
                    return true; // At least one property is null
                }
            }

            return false; // No null properties found
        }
    }
}
