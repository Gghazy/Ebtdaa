using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectorScreenStatus.Dtos;
using Ebtdaa.Application.InspectorScreenStatus.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.InspectorScreenStatus.Handlers
{
    public class InspectorScreenStatusService : IInspectorScreenStatusService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectorScreenStatusService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<InspectorScreenStatusResultDto>> GetAll(int periodId, int factoryId)
        {
           
            var result = new InspectorScreenStatusResultDto();
            var factorystatus = await _dbContext.BasicFactoryInfos.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId && x.CreatedDate.Year == DateTime.Now.Year);
            if(factorystatus != null)
            {
                result.factorystatus=factorystatus.FactoryStatusId;
            }
            result.InspectorBasicFactoryInfo = await CheckBasicInfoScreenStatus(periodId, factoryId);
            result.InspectorFactoryLocation = await CheckFactoryLocationScreenStatus(factoryId, periodId);
            result.InspectorFactoryContact = await CheckFactoryContactScreenStatus(factoryId, periodId);
            result.InspectorProductData = await CheckFactoryProductScreenStatus(factoryId, periodId);
            result.InspectorActualProduction = await CheckActualProductionScreenStatus(factoryId, periodId);
            result.InspectorRawMaterial = await CheckRawMaterialScreenStatus(factoryId, periodId);
           

            return new BaseResponse<InspectorScreenStatusResultDto>
            {
                Data = result
            };
        }

      

        private async Task<bool> CheckBasicInfoScreenStatus(int periodId, int factoryId)
        {
            var result = await _dbContext.InspectBasicFactoryInfos.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);
           // var attachment = await _dbContext.InspectFactoryFiles.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);


            bool screenStatus = false;

            screenStatus = result  ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryLocationScreenStatus(int factoryId, int periodId)
        {
            var result = await _dbContext.InspectFactoryLocations
                .AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);
            //attachment Not require
            /*  var attachment = await _dbContext.InspectFactoryLocationAttachments
                  .AnyAsync(x => x.FactoryId == factoryId && x.PeriodId== periodId);

              bool screenStatus = false;

              screenStatus = result && attachment ? true : false;*/

            bool screenStatus = false;

            screenStatus = result  ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryContactScreenStatus(int factoryId, int periodId)
        {
            var result = await _dbContext.InspectFactoryContacts.AnyAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);
           
            bool screenStatus = false;

            screenStatus = result ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckFactoryProductScreenStatus(int factoryId, int periodId)
        {
            

            var result = await _dbContext.InspectProductPhotos
                .AnyAsync(x => x.PeriodId == periodId && x.FactoryId == factoryId);

            bool screenStatus = false;
            screenStatus = result ? true : false;

            return screenStatus;
        }

        private async Task<bool> CheckActualProductionScreenStatus(int? factoryId, int periodId)
        {
            bool screenStatus = false;

            var result = await _dbContext.InspectActualProductions
                .AnyAsync(x => x.PeriodId == periodId && x.FactoryId == factoryId);


            screenStatus = result  ? true : false;

            return screenStatus;

        }

        private async Task<bool> CheckRawMaterialScreenStatus(int factoryId, int periodId)
        {
            

            var result = await _dbContext.InspectorRawMaterials
                .AnyAsync(x => x.PeriodId == periodId && x.FactoryId == factoryId);

            bool screenStatus = false;
            screenStatus = result ? true : false;

            return screenStatus;
        }
    }
}
