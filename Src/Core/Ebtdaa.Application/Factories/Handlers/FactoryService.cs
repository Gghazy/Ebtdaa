using AutoMapper;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Application.FactoryContacts.Interfaces;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryMonthlyFinancials.Interfaces;
using Ebtdaa.Application.LogIn.Interfaces;
using Ebtdaa.Application.ProductsData.Handlers;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Handlers
{
    public class FactoryService : IFactoryService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryValidator _factoryValidator;
        private readonly IActualProductionService _actualProductionService;
        private readonly IActualRawMaterialService _actualRawMaterialService;
        private readonly IProductPeriodActiveService _productPeriodService;
        private readonly IRawMaterialService _rawMaterialService;
        private readonly IFactoryMonthlyFinancialService _factoryMonthlyFinancial;
        private readonly IFactoryLocationService _factoryLocation;
        private readonly IFactoryContactService _factoryContactService;


        public FactoryService(
            IEbtdaaDbContext dbContext,IMapper mapper,FactoryValidator factoryValidator,IActualProductionService actualProductionService,IActualRawMaterialService actualRawMaterialService, IProductPeriodActiveService productPeriodService, IRawMaterialService rawMaterialService , IFactoryMonthlyFinancialService factoryMonthlyFinancial, IFactoryLocationService factoryLocation, IFactoryContactService factoryContactService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _factoryValidator = factoryValidator;
            _actualProductionService = actualProductionService;
            _actualRawMaterialService = actualRawMaterialService;
            _productPeriodService = productPeriodService;
            _rawMaterialService = rawMaterialService;
            _factoryMonthlyFinancial = factoryMonthlyFinancial;
            _factoryLocation = factoryLocation;
            _factoryContactService = factoryContactService;
        }
        public async Task<BaseResponse<QueryResult<FactoryResualtDto>>> GetAll(FactorySearch search)
        {
           
            var resualt = _mapper.Map<QueryResult<FactoryResualtDto>>(
                await _dbContext.Factories
                .Include(x=>x.FactoryLocations)
                .ThenInclude(x=>x.City)
                .Where(f => f.OwnerIdentity == search.OwnerIdentity.ToString()).ToQueryResult(search.PageNumber,search.PageSize));



            return new BaseResponse<QueryResult<FactoryResualtDto>>
            {
                Data = resualt
            };

        }
        public async Task<BaseResponse<FactoryResualtDto>> GetOne(int id, int periodId)
        {
            var resualt = await _dbContext.Factories
                                .Include(x => x.BaiscFactoryInfos)
                                .FirstOrDefaultAsync(x => x.Id == id);
            FactoryResualtDto responseDto = null;
            if (resualt.BaiscFactoryInfos != null)
            {

                var basicinfo = resualt.BaiscFactoryInfos
                    .FirstOrDefault(x => x.PeriodId == periodId);

                if (basicinfo!=null)
                {
                    resualt.Status = basicinfo.FactoryStatusId;

                    responseDto = new FactoryResualtDto
                    {
                        DataApprover = basicinfo.DataApprover,
                        DataReviewer = basicinfo.DataReviewer,
                        DataEntry = basicinfo.DataEntry,
                        CommercialRegister = resualt.CommercialRegister,
                        NameAr = resualt.NameAr,
                        Activity = resualt.Activity,
                        Status= basicinfo.FactoryStatusId
                    };

                }
                //var getAttachment = await _dbContext.BasicFactoryInfos.Include(x =>x.)

            }
            var response = _mapper.Map<FactoryResualtDto>(responseDto);

            return new BaseResponse<FactoryResualtDto>
                {
                    Data = response
                };
        }

        public async Task<BaseResponse<bool>> UpdateAsync(FactoryRequestDto req)
        {
            var isCheckExist = await _dbContext.Factories.FirstOrDefaultAsync(f => f.Id == req.FactoryId);
            var isFactoryExist = _mapper.Map(req, isCheckExist);
          
            await _dbContext.SaveChangesAsync();

            var factory = await _dbContext.BasicFactoryInfos
                            .FirstOrDefaultAsync(x => x.FactoryId == req.FactoryId&&x.PeriodId==req.PeriodId);

            if (factory != null)
            {
                factory.FactoryStatusId = req.Status;
                factory.DataApprover = req.DataApprover;
                factory.DataEntry = req.DataEntry;
                factory.DataReviewer = req.DataReviewer;
            }
            else
            {
                factory = new BaiscFactoryInfo()
                {
                    FactoryId = req.FactoryId,
                    PeriodId = req.PeriodId,
                    FactoryStatusId = req.Status,
                    DataApprover = req.DataApprover,
                    DataEntry =req.DataEntry,
                    DataReviewer = req.DataReviewer
                };

                await _dbContext.BasicFactoryInfos.AddAsync(factory);
            }

            if (factory.FactoryStatusId==FactoryStatusEnum.Under_Construction)
            {
              await _actualProductionService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
              await _actualRawMaterialService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
              await _productPeriodService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
              await _rawMaterialService.DeleteByFactoryIdAndPeriodId(req.FactoryId , req.PeriodId);
            }
            if (factory.FactoryStatusId == FactoryStatusEnum.Under_Production)
            {
                await _actualProductionService.UpdateByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
                await _actualRawMaterialService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
            }
            if(factory.FactoryStatusId == FactoryStatusEnum.Canceled)
            {
                await _actualProductionService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
                await _actualRawMaterialService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
                await _productPeriodService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
                await _rawMaterialService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
                //await _factoryMonthlyFinancial.DeleteByFactoryIdAndPeriodId(req.FactoryId , req.PeriodId);
                await _factoryLocation.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
                await _factoryContactService.DeleteByFactoryIdAndPeriodId(req.FactoryId, req.PeriodId);
            }
            await _dbContext.SaveChangesAsync();
           
            return new BaseResponse<bool>
            {
                Data =true
            };
        }

        public async Task<BaseResponse<List<FactoryResualtDto>>> GetFactoryByEntity(int factoryEntityId)
        {
            var resualt = _mapper.Map<List<FactoryResualtDto>>(
               await _dbContext.Factories
               .Where(f => f.FactoryLocations.Select(x=>x.FactoryEntityId)
               .Contains(factoryEntityId))
               .ToListAsync());



            return new BaseResponse<List<FactoryResualtDto>>
            {
                Data = resualt
            };
        }
    }
}
