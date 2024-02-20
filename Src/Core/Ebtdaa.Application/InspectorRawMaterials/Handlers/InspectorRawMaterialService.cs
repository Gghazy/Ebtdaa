using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectorRawMaterials.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Interfaces;
using Ebtdaa.Application.InspectorRawMaterials.Validation;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.InspectorRawMaterials.Handlers
{
    public class InspectorRawMaterialService : IInspectorRawMaterialService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly InspectorRawMaterialValidator _inspectorRawMaterialValidtor;

        public InspectorRawMaterialService(IEbtdaaDbContext dbContext, IMapper mapper, InspectorRawMaterialValidator inspectorRawMaterialValidtor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _inspectorRawMaterialValidtor = inspectorRawMaterialValidtor;
        }



        public async Task<BaseResponse<InspectorRawMaterialResultDto>> AddAsync(InspectorRawMaterialRequestDto req)
        {
            var InspectorrawMaterial = _mapper.Map<InspectorRawMaterial>(req);
            var result = await _inspectorRawMaterialValidtor.ValidateAsync(InspectorrawMaterial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);



            await _dbContext.InspectorRawMaterials.AddAsync(InspectorrawMaterial);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectorRawMaterialResultDto>
            {
                Data = _mapper.Map<InspectorRawMaterialResultDto>(InspectorrawMaterial)
            };
        }

        public async Task<BaseResponse<List<InspectorRawMaterialResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<InspectorRawMaterialResultDto>>
                (await _dbContext.InspectorRawMaterials
                  .Include(x => x.RawMaterial)
                  .ToListAsync());

            return new BaseResponse<List<InspectorRawMaterialResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<InspectorRawMaterialResultDto>> GetByFactory(int id)
        {
            var respose = _mapper.Map<InspectorRawMaterialResultDto>
                            (await _dbContext.InspectorRawMaterials
                                         .Include(s => s.RawMaterial)
                                             .Where(x => x.RawMaterial.FactoryId == id)
                                             .ToListAsync());


            return new BaseResponse<InspectorRawMaterialResultDto>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<InspectorRawMaterialResultDto>> GetOne(int id)
        {
            var result = await _dbContext.InspectorRawMaterials
                   .FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<InspectorRawMaterialResultDto>
            {
                Data = _mapper.Map<InspectorRawMaterialResultDto>(result)
            };
        }

        public async Task<BaseResponse<InspectorRawMaterialResultDto>> UpdateAsync(InspectorRawMaterialRequestDto req)
        {
            var inspectorRawMaterial = await _dbContext.InspectorRawMaterials.FirstOrDefaultAsync(x => x.Id == req.Id);
            var InspectorrawMaterialUpdated = _mapper.Map(req, inspectorRawMaterial);


            var result = await _inspectorRawMaterialValidtor.ValidateAsync(InspectorrawMaterialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectorRawMaterialResultDto>
            {
                Data = _mapper.Map<InspectorRawMaterialResultDto>(InspectorrawMaterialUpdated)
            };
        }
    }
}
