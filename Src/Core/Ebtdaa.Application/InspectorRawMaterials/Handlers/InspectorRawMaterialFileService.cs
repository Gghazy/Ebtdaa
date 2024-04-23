using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Interfaces;
using Ebtdaa.Application.InspectorRawMaterials.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Interfaces;
using Ebtdaa.Domain.InspectorBasicFactoryInfo.Entity;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectorRawMaterials.Handlers
{
    public class InspectorRawMaterialFileService : IInspectorRawMaterialFileService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectorRawMaterialFileService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<InspectorRawMaterialFileResultDto>>> GetAll(int factoryId, int periodId)
        {
            var inspectorRespose = _mapper.Map<List<InspectorRawMaterialFileResultDto>>(
                await _dbContext.InspectorRawMaterialFiles
                    .Include(x => x.RawMaterial)
                .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).Include(x => x.Attachment).ToListAsync()

                );
            if (inspectorRespose == null)
            {
                var respose = _mapper.Map<List<InspectorRawMaterialFileResultDto>>(
                await _dbContext.InspectorRawMaterialFiles
                    .Include(x => x.RawMaterial)
                    .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).Include(x => x.Attachment).ToListAsync()

                );

                return new BaseResponse<List<InspectorRawMaterialFileResultDto>>
                {
                    Data = respose
                };
            }
            else
            {
                return new BaseResponse<List<InspectorRawMaterialFileResultDto>>
                {
                    Data = inspectorRespose
                };
            }
        }
        public async Task<BaseResponse<InspectorRawMaterialFileResultDto>> AddAsync(InspectorRawMaterialFileRequestDto req)
        {
            var factoryFile = _mapper.Map<InspectorRawMaterialFile>(req);

            await _dbContext.InspectorRawMaterialFiles.AddAsync(factoryFile);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<InspectorRawMaterialFileResultDto>
            {
                Data = _mapper.Map<InspectorRawMaterialFileResultDto>(factoryFile)
            };
        }
        }
}
