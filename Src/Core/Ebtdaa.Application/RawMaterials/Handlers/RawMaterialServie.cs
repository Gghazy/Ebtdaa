using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.RawMaterials.Handlers
{
    public class RawMaterialServie : IRawMaterialService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly RawMaterialValidtor _rawMaterialValidtor;

        public RawMaterialServie(IEbtdaaDbContext dbContext, IMapper mapper, RawMaterialValidtor rawMaterialValidtor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _rawMaterialValidtor = rawMaterialValidtor;
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

                    ProductRawMaterial x = new ProductRawMaterial();
                    x.FactoryProductId = item;
                    x.rawMaterialId = rawMaterial.Id;
                    await _dbContext.ProductRawMaterials.AddAsync(x);

                }
                await _dbContext.SaveChangesAsync();



                return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(rawMaterial)
            };
            }
            catch (Exception)
            {

                throw;
            }
        }

       
           
        public async Task<BaseResponse<RawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.RawMaterials
                     .Include(s=>s.ProductRawMaterials)
                     .ThenInclude(x=>x.FactoryProduct)
                     .FirstOrDefaultAsync(x => x.Id == id);
            try
            {

                var x = _mapper.Map<RawMaterialResultDto>(result);

                if (result.ProductRawMaterials != null && result.ProductRawMaterials.Any())
                {
                   x.FactoryProductId = result.ProductRawMaterials
                        .Select(prm => prm.FactoryProductId)
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
                                        .ThenInclude(x => x.FactoryProduct)
                                        .FirstOrDefaultAsync(x => x.Id == req.Id);
            var rawMaterialUpdated = _mapper.Map(req, rawMaterial);
         //   var rawMaterialproductUpdated = _mapper.Map(req.ProductIds, rawMaterial.ProductRawMaterials);


            var result = await _rawMaterialValidtor.ValidateAsync(rawMaterialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();


                _dbContext.ProductRawMaterials.RemoveRange(rawMaterial.ProductRawMaterials);
                foreach (var item in req.FactoryProductId)
                {

                    ProductRawMaterial x = new ProductRawMaterial();
                    x.FactoryProductId = item;
                    x.rawMaterialId = rawMaterial.Id;
                    await _dbContext.ProductRawMaterials.AddAsync(x);

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
                .ThenInclude(x => x.FactoryProduct)
                .ToListAsync();
            var response = _mapper.Map<List<RawMaterialResultDto>>(data);
            return new BaseResponse<List<RawMaterialResultDto>>
            {
              Data = response
            };
        }

        public async Task<BaseResponse<QueryResult<RawMaterialResultDto>>> GetByFactory(RawMaterialSearch search,int id)
        {
            try
            {

            
            var respose =await _dbContext.RawMaterials
                            .Include(x=>x.ProductRawMaterials)
                            .ThenInclude(x=>x.FactoryProduct)
                             .Where(x => x.FactoryId == id).
                             ToListAsync();

                var resultDto = respose.Select(rawMaterial =>
                {
                    var dto = _mapper.Map<RawMaterialResultDto>(rawMaterial);
                    dto.FactoryProductId = rawMaterial.ProductRawMaterials
                        .Select(prm => prm.FactoryProductId)
                        .ToList();
                    return dto;
                }).ToList();

                var mappedResult = new QueryResult<RawMaterialResultDto>(
                   resultDto,          // Pass the list of items
    resultDto.Count,    // Set total count to the number of items in the list
    search.PageSize,    // Set page size
    search.PageNumber   
                    );

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
    } 
}
