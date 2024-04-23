using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Application.InspectionProductData.Interfaces;
using Ebtdaa.Domain.InspectorProductData.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Handlers
{
    public class InspectProductsService : IInspectProductsService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public InspectProductsService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<InspectProductsResultDto>> GetOne(int factoryId, int periodId, string ownerIdentity)
        {
            var getInspectData = await _dbContext.InspectProductPhotos.FirstOrDefaultAsync(i => i.FactoryId == factoryId && i.CreatedBy == ownerIdentity);
            if (getInspectData == null)
            {
                var result = await _dbContext.FactoryProducts.Include(x => x.Product).ThenInclude(x => x.Unit).FirstOrDefaultAsync(x => x.FactoryId == factoryId);

                var mapData = new InspectProductsResultDto()
                {
                    FactoryId = factoryId,
                    Id = result.Id,
                    ProductId = result.ProductId,
                    ProductPhotoId = result.PhototId
                };
                var response = _mapper.Map<InspectProductsResultDto>(mapData);

                return new BaseResponse<InspectProductsResultDto>
                {
                    Data = response
                };
            }
            else
            {
                var Inspectresponse = _mapper.Map<InspectProductsResultDto>(getInspectData);



                return new BaseResponse<InspectProductsResultDto>
                {
                    Data = Inspectresponse
                };
            }
            
        }

        public async Task<BaseResponse<bool>> AddAsync(InspectProductsRequestDto request)
        {
            var factoryProduct = new InspectProductPhoto();
            factoryProduct.ProductId = request.ProductId;
            factoryProduct.PhotoId = request.PhotoId;
            factoryProduct.FactoryId = request.FactoryId;
            factoryProduct.ProductId = request.ProductId;
            factoryProduct.IsProductPhotoCorrect = request.IsProductPhotoCorrect;
            factoryProduct.Comments = request.Comments;
            factoryProduct.NewProductPhotoId = request.NewProductPhotoId;
            factoryProduct.PeriodId = request.PeriodId;

            
            await _dbContext.InspectProductPhotos.AddAsync(factoryProduct);
            await _dbContext.SaveChangesAsync();
            return new BaseResponse<bool>
            {
                Data = true
            };

        }

        public async Task<BaseResponse<bool>> UpdateAsync(InspectProductsRequestDto req)
        {

            var factoryProduct = await _dbContext.InspectProductPhotos.FirstAsync(x => x.Id == req.Id);
            factoryProduct.ProductId = req.ProductId;
            factoryProduct.PhotoId = req.PhotoId;
            factoryProduct.IsProductPhotoCorrect = req.IsProductPhotoCorrect;
            factoryProduct.Comments = req.Comments;
            factoryProduct.NewProductPhotoId= req.NewProductPhotoId;

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    }
}
