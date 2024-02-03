using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.RawMaterials.Handlers
{
    public class ItemAttachmentService : IItemAttachmentService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ItemAttachmentValidator _itemAttachmentValidtor;

        public ItemAttachmentService(IEbtdaaDbContext dbContext, IMapper mapper, ItemAttachmentValidator itemAttachmentValidtor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _itemAttachmentValidtor = itemAttachmentValidtor;
        }

        public async Task<BaseResponse<List<ItemAttachmentsResultDto>>> GetByItem(int id)
        {
            var respose = _mapper.Map<List<ItemAttachmentsResultDto>>(await _dbContext.RawMaterialAttachments.Where(x => x.RawMaterialId == id).ToListAsync());

            return new BaseResponse<List<ItemAttachmentsResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<ItemAttachmentsResultDto>> GetOne(int id)
        {
            var result = await _dbContext.RawMaterialAttachments.FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<ItemAttachmentsResultDto>
            {
                Data = _mapper.Map<ItemAttachmentsResultDto>(result)
            };
        }

        public async Task<BaseResponse<ItemAttachmentsResultDto>> AddAsync(ItemAttachmentsRequestDto req)
        {
            var Item = _mapper.Map<RawMaterialAttachment>(req);
            var result = await _itemAttachmentValidtor.ValidateAsync(Item);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.RawMaterialAttachments.AddAsync(Item);

            await _dbContext.SaveChangesAsync();



            return new BaseResponse<ItemAttachmentsResultDto>
            {
                Data = _mapper.Map<ItemAttachmentsResultDto>(Item)
            };
        }

        public async Task<BaseResponse<ItemAttachmentsResultDto>> UpdateAsync(ItemAttachmentsRequestDto req)
        {
            var item = await _dbContext.RawMaterialAttachments.FirstOrDefaultAsync(x => x.Id == req.Id);
            var itemUpdated = _mapper.Map(req, item);


            var result = await _itemAttachmentValidtor.ValidateAsync(itemUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ItemAttachmentsResultDto>
            {
                Data = _mapper.Map<ItemAttachmentsResultDto>(itemUpdated)
            };
        }
    }
}
