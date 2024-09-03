using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.Periods;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Ebtdaa.Application.RawMaterials.Handlers
{
    public class RawMaterialServie : IRawMaterialService
    {
        private readonly IEbtdaaDbContext _dbContext;
        private readonly IItemAttachmentService _itemAttachmentService;
        public readonly IMapper _mapper;
        private readonly RawMaterialValidtor _rawMaterialValidtor;

        public RawMaterialServie(IEbtdaaDbContext dbContext, IMapper mapper, RawMaterialValidtor rawMaterialValidtor, IItemAttachmentService itemAttachmentService)
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
               // var result = await _dbContext.RawMaterials
                 //    .Include(s => s.ProductRawMaterials)
                   //  .ThenInclude(x => x.Product)
                     //.FirstOrDefaultAsync(x => x.Id == id);

                List< ProductRawMaterial> ProductRawMateriallist= new List< ProductRawMaterial >();
                foreach (var item in req.FactoryProductId)
                {
                    //var x = new ProductRawMaterial();
                    //x.ProductId = item;
                    //x.rawMaterialId = rawMaterial.Id;
                    ProductRawMateriallist.Add(
                         new ProductRawMaterial
                         {
                             ProductId = item.ProductId,
                             ProductNameInRaw=item.ProductNameInRaw,
                             rawMaterialId = rawMaterial.Id
                         }
                        ); ;

                }
                await _dbContext.ProductRawMaterials.AddRangeAsync(ProductRawMateriallist);

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
                    Data = _mapper.Map<RawMaterialResultDto>(rawMaterial),
                    IsSuccess = true

                };
            }
            catch (Exception ex)
            {
               
                return new BaseResponse<RawMaterialResultDto>
                {
                    Data = new RawMaterialResultDto(),
                    IsSuccess = false
                };
            }
        }



        public async Task<BaseResponse<RawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.RawMaterials
                     .Include(s => s.ProductRawMaterials)
                     .ThenInclude(x => x.Product)
                     .FirstOrDefaultAsync(x => x.Id == id);

            string resultPhoto = "", resultfile = "";
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
                         .Select(prm =>new FactoryProductInRaw
                         {
                            ProductId= prm.ProductId,
                            ProductNameInRaw= prm.ProductNameInRaw,
                         })
                         .ToList();
                }
                else
                {
                    x.FactoryProductId = new List<FactoryProductInRaw>();
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
                if(rawMaterial!=null)
                _dbContext.ProductRawMaterials.RemoveRange(rawMaterial.ProductRawMaterials);
                foreach (var item in req.FactoryProductId)
                {
                    var productRawMateriall = new ProductRawMaterial
                    {
                        ProductId = item.ProductId,
                        rawMaterialId = rawMaterialUpdated.Id,
                        ProductNameInRaw = item.ProductNameInRaw,
                        
                    };

                    await _dbContext.ProductRawMaterials.AddAsync(productRawMateriall);

                }

                var actualRawMaterial = await _dbContext.ActualRawMaterials
                                            .FirstOrDefaultAsync(x => x.RawMaterialId== req.Id);
                if (actualRawMaterial != null)
                {
                    actualRawMaterial.CurrentStockQuantity_KG =
                       (actualRawMaterial.CurrentStockQuantity * (double)req.AverageWeightKG);

                    actualRawMaterial.UsedQuantity_KG =
                       (actualRawMaterial.UsedQuantity * (double)req.AverageWeightKG);

                }
                await _dbContext.SaveChangesAsync();

                return new BaseResponse<RawMaterialResultDto>
                {
                    Data = _mapper.Map<RawMaterialResultDto>(rawMaterialUpdated),
                    IsSuccess = true
                };
            }
            catch (Exception)
            {
                
                return new BaseResponse<RawMaterialResultDto>
                {
                    Data = new RawMaterialResultDto(),
                    IsSuccess = false
                };
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
            try
            {
                var material = await _dbContext.RawMaterials.FirstOrDefaultAsync(x => x.Id == id);

                var actualRawmaterial = await _dbContext.ActualRawMaterials.FirstOrDefaultAsync(x => x.RawMaterialId == id);
                if (actualRawmaterial != null)
                    _dbContext.ActualRawMaterials.Remove(actualRawmaterial);

                var productRawMaterial = await _dbContext.ProductRawMaterials.Where(x => x.rawMaterialId == id).ToListAsync();
                if (productRawMaterial.Count != 0)
                    _dbContext.ProductRawMaterials.RemoveRange(productRawMaterial);

                _dbContext.RawMaterials.Remove(material);


                //  _dbContext.RawMaterials.State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();

                return new BaseResponse<RawMaterialResultDto>
                {
                    Data = _mapper.Map<RawMaterialResultDto>(material),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<RawMaterialResultDto>
                {
                    Data = new RawMaterialResultDto(),
                    IsSuccess = false
                };

            }
        }
        public async Task<List<RawMaterialResultDto>> addAcutalRawMaterial(int periodId, int factoryId)
        {
            var rawMaterialsList = await _dbContext.RawMaterials
                .Include(x => x.ProductRawMaterials)
               .ThenInclude(x => x.Product)
               .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
               .Select(r => new RawMaterialResultDto
               {
                   Id = r.Id,
                   RawMaterialName = r.RawMaterialName,
                   CustomItemName = r.CustomItemName,
                   Name = r.Name,
                   PeriodId = r.PeriodId,
                   FactoryId = r.FactoryId,
                   UnitId = r.UnitId,
                   AverageWeightKG=r.AverageWeightKG,


               })
                .ToListAsync();

            List<ActualRawMaterial> actualRawMaterialsList = new List<ActualRawMaterial>();
            foreach (var rawMaterial in rawMaterialsList)
            {

                actualRawMaterialsList.Add(
                     new ActualRawMaterial
                     {
                         RawMaterialId = rawMaterial.Id,
                         PeriodId = rawMaterial.PeriodId,
                         StockUnitId = rawMaterial.UnitId,
                         UsageUnitId = rawMaterial.UnitId,
                         CurrentStockQuantity_KG = 0,
                         UsedQuantity_KG = 0,
                         UsedQuantity = 0,
                         CurrentStockQuantity = 0,
                     });

            }
            await _dbContext.ActualRawMaterials.AddRangeAsync(actualRawMaterialsList);
            await _dbContext.SaveChangesAsync();

            return rawMaterialsList;
        }
     
    //
    public async Task<BaseResponse<List<RawMaterialResultDto>>> getAllRawMaterial(RawMaterialSearch search, int id)
        {

            var periodId = search.PeriodId;
            var factoryId = id;


            var rawMaterials = await _dbContext.RawMaterials
                 .Include(x => x.ProductRawMaterials)
                .ThenInclude(x => x.Product)
                .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                .Select(r => new RawMaterial
                {
                    Id = r.Id,
                    RawMaterialName = r.RawMaterialName,
                    CustomItemName = r.CustomItemName,
                    Name = r.Name,
                    PeriodId = r.PeriodId,
                    FactoryId = r.FactoryId,
                    UnitId = r.UnitId,
                    PaperId=r.PaperId,
                    PhotoId=r.PhotoId,


                })
                .ToListAsync();
          /*  var ids = rawMaterials.Select(c => c.Id);
           
           if (rawMaterials.Count >0 )
                 _dbContext.RawMaterials.RemoveRange(rawMaterials);
            var ACUTALrawMaterials = await _dbContext.ActualRawMaterials.Where(x => x.PeriodId == periodId && ids.Contains(x.RawMaterialId)).ToListAsync();
            if (ACUTALrawMaterials.Count > 0)
                _dbContext.ActualRawMaterials.RemoveRange(ACUTALrawMaterials);
            var de1 = await _dbContext.ProductPeriodActives.Where(x => x.PeriodId == periodId&& x.FactoryId==factoryId).ToListAsync();
            if (de1.Count > 0)
                _dbContext.ProductPeriodActives.RemoveRange(de1);

          
            var de3 = await _dbContext.FactoryProducts.Where(x => x.PeriodId == periodId && x.FactoryId == factoryId).ToListAsync();
            if (de3.Count > 0)
                _dbContext.FactoryProducts.RemoveRange(de3);
            var delis = de3.Select(r => r.ProductId).ToList();
            var de2 = await _dbContext.ActualProductionAndCapacities.Where(x => x.PeriodId == periodId && delis.Contains(x.FactoryProductId)).ToListAsync();
            if (de2.Count > 0)
                _dbContext.ActualProductionAndCapacities.RemoveRange(de2);
            await _dbContext.SaveChangesAsync();*/
           
            List<RawMaterialResultDto> rawMaterialsList = new List<RawMaterialResultDto>();
            if (rawMaterials.Count ==0)
            {



                

                

                var getCR = await _dbContext.Factories.FirstOrDefaultAsync(f => f.Id == factoryId);

                var productActive = await _dbContext.RawMaterials
                    .Include(x => x.ProductRawMaterials)
                   .Where(x => x.FactoryId == factoryId && x.CreatedDate.Year == DateTime.Now.Year )
                   .OrderByDescending(e => e.PeriodId)
                   .ToListAsync();

                var productActiveId = productActive
                  .Select(x => Int32.Parse(x.CustomItemName)).ToList();

                var productRawMaterials = productActive
                  .Select(x => x.ProductRawMaterials).ToList();

                var productActiveData = productActive
                .Select(x => new { CustomItemId = x.CustomItemName, Name = x.Name, AverageWeightKG = x.AverageWeightKG }).ToList();
                
                string name = "";
                decimal averageWeightKG = 0;

             

                rawMaterialsList =
                       await _dbContext.Products
                       .Include(x => x.Unit)
                       .Include(x => x.ProductPeriodActives)
                      .Where(r => r.CR == getCR.CommercialRegister || productActiveId.Contains(r.Id))
                       .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                       new RawMaterialResultDto
                       {
                           RawMaterialName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                           CustomItemName= a.Id+"",
                           Name = "",
                           PeriodId = periodId,
                           FactoryId = factoryId,
                           UnitId = a.UnitId != null ? (int)a.UnitId : 0,
                           AverageWeightKG =0,



                       })
                       .ToListAsync();
               


                if (rawMaterialsList.Count > 0)
                {
                    /*foreach (var rawMat in rawMaterialsList.Where(r=>productActiveId.Contains(Int32.Parse(r.CustomItemName))))
                    {
                        rawMat.Name = productActiveData.FirstOrDefault(t => t.CustomItemId == rawMat.CustomItemName).Name;
                        rawMat.AverageWeightKG = productActiveData.FirstOrDefault(t => t.CustomItemId == rawMat.CustomItemName).AverageWeightKG;

                    }*/
                    DateTime tt = DateTime.Now;

                    var lastrawM = productActive
                       .Where(t => t.PeriodId < periodId)
                       .GroupBy(r => r.PeriodId)
                       .FirstOrDefault();

                    List<RawMaterial> r = new List<RawMaterial>();
                    foreach (var item in rawMaterialsList)
                    {
                        
                        var itemPast = lastrawM != null? lastrawM.Where(t => t.CustomItemName == item.CustomItemName).FirstOrDefault():null;
                        
                        if(itemPast!=null)
                        {
                            r.Add(new RawMaterial
                            {
                                RawMaterialName = item.RawMaterialName,
                                CustomItemName = item.CustomItemName,
                                Name = itemPast.Name,
                                PeriodId = item.PeriodId,
                                FactoryId = item.FactoryId,
                                UnitId = item.UnitId,
                                AverageWeightKG = itemPast.AverageWeightKG,
                                PaperId = itemPast.PaperId,
                                PhotoId= itemPast.PhotoId,
                                MaximumMonthlyConsumption=itemPast.MaximumMonthlyConsumption,
     
                            });
                        
                        }
                        else
                        r.Add(new RawMaterial
                        {
                            RawMaterialName = item.RawMaterialName,
                            CustomItemName = item.CustomItemName,
                            Name = item.Name,
                            PeriodId = item.PeriodId,
                            FactoryId = item.FactoryId,
                            UnitId = item.UnitId,
                            AverageWeightKG=item.AverageWeightKG,

                        }
                            );
                    }
                    await _dbContext.RawMaterials.AddRangeAsync(r);
                   await _dbContext.SaveChangesAsync();


                    List<ProductRawMaterial> ProductRawMateriallist = new List<ProductRawMaterial>();
                    foreach (var item in r)
                    {
                        var itemPast = lastrawM!=null? lastrawM.Where(t => t.CustomItemName == item.CustomItemName).FirstOrDefault():null;
                        if (itemPast != null)
                        {
                            foreach (var itemProductRawMaterial in itemPast.ProductRawMaterials)
                            {
                             ProductRawMateriallist.Add(
                             new ProductRawMaterial
                             {
                                 ProductId = itemProductRawMaterial.ProductId,
                                 ProductNameInRaw=itemProductRawMaterial.ProductNameInRaw,
                                 rawMaterialId = item.Id,
                             }
                            );
                            }
                            
                         }

                    }
                    await _dbContext.ProductRawMaterials.AddRangeAsync(ProductRawMateriallist);

                    rawMaterialsList = await addAcutalRawMaterial(periodId,factoryId);
                    

                }

            }
            else
            {
                rawMaterialsList = _mapper.Map<List<RawMaterialResultDto>>(rawMaterials);




            }



            return new BaseResponse<List<RawMaterialResultDto>>
                {
                    Data = rawMaterialsList
                };
            }
            
        
         //
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
                              RawMaterialName = mappingProduct.Hs12NameAr + " (" + mappingProduct.Hs12Code + ")",
                              Name = rawMaterial.Name,
                              FactoryProductId = _dbContext.ProductRawMaterials
                .Where(prm => prm.rawMaterialId == rawMaterial.Id)
                .Select(prm =>new FactoryProductInRaw
                {
                    ProductId = prm.ProductId,
                    ProductNameInRaw= prm.ProductNameInRaw
                }
               )
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
