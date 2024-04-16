using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.InspectorBasicFactoryInfo.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Handlers
{
    public class InspectFactoryFileService : IInspectFactoryFIleService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectFactoryFileService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<InspectFactoryFlieResultDto>>> GetAll(int factoryId, int periodId)
        {
            var inspectorRespose = _mapper.Map<List<InspectFactoryFlieResultDto>>(
                await _dbContext.InspectFactoryFiles.Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).Include(x => x.Attachment).ToListAsync()

                );
            if(inspectorRespose == null)
            {
                var respose = _mapper.Map<List<InspectFactoryFlieResultDto>>(
                await _dbContext.FactoryFiles.Where(x => x.FactoryId == factoryId && x.PeriodId == periodId).Include(x => x.Attachment).ToListAsync()

                );

                return new BaseResponse<List<InspectFactoryFlieResultDto>>
                {
                    Data = respose
                };
            }
            else
            {
                return new BaseResponse<List<InspectFactoryFlieResultDto>>
                {
                    Data = inspectorRespose
                };
            }
        }
        public async Task<BaseResponse<InspectFactoryFlieResultDto>> AddAsync(InspectFactoryFlieRequestDto req)
        {
            InspectFactoryFile factoryFile = _mapper.Map<InspectFactoryFile>(req);
          
            await _dbContext.InspectFactoryFiles.AddAsync(factoryFile);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<InspectFactoryFlieResultDto>
            {
                Data = _mapper.Map<InspectFactoryFlieResultDto>(factoryFile)
            };
        }
    }
}
