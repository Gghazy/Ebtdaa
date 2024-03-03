using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            try
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
            catch (Exception)
            {

                throw;
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
                Data = _mapper.Map<ActualRawMaterialResultDto>(actualRawMaterialUpdated)
            };
            }
            catch (Exception)
            {

                throw;
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
    }
}
