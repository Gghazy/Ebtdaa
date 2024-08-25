using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Application.InspectionProductData.Interfaces;
using Ebtdaa.Domain.InspectorProductData.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public async  Task<BaseResponse<List<InspectProductsResultDto>>> GetProducts(int factoryId, int periodId , string ownerIdentity)
        {
            var getInspectData = await _dbContext.InspectProductPhotos
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(i => i.FactoryId == factoryId 
                                && i.PeriodId == periodId && i.CreatedBy == ownerIdentity)
                .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code,
                   (a, b) => new InspectProductsResultDto()
                   {
                       Id= a.Id,
                       FactoryId = a.FactoryId,
                       PeriodId = a.PeriodId,
                       ProductId = a.ProductId,
                       PhotoId = a.PhotoId ,
                       PaperId = a.PaperId,
                       ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                       IsProductPhotoCorrect = a.IsProductPhotoCorrect,
                       Comments = a.Comments,
                       NewProductPhotoId = a.NewProductPhotoId,
                       NewProductPaperId = a.NewProductPaperId,
                   })
                   .ToListAsync();
            if (getInspectData.Count == 0)
            {
                var result = await _dbContext.FactoryProducts
                    .Include(x => x.Product)
                     .ThenInclude(x => x.Unit)
                     .Where(x => x.FactoryId == factoryId && x.PeriodId==periodId)
                   .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code,
                   (a, b) =>new InspectProductsResultDto()
                    {
                        
                        FactoryId = a.FactoryId,
                        PeriodId=a.PeriodId,
                        ProductId = a.ProductId,
                        PhotoId = a.PhototId ?? 0,
                        PaperId = a.PeperId ?? 0,
                        ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                        IsProductPhotoCorrect = true,
                        Comments = "",
                        NewProductPhotoId = 0,
                        NewProductPaperId = 0,

                    }  )
                    .ToListAsync();
                var response = _mapper.Map< List< InspectProductsResultDto>>(result);

                return new BaseResponse<List<InspectProductsResultDto>>
                {
                    Data = response
                };
            }
            else
            {
                var Inspectresponse = _mapper.Map<List<InspectProductsResultDto>>(getInspectData);



                return new BaseResponse<List<InspectProductsResultDto>>
                {
                    Data = Inspectresponse
                };
            }


              
        }

        public async Task<BaseResponse<bool>> AddAsync(InspectProductsRequestDto request)
        {
            var IfFound = await _dbContext.InspectProductPhotos.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (request.NewProductPhotoId <= 0)
                request.NewProductPhotoId = null;
            if (request.NewProductPaperId <= 0)
                request.NewProductPaperId = null;
            var factoryProduct = new InspectProductPhoto();
            factoryProduct.ProductId = request.ProductId;
            factoryProduct.PhotoId = request.PhotoId;
            factoryProduct.FactoryId = request.FactoryId;
            factoryProduct.ProductId = request.ProductId;
            factoryProduct.PaperId = request.PaperId;
            factoryProduct.IsProductPhotoCorrect = request.IsProductPhotoCorrect;
            factoryProduct.Comments = request.Comments;
            factoryProduct.NewProductPhotoId = request.NewProductPhotoId;
            factoryProduct.NewProductPaperId = request.NewProductPaperId;
            factoryProduct.PeriodId = request.PeriodId;
            if (IfFound == null) {
                await _dbContext.InspectProductPhotos.AddAsync(factoryProduct);

            }
          

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<bool>
            {
                Data = true
            };
           
        }

        public async Task<BaseResponse<bool>> UpdateAsync(InspectProductsRequestDto req)
        {
            if (req.NewProductPhotoId <= 0)
                req.NewProductPhotoId = null;
            if (req.NewProductPaperId <= 0)
                req.NewProductPaperId = null;
            var factoryProduct = await _dbContext.InspectProductPhotos.FirstAsync(x => x.Id == req.Id);
            factoryProduct.ProductId = req.ProductId;
            factoryProduct.PhotoId = req.PhotoId;
            factoryProduct.IsProductPhotoCorrect = req.IsProductPhotoCorrect;
            factoryProduct.Comments = req.Comments;
            factoryProduct.NewProductPhotoId= req.NewProductPhotoId;
            factoryProduct.NewProductPaperId= req.NewProductPaperId;

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    }
}
