using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryLocations.Validation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.FactoryLocations.Handlers
{
    public class FactoryLocationAttachmentService : IFactoryLocationAttachmentService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryLocationAttachmentValidator _validator;
        private readonly IScreenStatusService _screenStatusService;
        public FactoryLocationAttachmentService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryLocationAttachmentValidator validator, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
            _screenStatusService = screenStatusService;
        }


        public async Task<BaseResponse<List<FactoryLocationAttachmentResultDto>>> GetAll(int id,int periodId)
        {
            var respose = _mapper.Map<List<FactoryLocationAttachmentResultDto>>(
                await _dbContext.FactoryLocationAttachments
                .Where(x => x.FactoryId == id && x.PeriodId == periodId)
                .Include(x=>x.Attachment).ToListAsync());

            return new BaseResponse<List<FactoryLocationAttachmentResultDto>>
            {
                Data = respose
            };
        }
        public async Task<BaseResponse<FactoryLocationAttachmentResultDto>> AddAsync(FactoryLocationAttachmentRequestDto req)
        {
            try
            {
                var file = _mapper.Map<FactoryLocationAttachment>(req);
                file.Name = req.FactoryId
                               + DateTime.Today.Date.ToShortDateString().Replace("/", "")
                               + file.AttachmentId;
                var result = await _validator.ValidateAsync(file);
                if (result.IsValid == false) throw new ValidationException(result.Errors);
                await _dbContext.FactoryLocationAttachments.AddAsync(file);

                ///
                /*var allPeriods = await _dbContext.Periods
                      .Include(x => x.FactoryUpdateStatuses)
                      .Where(r => r.FactoryUpdateStatuses.
                      All(x => x.FactoryId == req.FactoryId)).Select(i => i.Id)
                      .ToListAsync();*/
                var allPeriods = await _dbContext.Periods
                  // .Where(x => x.PeriodStartDate.Year == DateTime.Now.Year)
                   .Select(i => i.Id)
                   .ToListAsync();

                var AllPeriodsHasData = await _dbContext.FactoryLocationAttachments
                                .Where(x => x.FactoryId == req.FactoryId &&
                                x.CreatedDate.Year == DateTime.Now.Year &&
                                allPeriods.Contains(x.PeriodId))
                                .Select(x => x.PeriodId).ToListAsync();

                AllPeriodsHasData.Add(req.PeriodId);

                var emptyPeriods = allPeriods.Except(AllPeriodsHasData).ToList();



                ///
                foreach (var item in emptyPeriods)
                {
                    var newFactoryFile = new FactoryLocationAttachment();
                    newFactoryFile.AttachmentId = file.AttachmentId;
                    newFactoryFile.FactoryId = file.FactoryId;
                    newFactoryFile.Name = file.Name;
                    newFactoryFile.Type = file.Type;

                    newFactoryFile.PeriodId = item;

                    await _dbContext.FactoryLocationAttachments.AddAsync(newFactoryFile);
                }


                await _dbContext.SaveChangesAsync();
                return new BaseResponse<FactoryLocationAttachmentResultDto>
                {
                    Data = _mapper.Map<FactoryLocationAttachmentResultDto>(file),
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<FactoryLocationAttachmentResultDto>
                {
                    Data = new FactoryLocationAttachmentResultDto(),
                    IsSuccess = false,
                };
            }
           
        }
        public async Task<BaseResponse<FactoryLocationAttachmentResultDto>> DeleteAsync(int id)
        {
            try
            {
                var file = await _dbContext.FactoryLocationAttachments.FirstOrDefaultAsync(x => x.Id == id);
                if (file != null)
                {
                    _dbContext.FactoryLocationAttachments.Remove(file);


                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse<FactoryLocationAttachmentResultDto>
                    {
                        Data = _mapper.Map<FactoryLocationAttachmentResultDto>(file),
                        IsSuccess = true
                    };
                }
                else
                {
                    return new BaseResponse<FactoryLocationAttachmentResultDto>
                    {
                        Data = new FactoryLocationAttachmentResultDto(),
                        IsSuccess = false
                    };
                }
            }
            catch(Exception ex)
            {
                return new BaseResponse<FactoryLocationAttachmentResultDto>
                {
                    Data = new FactoryLocationAttachmentResultDto(),
                    IsSuccess = false
                };

            }
        }

         public async Task<BaseResponse<FactoryLocationAttachmentResultDto>> DeleteAsync(int factoryId , int periodId)
         {
             var file = await _dbContext.FactoryLocationAttachments.FirstOrDefaultAsync(x=>x.FactoryId== factoryId && x.PeriodId == periodId);
             if(file != null)
             {
                 _dbContext.FactoryLocationAttachments.Remove(file);

             }
             await _dbContext.SaveChangesAsync();
             return new BaseResponse<FactoryLocationAttachmentResultDto>
             {
                 Data = _mapper.Map<FactoryLocationAttachmentResultDto>(file)
             };
         }

    }
}
