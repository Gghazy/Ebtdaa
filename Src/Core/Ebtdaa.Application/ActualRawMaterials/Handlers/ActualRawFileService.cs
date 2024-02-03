using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.ActualRawMaterials.Handlers
{
    public class ActualRawFileService : IActualRawFileService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ActualRawMaterialFileValidator _actualMaterialFileValidator;
        public ActualRawFileService(IEbtdaaDbContext dbContext, IMapper mapper, ActualRawMaterialFileValidator rawMaterialFileValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualMaterialFileValidator = rawMaterialFileValidator;
        }
        public async Task<BaseResponse<ActualRawFileResultDto>> AddAsync(ActualRawFileRequestDto req)
        {
            ActualRawMaterialFile file = _mapper.Map<ActualRawMaterialFile>(req);
            var result = await _actualMaterialFileValidator.ValidateAsync(file);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.ActualRawMaterialFiles.AddAsync(file);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ActualRawFileResultDto>
            {
                Data = _mapper.Map<ActualRawFileResultDto>(file)
            };
        }

        public async Task<BaseResponse<ActualRawFileResultDto>> DeleteAsync(int id)
        {
            var file = await _dbContext.ActualRawMaterialFiles.FindAsync(id);

            _dbContext.ActualRawMaterialFiles.Remove(file);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ActualRawFileResultDto>
            {
                Data = _mapper.Map<ActualRawFileResultDto>(file)
            };
        }

        public async Task<BaseResponse<List<ActualRawFileResultDto>>> GetByFactory(int id)
        {
            var respose = _mapper.Map<List<ActualRawFileResultDto>>(
                await _dbContext.ActualRawMaterialFiles
                .Where(x=>x.FactoryId ==id)
                .Include(x => x.Attachment).ToListAsync());

            return new BaseResponse<List<ActualRawFileResultDto>>
            {
                Data = respose
            };
        }
    }
}
