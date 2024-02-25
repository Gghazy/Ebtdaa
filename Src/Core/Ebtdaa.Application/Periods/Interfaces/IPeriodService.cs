using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Periods.Dtos;
using Ebtdaa.Common.Dtos;


namespace Ebtdaa.Application.Periods.Interfaces
{
    public interface IPeriodService
    {

        Task<BaseResponse<QueryResult<PeriodResultDto>>> GetAll(PeriodSearch search);
        Task<BaseResponse<PeriodResultDto>> GetOne(int id);


    }
}
