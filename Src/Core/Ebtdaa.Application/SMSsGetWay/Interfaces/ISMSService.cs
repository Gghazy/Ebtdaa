using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.SMSsGetWay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.SMSsGetWay.Interfaces
{
    public interface ISMSService
    {
        Task<BaseResponse<List<SMSGetWayResultDto>>> GetSMSList();
        Task<BaseResponse<bool>> CancelSendSMS(int Id);
        Task<BaseResponse<SMSGetWayResultDto>> CreateSMS(SMSGetWayRequestDto model);
    }
}
