using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Validation;
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


        public async Task<BaseResponse<List<FactoryLocationAttachmentResultDto>>> GetAll(int id)
        {
            var respose = _mapper.Map<List<FactoryLocationAttachmentResultDto>>(await _dbContext.FactoryLocationAttachments.ToListAsync());

            return new BaseResponse<List<FactoryLocationAttachmentResultDto>>
            {
                Data = respose
            };
        }
        public async Task<BaseResponse<FactoryLocationAttachmentResultDto>> AddAsync(FactoryLocationAttachmentRequestDto req)
        {
            var file = _mapper.Map<FactoryLocationAttachment>(req);
            var result = await _validator.ValidateAsync(file);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryLocationAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();

            var FactoryLocation= await _dbContext.FactoryLocations.FirstOrDefaultAsync(x=>x.Id==req.FactoryLocationId);

            await _screenStatusService.CheckFactoryLocationScreenStatus(FactoryLocation.FactoryId);

            return new BaseResponse<FactoryLocationAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryLocationAttachmentResultDto>(file)
            };
        }

        public async Task<BaseResponse<FactoryLocationAttachmentResultDto>> DeleteAsync(int id)
        {
            var file = await _dbContext.FactoryLocationAttachments.Include(x=>x.FactoryLocation).FirstOrDefaultAsync(x=>x.Id== id);

            _dbContext.FactoryLocationAttachments.Remove(file);

            await _dbContext.SaveChangesAsync();

            await _screenStatusService.CheckFactoryLocationScreenStatus(file.FactoryLocation.FactoryId);


            return new BaseResponse<FactoryLocationAttachmentResultDto>
            {
                Data = _mapper.Map<FactoryLocationAttachmentResultDto>(file)
            };
        }

       
    }
}
