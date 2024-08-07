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
            factoryFile.Name = factoryFile.FactoryId
                            + DateTime.Today.Date.ToShortDateString().Replace("/", "")
                            + factoryFile.AttachmentId;
            var result = await _factoryFileValidator.ValidateAsync(factoryFile);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            //

            var allPeriods = await _dbContext.Periods
               .Include(x => x.FactoryUpdateStatuses)
               .Where(r => r.FactoryUpdateStatuses.
               All(x => x.FactoryId == req.FactoryId)).Select(i => i.Id)
               .ToListAsync();


            var AllPeriodsHasData = await _dbContext.FactoryFiles
                            .Where(x => x.FactoryId == req.FactoryId &&
                            allPeriods.Contains(x.PeriodId))
                            .Select(x => x.PeriodId).ToListAsync();

            AllPeriodsHasData.Add(req.PeriodId);

            var emptyPeriods = allPeriods.Except(AllPeriodsHasData).ToList();

            await _dbContext.FactoryFiles.AddAsync(factoryFile);

            ///
            foreach (var item in emptyPeriods)
            {
                var newFactoryFile = new FactoryFile();
                newFactoryFile.AttachmentId = factoryFile.AttachmentId;
                newFactoryFile.FactoryId = factoryFile.FactoryId;
                newFactoryFile.Name = factoryFile.Name;
                newFactoryFile.Type = factoryFile.Type;

                newFactoryFile.PeriodId = item;

                await _dbContext.FactoryFiles.AddAsync(newFactoryFile);
            }

            ///


            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactoryFileResultDto>
            {
                Data = _mapper.Map<FactoryFileResultDto>(factoryFile)
            };
        }

        public async Task<BaseResponse<FactoryFileResultDto>> DeleteAsync(int id)
        {
            var factoryFile = await _dbContext.FactoryFiles.FindAsync(id);
            var attachfile = await _dbContext.Attachments.FindAsync(factoryFile.AttachmentId);
          
            _dbContext.FactoryFiles.Remove(factoryFile);
            _dbContext.Attachments.Remove(attachfile);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactoryFileResultDto>
            {
                Data = _mapper.Map<FactoryFileResultDto>(factoryFile)
            };
        }
    }
}
