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
            catch (Exception ex)
            { 

                throw ex;
            }
        }

       
           
        public async Task<BaseResponse<RawMaterialResultDto>> GetOne(int id)
        {
            try
            {

           
            var result = await _dbContext.RawMaterials
               //     .Include(s=>s.ProductRawMaterial)
                    .FirstOrDefaultAsync(x => x.Id == id);
            
            return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(result)
            };
            }
            catch (Exception)
            {

                throw;
            }
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
            var respose = _mapper.Map<List<RawMaterialResultDto>>(await _dbContext.RawMaterials.Include(x => x.Products).ToListAsync());

            return new BaseResponse<List<RawMaterialResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<QueryResult<RawMaterialResultDto>>> GetByFactory(RawMaterialSearch search,int id)
        {
            try
            {

           
            var respose = _mapper.Map<QueryResult<RawMaterialResultDto>>
                            (await _dbContext.RawMaterials
                                            // .Include(s => s.ProductRawMaterial)
                                             .Where(x => x.FactoryId == id )
                                             .ToQueryResult(search.PageNumber, search.PageSize));
           
          
            return new BaseResponse<QueryResult<RawMaterialResultDto>>
                {
                    Data = respose
                };



            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    } 
}
