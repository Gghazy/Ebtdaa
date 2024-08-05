using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using Ebtdaa.Application.InspectorUpdateStatus.Dtos;
using Ebtdaa.Application.InspectorUpdateStatus.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.InspectorUpdateStatus.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.InspectorUpdateStatus.Handlers
{
    public class InspectorUpdateStatusService : IInspectorUpdateStatusService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public InspectorUpdateStatusService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<InspectorUpdateStatusResultDto>> AddAsync(InspectorUpdateStatusRequestDto req)
        {
            var UpdateStatus = _mapper.Map<InspectorUpdateStatuses>(req);

            UpdateStatus.DataStatus = Ebtdaa.Common.Enums.DataStatus.Added;
            UpdateStatus.EnteredAt = DateTime.Now;
            await _dbContext.InspectorUpdateStatuses.AddAsync(UpdateStatus);

            await _dbContext.SaveChangesAsync();
            InspectorUpdateStatusResultDto re= new InspectorUpdateStatusResultDto() ;
            if(UpdateStatus!=null)
            {
                re = new InspectorUpdateStatusResultDto
                {
                    FactoryId = UpdateStatus.FactoryId,
                    PeriodId = UpdateStatus.PeriodId,
                    UpdateStatus = UpdateStatus.UpdateStatus,
                    DataStatus = UpdateStatus.DataStatus,
                    EnteredAt = UpdateStatus.EnteredAt,
                    ApprovedAt = UpdateStatus.ApprovedAt,
                    ReviewedAt = UpdateStatus.ReviewedAt,

                };
            }
            return new BaseResponse<InspectorUpdateStatusResultDto>
            {
                Data = re
            };
        }

        public async Task<BaseResponse<InspectorUpdateStatusResultDto>> GetOne(int factoryId, int periodId)
        {
            var resualt = await _dbContext.InspectorUpdateStatuses.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            return new BaseResponse<InspectorUpdateStatusResultDto>
            {
                Data = resualt != null ? _mapper.Map<InspectorUpdateStatusResultDto>(resualt) : new InspectorUpdateStatusResultDto()
            };
        }

        public async Task<BaseResponse<InspectorUpdateStatusResultDto>> UpdateAsync(InspectorUpdateStatusRequestDto req)
        {
            var InspectorStatus = await _dbContext.InspectorUpdateStatuses.FirstOrDefaultAsync(x => x.Id == req.Id);
            var InspectorUpdated = _mapper.Map(req, InspectorStatus);
            if (InspectorStatus.DataStatus == Ebtdaa.Common.Enums.DataStatus.Added)
            {
                InspectorStatus.DataStatus = Ebtdaa.Common.Enums.DataStatus.Reviwed;
                InspectorStatus.ReviewedAt = DateTime.Now;

            }
            else if (InspectorStatus.DataStatus == Ebtdaa.Common.Enums.DataStatus.Reviwed)
            {
                InspectorStatus.DataStatus = Ebtdaa.Common.Enums.DataStatus.Approved;
                InspectorStatus.ApprovedAt = DateTime.Now;

            }


            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectorUpdateStatusResultDto>
            {
                Data = _mapper.Map<InspectorUpdateStatusResultDto>(InspectorUpdated)
            };
        }
    }
}
