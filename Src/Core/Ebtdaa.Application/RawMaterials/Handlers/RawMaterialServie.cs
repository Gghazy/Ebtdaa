using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.Periods;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

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

                ActualRawMaterial actualRawMaterial = new ActualRawMaterial
                {
                    RawMaterialId = rawMaterial.Id,
                    PeriodId = rawMaterial.PeriodId,
                    StockUnitId = rawMaterial.UnitId,
                    UsageUnitId = rawMaterial.UnitId,
                    CurrentStockQuantity_KG = 0,
                    UsedQuantity_KG = 0,
                    UsedQuantity = 0,
                    CurrentStockQuantity = 0,
                    


                    // AverageWeightKG=rawMaterial.AverageWeightKG,
                };
                if (result.IsValid == false) throw new ValidationException(result.Errors);

                await _dbContext.ActualRawMaterials.AddAsync(actualRawMaterial);
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

            string resultPhoto ="", resultfile = "";
            if (result != null)
            {


                resultPhoto = await _dbContext.Attachments.Where(x => x.Id == result.PhotoId).Select(r => r.Name).FirstOrDefaultAsync();
                resultfile = await _dbContext.Attachments.Where(x => x.Id == result.PaperId).Select(r => r.Name).FirstOrDefaultAsync();

            }
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
                    x.PhotoName = resultPhoto;
                    x.PaperName = resultfile;
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
            var actualRawmaterial = await _dbContext.ActualRawMaterials.FirstOrDefaultAsync(x => x.RawMaterialId == id);

            var ar = _dbContext.ActualRawMaterials.Remove(actualRawmaterial);
            var r = _dbContext.RawMaterials.Remove(material);


            //  _dbContext.RawMaterials.State = EntityState.Deleted;
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
            var respose =await( from rawMaterial in _dbContext.RawMaterials
                          join product in _dbContext.Products
                              on Convert.ToInt32( rawMaterial.CustomItemName) equals product.Id
                          join mappingProduct in _dbContext.MappingProducts
                              on product.ItemNumber equals mappingProduct.Hs10Code
                          where rawMaterial.FactoryId == id && rawMaterial.PeriodId == search.PeriodId
                          select new RawMaterialResultDto
                               {
                              Id = rawMaterial.Id,
                              CustomItemName = rawMaterial.CustomItemName,
                              ProductName = mappingProduct.Hs12NameAr + " (" + mappingProduct.Hs12Code + ")",
                              Name = rawMaterial.Name,
                              FactoryProductId = _dbContext.ProductRawMaterials
                .Where(prm => prm.rawMaterialId == rawMaterial.Id)
                .Select(prm => prm.ProductId)
                .ToList(),
                              MaximumMonthlyConsumption = rawMaterial.MaximumMonthlyConsumption,
                              AverageWeightKG = rawMaterial.AverageWeightKG,
                              UnitId = rawMaterial.UnitId,
                              Description = rawMaterial.Description,
                              FactoryId = rawMaterial.FactoryId,
                              PeriodId = rawMaterial.PeriodId,
                              PhotoId = rawMaterial.PhotoId ?? 0,
                              PaperId = rawMaterial.PaperId ?? 0
                               
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
