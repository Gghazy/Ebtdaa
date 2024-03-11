using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Handlers
{
    public class FactoryFileService : IFactoryFileService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryFileValidator _factoryFileValidator;
        private readonly IScreenStatusService _screenStatusService;

        public FactoryFileService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryFileValidator factoryFileValidator, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _factoryFileValidator = factoryFileValidator;
            _screenStatusService = screenStatusService;
        }
        public async Task<BaseResponse<List<FactoryFileResultDto>>> GetAll(int factoryId,int periodId)
        {
            var respose = _mapper.Map<List<FactoryFileResultDto>>(
                await _dbContext.FactoryFiles.Where(x=>x.FactoryId==factoryId&&x.PeriodId==periodId).Include(x=>x.Attachment).ToListAsync()
                
                );

            return new BaseResponse<List<FactoryFileResultDto>>
            {
                Data = respose
            };
        }
        public async Task<BaseResponse<FactoryFileResultDto>> AddAsync(FactoryFileRequestDto req)
        {
            FactoryFile factoryFile = _mapper.Map<FactoryFile>(req);
            var result = await _factoryFileValidator.ValidateAsync(factoryFile);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryFiles.AddAsync(factoryFile);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactoryFileResultDto>
            {
                Data = _mapper.Map<FactoryFileResultDto>(factoryFile)
            };
        }

        public async Task<BaseResponse<FactoryFileResultDto>> DeleteAsync(int id)
        {
            var factoryFile = await _dbContext.FactoryFiles.FindAsync(id);

             _dbContext.FactoryFiles.Remove(factoryFile);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactoryFileResultDto>
            {
                Data = _mapper.Map<FactoryFileResultDto>(factoryFile)
            };
        }
    }
}
