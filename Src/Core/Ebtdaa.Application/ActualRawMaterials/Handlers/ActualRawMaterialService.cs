using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.ActualRawMaterials.Handlers
{
    public class ActualRawMaterialService : IActualRawMaterialService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ActualRawMaterialValidator _actualRawMaterialValidator;

        public ActualRawMaterialService(IEbtdaaDbContext dbContext, IMapper mapper, ActualRawMaterialValidator actualRawMaterial)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualRawMaterialValidator = actualRawMaterial;
            
        }

        public async Task<BaseResponse<List<ActualRawMaterialResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<ActualRawMaterialResultDto>>(await _dbContext.ActualRawMaterials.ToListAsync());

            return new BaseResponse<List<ActualRawMaterialResultDto>>
            {
                Data = respose
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
            ActualRawMaterial actualRawMaterial = _mapper.Map<ActualRawMaterial>(req);
            var result = await _actualRawMaterialValidator.ValidateAsync(actualRawMaterial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.ActualRawMaterials.AddAsync(actualRawMaterial);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ActualRawMaterialResultDto>
            {
                Data = _mapper.Map<ActualRawMaterialResultDto>(actualRawMaterial)
            };
        }
        public async Task<BaseResponse<ActualRawMaterialResultDto>> UpdateAsync(ActualRawMaterialRequestDto req)
        {
            var actualRawMaterial = await _dbContext.ActualRawMaterials.FirstOrDefaultAsync(x => x.Id == req.Id);
            var actualRawMaterialUpdated = _mapper.Map(req, actualRawMaterial);

            // Validation
            var result = await _actualRawMaterialValidator.ValidateAsync(actualRawMaterialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ActualRawMaterialResultDto>
            {
                Data = _mapper.Map<ActualRawMaterialResultDto>(actualRawMaterialUpdated)
            };
        }

       

      
    }
}
