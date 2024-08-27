using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionProductData.Dtos;
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

        public async Task<BaseResponse<List<InspectorRawMaterialResultDto>>> GetAll(int factoryId, int periodId, string ownerIdentity)
        {
            var respose =await _dbContext.InspectorRawMaterials
                  .Include(x => x.RawMaterial)
                  .Where(i => i.FactoryId == factoryId
                                && i.PeriodId == periodId && i.CreatedBy == ownerIdentity).ToListAsync();
            if (respose.Count == 0)
            {
                var result = await _dbContext.RawMaterials
                    .Where(x => x.FactoryId == factoryId && x.PeriodId==periodId)
                    .Select(x => new InspectorRawMaterialResultDto()
                    {
                       
                        FactoryId = factoryId,
                        PeriodId = periodId,
                        RawMaterialId = x.Id,
                        PhotoId = x.PhotoId ?? 0,
                        PaperId = x.PaperId ?? 0,
                        RawMaterialName = x.Name,
                        IsImageClear = true,
                        IsPaperClear = true,
                        Comment = "",
                        CorrectPaperId = 0,
                        CorrectPhotoId = 0,

                    })
                    .ToListAsync();
                var response = _mapper.Map<List<InspectorRawMaterialResultDto>>(result);

                return new BaseResponse<List<InspectorRawMaterialResultDto>>
                {
                    Data = response
                };
            }
            else
            {
                var Inspectresponse = _mapper.Map<List<InspectorRawMaterialResultDto>>(respose);

                return new BaseResponse<List<InspectorRawMaterialResultDto>>
                {
                    Data = Inspectresponse
                };
            }
        }

    }
}
