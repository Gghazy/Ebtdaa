using AutoMapper;
using Ebtdaa.Application.Periods.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.Periods;

namespace Ebtdaa.Application.Periods.Mapper
{
    public class PeriodMapper :Profile
    {
        public PeriodMapper()
        {
            CreateMap<Period, PeriodResultDto>()
                     .ForMember(b => b.Year, opt => opt.MapFrom(dest => dest.PeriodEndDate.Year))
                     .ForMember(b => b.PeriodEndDate, opt => opt.MapFrom(dest => dest.PeriodEndDate.Date.ToString("yyyy-MM-dd")))
                     .ForMember(b => b.PeriodStartDate, opt => opt.MapFrom(dest => dest.PeriodStartDate.Date.ToString("yyyy-MM-dd")));

            CreateMap<QueryResult<Period>, QueryResult<PeriodResultDto>>();

        }
    }
}
