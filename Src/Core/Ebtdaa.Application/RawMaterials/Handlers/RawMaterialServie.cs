using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
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
            var result = await _rawMaterialValidtor.ValidateAsync(rawMaterial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.RawMaterials.AddAsync(rawMaterial);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
              
           
            return new BaseResponse<RawMaterialResultDto>
            {
                Data = _mapper.Map<RawMaterialResultDto>(rawMaterial)
            };
        }

       
           
        public async Task<BaseResponse<RawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.RawMaterials.FirstOrDefaultAsync(x => x.Id == id);

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
            var respose = _mapper.Map<List<RawMaterialResultDto>>(await _dbContext.RawMaterials.Include(x => x.Product).ToListAsync());

            return new BaseResponse<List<RawMaterialResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<List<RawMaterialResultDto>>> GetByFactory(int id)
        {
            var respose = _mapper.Map<List<RawMaterialResultDto>>(await _dbContext.RawMaterials.Where(x => x.FactoryId == id).ToListAsync());

            return new BaseResponse<List<RawMaterialResultDto>>
            {
                Data = respose
            };


            }
    } 
}
