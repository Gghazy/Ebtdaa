using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace Ebtdaa.Application.RawMaterials.Handlers
{
    public class RawMaterialServie : IRawMaterialService
    {
        private readonly IEbtdaaDbContext _dbContext;
        private readonly IItemAttachmentService _itemAttachmentService;
        public readonly IMapper _mapper;
        private readonly RawMaterialValidtor _rawMaterialValidtor;

        public RawMaterialServie(IEbtdaaDbContext dbContext, IMapper mapper, RawMaterialValidtor rawMaterialValidtor , IItemAttachmentService itemAttachmentService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _rawMaterialValidtor = rawMaterialValidtor;
            _itemAttachmentService = itemAttachmentService;
        }
        public async Task<BaseResponse<RawMaterialResultDto>> AddAsync(RawMaterialRequestDto req)
        {
            try
            {

            
            var rawMaterial = _mapper.Map<RawMaterial>(req);
         //   var productRawMaterial = _mapper.Map<List<ProductRawMaterial>>(req.ProductRawMaterial);
            var result = await _rawMaterialValidtor.ValidateAsync(rawMaterial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);


           
                await _dbContext.RawMaterials.AddAsync(rawMaterial);
                await _dbContext.SaveChangesAsync();


                foreach (var item in req.FactoryProductId)
                {
                    var x = new ProductRawMaterial();
                            x.ProductId = item;
                    x.rawMaterialId = rawMaterial.Id;
                    

                   var products = _mapper.Map<ProductRawMaterial>(x);
                      await _dbContext.ProductRawMaterials.AddAsync(x);
                }
               await _dbContext.SaveChangesAsync();

                

                return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(rawMaterial)
            };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       
           
        public async Task<BaseResponse<RawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.RawMaterials
                     .Include(s=>s.ProductRawMaterials)
                     .ThenInclude(x=>x.Product)
                     .FirstOrDefaultAsync(x => x.Id == id);
            try
            {

                var x = _mapper.Map<RawMaterialResultDto>(result);

                if (result.ProductRawMaterials != null && result.ProductRawMaterials.Any())
                {
                   x.FactoryProductId = result.ProductRawMaterials
                        .Select(prm => prm.ProductId)
                        .ToList();
                }
                else
                {
                    x.FactoryProductId = new List<int>();
                }
                return new BaseResponse<RawMaterialResultDto>
                {
                    Data = x
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
           
        }

        public async Task<BaseResponse<RawMaterialResultDto>> UpdateAsync(RawMaterialRequestDto req)
        {
            
                try
                {
                    var rawMaterial = await _dbContext.RawMaterials
                                                .Include(s => s.ProductRawMaterials)
                                                .ThenInclude(x => x.Product)
                                                
                                                .FirstOrDefaultAsync(x => x.Id == req.Id);
                    var rawMaterialUpdated = _mapper.Map(req, rawMaterial);
                    //   var rawMaterialproductUpdated = _mapper.Map(req.ProductIds, rawMaterial.ProductRawMaterials);
                    var result = await _rawMaterialValidtor.ValidateAsync(rawMaterialUpdated);
                    if (result.IsValid == false) throw new ValidationException(result.Errors);

                    await _dbContext.SaveChangesAsync();
                    _dbContext.ProductRawMaterials.RemoveRange(rawMaterial.ProductRawMaterials);
                    foreach (var item in req.FactoryProductId)
                    {
                       var productRawMateriall = new ProductRawMaterial
                        {
                            ProductId = item,
                            rawMaterialId =rawMaterialUpdated.Id
                        };

                        await _dbContext.ProductRawMaterials.AddAsync(productRawMateriall);

                    }
                    await _dbContext.SaveChangesAsync();

                    return new BaseResponse<RawMaterialResultDto>
                    {
                        Data = _mapper.Map<RawMaterialResultDto>(rawMaterialUpdated)
                    };
                }
                catch (Exception)
                {

                    throw;
                }
           
        }

        public async Task<BaseResponse<List<RawMaterialResultDto>>> GetAll()
        {
            var data = await _dbContext.RawMaterials
                .Include(x => x.ProductRawMaterials)
                .ThenInclude(x => x.Product)
                .ToListAsync();
           
            var response = _mapper.Map<List<RawMaterialResultDto>>(data);

           

            return new BaseResponse<List<RawMaterialResultDto>>
            {
              Data = response
            };
        }
           
            public async Task<BaseResponse<RawMaterialResultDto>> DeleteAsync(int id)
        {
            var material = await _dbContext.RawMaterials.FirstOrDefaultAsync(x => x.Id == id);

            _dbContext.RawMaterials.Remove(material);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(material)
            };
        }
        public async Task<BaseResponse<QueryResult<RawMaterialResultDto>>> GetByFactory(RawMaterialSearch search,int id)
        {
            try
            {
            var respose =await _dbContext.RawMaterials
                               .Include(x=>x.ProductRawMaterials)
                               .ThenInclude(x=>x.Product)
                               .Where(x => x.FactoryId == id && x.PeriodId == search.PeriodId)
                               .Select(x=>new RawMaterialResultDto
                               {
                                  Id=x.Id,
        CustomItemName=x.CustomItemName,
       ProductName=x.ProductRawMaterials.Select(y=>y.Product.Level12ItemName).FirstOrDefault()
     + '('+ x.ProductRawMaterials.Select(y => y.Product.Level12Number).FirstOrDefault() + ')',
       
                             Name=x.Name,
       FactoryProductId=x.ProductRawMaterials.Select(x=>x.ProductId).ToList(),
       MaximumMonthlyConsumption=x.MaximumMonthlyConsumption,
       AverageWeightKG=x.AverageWeightKG,
       UnitId=x.UnitId,
       Description=x.Description,
       FactoryId=x.FactoryId,
       PeriodId=x.PeriodId,
       PhotoId=x.PhotoId??0,
       PaperId=x.PaperId??0
    })
                               .ToListAsync();

                var resultDto = respose.Select(rawMaterial =>
                {
                    var dto = _mapper.Map<RawMaterialResultDto>(rawMaterial);
                    dto.FactoryProductId = rawMaterial.FactoryProductId
                      //  .Select(prm => prm)
                        .ToList();
                        return dto;
                }).ToList();

                var mappedResult = new QueryResult<RawMaterialResultDto>(
                   resultDto,
                   resultDto.Count,
                   search.PageSize,
                   search.PageNumber);

                if (resultDto == null)
                {
                    return null;  
                }
                return new BaseResponse<QueryResult<RawMaterialResultDto>>
                {
                    Data = mappedResult
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            var result = await _dbContext.RawMaterials
                                     .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                                     .ToListAsync();

            _dbContext.RawMaterials.RemoveRange(result);

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    } 
}
