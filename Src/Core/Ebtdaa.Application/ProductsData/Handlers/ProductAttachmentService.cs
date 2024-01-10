using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Application.ProductsData.Validatiton;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Handlers
{
    public class ProductAttachmentService : IProductAttachmentService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ProductAttachmentValidatorcs _validator;
        public ProductAttachmentService(IEbtdaaDbContext dbContext, IMapper mapper, ProductAttachmentValidatorcs validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<List<ProductAttachmentResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<ProductAttachmentResultDto>>(await _dbContext.FactoryFinancialAttachments.ToListAsync());

            return new BaseResponse<List<ProductAttachmentResultDto>>
            {
                Data = respose
            };
        }
        public async Task<BaseResponse<ProductAttachmentResultDto>> AddAsync(ProductAttachmentRequestDto req)
        {
            var file = _mapper.Map<ProductAttachment>(req);
            var result = await _validator.ValidateAsync(file);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.ProductAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ProductAttachmentResultDto>
            {
                Data = _mapper.Map<ProductAttachmentResultDto>(file)
            };
        }

        public async Task<BaseResponse<ProductAttachmentResultDto>> DeleteAsync(int id)
        {
            var file = await _dbContext.ProductAttachments.FindAsync(id);

            _dbContext.ProductAttachments.Remove(file);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ProductAttachmentResultDto>
            {
                Data = _mapper.Map<ProductAttachmentResultDto>(file)
            };
        }
    }
}
