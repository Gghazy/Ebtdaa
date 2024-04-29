using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionActualProduction.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Interfaces;
using Ebtdaa.Domain.InspectorActualProduction.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Handlers
{
    public class InspectActualProductionAttachService : IInspectActualProductionAttachService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectActualProductionAttachService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<InspectActualProductionAttachResDto>>> GetAll(int factoryId, int periodId)
        {
            var respose = _mapper.Map<List<InspectActualProductionAttachResDto>>
                (await _dbContext.InspectActualProductionAttachments.Include(x => x.Attachment).Where(x => x.FactoryId == factoryId).ToListAsync());

            return new BaseResponse<List<InspectActualProductionAttachResDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<InspectActualProductionAttachResDto>> AddAsync(InspectActualProductionAttachReqDto req)
        {
            var file = _mapper.Map<InspectActualProductionAttachment>(req);
           
            await _dbContext.InspectActualProductionAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();



            return new BaseResponse<InspectActualProductionAttachResDto>
            {
                Data = _mapper.Map<InspectActualProductionAttachResDto>(file)
            };
        }
    }
}
