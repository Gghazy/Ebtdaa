using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Ebtdaa.Application.FactoryFinancials.Handlers
{
    public class FactoryFinancialAttachmentService : IFactoryFinancialAttachmentService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryFinancialAttachmentValidator _validator;
        private readonly IScreenStatusService _screenStatusService;
        public FactoryFinancialAttachmentService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryFinancialAttachmentValidator validator, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
            _screenStatusService = screenStatusService;
        }


        public async Task<BaseResponse<List<FactoryFinancialAttachmentResultDto>>> GetAll(int Factoryid, int PeriodId)
        {
            var respose = _mapper.Map<List<FactoryFinancialAttachmentResultDto>>(
                await _dbContext.FactoryFinancialAttachments
                .Where(x=>x.FactoryId==Factoryid && x.PeriodId == PeriodId)
                .Include(x=>x.Attachment).ToListAsync()
                
                );

            return new BaseResponse<List<FactoryFinancialAttachmentResultDto>>
            {
                Data = respose
            };
        }
        public async Task<BaseResponse<FactoryFinancialAttachmentResultDto>> AddAsync(FactoryFinancialAttachmentRequestDto req)
        {
            try
            {

            var file = _mapper.Map<FactoryFinancialAttachment>(req);
            file.Name = req.FactoryId
                           + DateTime.Today.Date.ToShortDateString().Replace("/", "")
                           + file.AttachmentId;
                file.FactoryFinancialId =null;
            var result = await _validator.ValidateAsync(file);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryFinancialAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<FactoryFinancialAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryFinancialAttachmentResultDto>(file)
            };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseResponse<FactoryFinancialAttachmentResultDto>> DeleteAsync(int id)
        {
            var file = await _dbContext.FactoryFinancialAttachments
                .Include(x=>x.FactoryFinancial)
                .FirstOrDefaultAsync(x=>x.Id==id);

            _dbContext.FactoryFinancialAttachments.Remove(file);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryFinancialAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryFinancialAttachmentResultDto>(file)
            };
        }

        public async Task<BaseResponse<FactoryFinancialAttachmentResultDto>> UpdateAsync(FactoryFinancialAttachmentRequestDto req)
        {
            var file = await _dbContext.FactoryFinancialAttachments
               .Include(x => x.FactoryFinancial)
               .FirstOrDefaultAsync(x => x.Id == req.Id);

            file.FactoryFinancialId =req.FactoryFinancialId??0 ;

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryFinancialAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryFinancialAttachmentResultDto>(file)
            };
        }
    }
}
