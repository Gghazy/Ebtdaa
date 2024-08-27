using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.SMSsGetWay.Dtos;
using Ebtdaa.Application.SMSsGetWay.Interfaces;
using Ebtdaa.Common.Consts;
using Ebtdaa.Domain.SMSs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.SMSsGetWay.Handlers
{
    public class SMSService : ISMSService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public SMSService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<SMSGetWayResultDto>>> GetSMSList()
        {
                var sms = _dbContext.SMSGetWays.OrderByDescending(s => s.CreationDate).Select(s => new SMSGetWayResultDto
                {
                    ID = s.ID,
                    AllFactories = s.AllFactories,
                    Content = s.Content,
                    SendDate = s.SendDate.Date,
                    SendTime = s.SendTime,
                    SendStatus = s.SendStatus,
                    CreationDate = s.CreationDate

                }).ToList();

                var response = _mapper.Map<List<SMSGetWayResultDto>>(sms);
                return new BaseResponse<List<SMSGetWayResultDto>>
                {
                    Data = response
                };
        }
        public async Task<BaseResponse<bool>> CancelSendSMS(int Id)
        {
            var sms = _dbContext.SMSGetWays.Find(Id);

            sms.SendStatus = Const.Cancled;

            _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>
            {
                Data = true
            };
        }

        public async Task<BaseResponse<SMSGetWayResultDto>> CreateSMS(SMSGetWayRequestDto model)
        {
           
                SMSGetWay sms = new SMSGetWay()
                {
                    Content = model.Content,
                    CreationDate = DateTime.Now,
                    SendDate = model.SendDate,
                    AllFactories = model.AllFactories,
                    SendTime = model.SendTime,
                    SendStatus = Const.Scheduled,
                };

                _dbContext.SMSGetWays.Add(sms);
                _dbContext.SaveChangesAsync();

                return new BaseResponse<SMSGetWayResultDto>
                {
                    Data = _mapper.Map<SMSGetWayResultDto>(sms)
                };
           
        }
    }
}
