using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.Periods;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.ActualRawMaterials.Handlers
{
    public class ActualRawMaterialService : IActualRawMaterialService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ActualRawMaterialValidator _actualRawMaterialValidator;
        private readonly IActualRawFileService _actualRawFileService;

        public ActualRawMaterialService(IEbtdaaDbContext dbContext, IMapper mapper, ActualRawMaterialValidator actualRawMaterial, IActualRawFileService actualRawFileService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualRawMaterialValidator = actualRawMaterial;
            _actualRawFileService = actualRawFileService;
        }

        public async Task<BaseResponse<List<ActualRawMaterialResultDto>>> GetAll(ActualRawMaterialSearch search)
        {
            var respose = await _dbContext.ActualRawMaterials
                           .Include(x => x.RawMaterial)
                           .Where(x => x.RawMaterial.FactoryId == search.FactoryId &&
                           x.PeriodId == search.PeriodId)
            .ToListAsync();


           var  AcurawMaterialsList = _mapper.Map<List<ActualRawMaterialResultDto>>(respose);


            return new BaseResponse<List<ActualRawMaterialResultDto>>
            {
                Data = AcurawMaterialsList
            };
           
        }


        public async Task<BaseResponse<ActualRawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.ActualRawMaterials.FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<ActualRawMaterialResultDto>
            {
                Data = _mapper.Map<ActualRawMaterialResultDto>(result)
            };
        }


        public async Task<BaseResponse<ActualRawMaterialResultDto>> AddAsync(ActualRawMaterialRequestDto req)
        {

            try
            {


                ActualRawMaterial actualRawMaterial = _mapper.Map<ActualRawMaterial>(req);
            var result = await _actualRawMaterialValidator.ValidateAsync(actualRawMaterial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.ActualRawMaterials.AddAsync(actualRawMaterial);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ActualRawMaterialResultDto>
            {
                Data = _mapper.Map<ActualRawMaterialResultDto>(actualRawMaterial),
                IsSuccess= true
            };
            }
            catch (Exception)
            {

                return new BaseResponse<ActualRawMaterialResultDto>
                {
                    Data = new ActualRawMaterialResultDto(),
                    IsSuccess = false
                };
            }
        }
        public async Task<BaseResponse<ActualRawMaterialResultDto>> UpdateAsync(ActualRawMaterialRequestDto req)
        {

            try
            {


                var actualRawMaterial = await _dbContext.ActualRawMaterials.FirstOrDefaultAsync(x => x.Id == req.Id);
            var actualRawMaterialUpdated = _mapper.Map(req, actualRawMaterial);

            // Validation
            var result = await _actualRawMaterialValidator.ValidateAsync(actualRawMaterialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ActualRawMaterialResultDto>
            {
                Data = _mapper.Map<ActualRawMaterialResultDto>(actualRawMaterialUpdated),
                IsSuccess=true
                
            };
            }
            catch (Exception)
            {

                return new BaseResponse<ActualRawMaterialResultDto>
                {
                    Data = new ActualRawMaterialResultDto(),
                    IsSuccess = false
                };
            }
        }

        public async Task<BaseResponse<List<ActualRawMaterialResultDto>>> GetByPeriod(int factoryid,int periodid)
        {
            var respose =

                                await _dbContext.ActualRawMaterials
                                .Where(x => x.PeriodId == periodid
                                 && x.RawMaterial.FactoryId == factoryid)
                               .Include(x => x.RawMaterial)
                               .ToListAsync();

            return new BaseResponse<List<ActualRawMaterialResultDto>>
            {
                Data = _mapper.Map<List<ActualRawMaterialResultDto>>(respose)
            };
        }

        public async Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            try
            {
                /*   var result = await _dbContext.ActualRawMaterials
                                            .Include(x => x.RawMaterial)
                                            .Where(x => x.PeriodId == periodId)
                                            //.Select(x=>x.RawMaterial.ProductRawMaterials
                                            .Where(x => x.RawMaterial.FactoryId == factoryId && x.PeriodId==periodId)
                                            .ToListAsync();*/
                var result = await _dbContext.ActualRawMaterials
                                      .Include(x => x.RawMaterial)
                                      .Where(x => x.RawMaterial.FactoryId == factoryId && x.PeriodId == periodId)
                                      .ToListAsync();

                // await _actualRawFileService.delete(factoryId, periodId);
             
                if (result.Count > 0)
                {
                    _dbContext.ActualRawMaterials.RemoveRange(result);
                }

               var  actualRawMaterialFile = await _dbContext.ActualRawMaterialFiles
                    .Where(x=>x.FactoryId==factoryId&&periodId==periodId).ToListAsync();
                if (actualRawMaterialFile.Count > 0)
                {
                    _dbContext.ActualRawMaterialFiles.RemoveRange(actualRawMaterialFile);
                }
                await _dbContext.SaveChangesAsync();


                return new BaseResponse<bool>
                {
                    Data = true,
                    IsSuccess= true,
                };
            }catch (Exception ex) {

                return new BaseResponse<bool>
                {
                    Data = false,
                    IsSuccess = false,
                };
            }

        }
    }
}
