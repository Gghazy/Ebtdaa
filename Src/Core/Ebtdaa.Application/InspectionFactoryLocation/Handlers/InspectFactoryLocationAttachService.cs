using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryLocation.Handlers
{
    public class InspectFactoryLocationAttachService : IInspectFactoryLocationAttachService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectFactoryLocationAttachService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<InspectFactoryLocationAttachResDto>>> GetAll(int FactoryId, int periodId)
        {
            try
            {
                var response = _mapper.Map<List<InspectFactoryLocationAttachResDto>>(
                    await _dbContext.InspectFactoryLocationAttachments
                    .Where(x => x.FactoryId == FactoryId && x.PeriodId == periodId)
                    .Include(x => x.Attachment).ToListAsync());

                return new BaseResponse<List<InspectFactoryLocationAttachResDto>>
                {
                    Data = response,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<InspectFactoryLocationAttachResDto>>
                {
                    Data = new List<InspectFactoryLocationAttachResDto>(),
                    IsSuccess = false

                };


            }
        }

        public async Task<BaseResponse<InspectFactoryLocationAttachResDto>> AddAsync(InspectFactoryLocationAttachReqDto req)
        {
            try
            {
                var file = _mapper.Map<InspectFactoryLocationAttachment>(req);
                file.Name = file.FactoryId
                    + DateTime.Today.Date.ToShortDateString().Replace("/", "")
                    + file.AttachmentId;
                await _dbContext.InspectFactoryLocationAttachments.AddAsync(file);

                await _dbContext.SaveChangesAsync();

                return new BaseResponse<InspectFactoryLocationAttachResDto>
                {
                    Data = _mapper.Map<InspectFactoryLocationAttachResDto>(file),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<InspectFactoryLocationAttachResDto>
                {
                    Data = new InspectFactoryLocationAttachResDto(),
                    IsSuccess = false

                };


            }
        }

        public async Task<BaseResponse<InspectFactoryLocationAttachResDto>> DeleteAsync(int id)
        {
            try
            {
                var file = await _dbContext.InspectFactoryLocationAttachments.FirstOrDefaultAsync(x => x.Id == id);
                //  var attachfile = await _dbContext.Attachments.FindAsync(file.AttachmentId);

                _dbContext.InspectFactoryLocationAttachments.Remove(file);
                //  _dbContext.Attachments.Remove(attachfile);


                await _dbContext.SaveChangesAsync();



                return new BaseResponse<InspectFactoryLocationAttachResDto>
                {
                    Data = _mapper.Map<InspectFactoryLocationAttachResDto>(file),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<InspectFactoryLocationAttachResDto>
                {
                    Data = new InspectFactoryLocationAttachResDto(),
                    IsSuccess = false

                };


            }
        }
    }
}
