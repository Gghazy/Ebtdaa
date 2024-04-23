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
    public class InspectProductDataAttachService : IInspectProductDataAttachService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        
        public InspectProductDataAttachService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<InspectProductAttachResDto>>> GetAll(int id)
        {
            var response = _mapper.Map<List<InspectProductAttachResDto>>(
                await _dbContext.InspectProductDataAttachments.Include(x => x.Attachment).ToListAsync());

            return new BaseResponse<List<InspectProductAttachResDto>>
            {
                Data = response
            };
        }

        public async Task<BaseResponse<InspectProductAttachResDto>> AddAsync(InspectProductAttachReqDto req)
        {
            var file = _mapper.Map<InspectProductDataAttachment>(req);

            await _dbContext.InspectProductDataAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectProductAttachResDto>
            {
                Data = _mapper.Map<InspectProductAttachResDto>(file)
            };
        }
    }
}
