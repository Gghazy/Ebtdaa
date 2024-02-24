using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.IndustiryalZone.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustiryalZone.Interfaces
{
    public interface IIndustiryalZoneTypeService
    {
        Task<BaseResponse<List<IndustiryalZoneTypeResultDto>>> GetAll();
    }
}
