using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Validation;
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
        public FactoryFinancialAttachmentService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryFinancialAttachmentValidator validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }
       

        public async Task<BaseResponse<List<FactoryFinancialAttachmentResultDto>>> GetAll(int id)
        {
            var respose = _mapper.Map<List<FactoryFinancialAttachmentResultDto>>(
                await _dbContext.FactoryFinancialAttachments.Where(x=>x.FactoryFinancialId==id).Include(x=>x.Attachment).ToListAsync()
                
                );

            return new BaseResponse<List<FactoryFinancialAttachmentResultDto>>
            {
                Data = respose
            };
        }
        public async Task<BaseResponse<FactoryFinancialAttachmentResultDto>> AddAsync(FactoryFinancialAttachmentRequestDto req)
        {
            var file = _mapper.Map<FactoryFinancialAttachment>(req);
            var result = await _validator.ValidateAsync(file);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryFinancialAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactoryFinancialAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryFinancialAttachmentResultDto>(file)
            };
        }

        public async Task<BaseResponse<FactoryFinancialAttachmentResultDto>> DeleteAsync(int id)
        {
            var file = await _dbContext.FactoryFinancialAttachments.FindAsync(id);

            _dbContext.FactoryFinancialAttachments.Remove(file);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryFinancialAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryFinancialAttachmentResultDto>(file)
            };
        }

      
    }
}
