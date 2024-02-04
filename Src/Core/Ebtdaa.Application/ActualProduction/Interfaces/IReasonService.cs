using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Interfaces
{
    public interface IReasonService
    {
        Task<BaseResponse<List<ReasonResultDto>>> GetAll();

    }
}
