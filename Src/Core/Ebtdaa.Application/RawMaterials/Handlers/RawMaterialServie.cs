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
           
                var rawMaterial = _mapper.Map<RawMaterial>(req);
            var productRawMaterial = _mapper.Map<List<ProductRawMaterial>>(req.ProductRawMaterial);
            var result = await _rawMaterialValidtor.ValidateAsync(rawMaterial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);


           
                await _dbContext.RawMaterials.AddAsync(rawMaterial);
                await _dbContext.SaveChangesAsync();
                foreach (var item in productRawMaterial)
                {
                    item.rawMaterialId = rawMaterial.Id;
                    await _dbContext.ProductRawMaterials.AddAsync(item);

                }
                await _dbContext.SaveChangesAsync();



                return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(rawMaterial)
            };
           
        }

       
           
        public async Task<BaseResponse<RawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.RawMaterials
                   .Include(s=>s.ProductRawMaterials)
                   .ThenInclude(x=>x.Product)
                    .FirstOrDefaultAsync(x => x.Id == id);
            
            return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(result)
            };
           
        }

        public async Task<BaseResponse<RawMaterialResultDto>> UpdateAsync(RawMaterialRequestDto req)
        {
            var rawMaterial = await _dbContext.RawMaterials.FirstOrDefaultAsync(x => x.Id == req.Id);
            var rawMaterialUpdated = _mapper.Map(req, rawMaterial);


            var result = await _rawMaterialValidtor.ValidateAsync(rawMaterialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(rawMaterialUpdated)
            };
        }

        public async Task<BaseResponse<List<RawMaterialResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<RawMaterialResultDto>>(await _dbContext.RawMaterials
                .Include(x => x.ProductRawMaterials)
                .ToListAsync());

            return new BaseResponse<List<RawMaterialResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<QueryResult<RawMaterialResultDto>>> GetByFactory(RawMaterialSearch search,int id)
        {
            var respose = _mapper.Map<QueryResult<RawMaterialResultDto>>
                            (await _dbContext.RawMaterials
                                         .Include(s => s.ProductRawMaterials)
                                             .Where(x => x.FactoryId == id )
                                             .ToQueryResult(search.PageNumber, search.PageSize));
           
          
            return new BaseResponse<QueryResult<RawMaterialResultDto>>
                {
                    Data = respose
                };




        }
    } 
}
