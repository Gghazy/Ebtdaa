using AutoMapper;
using Ebtdaa.Application.ReasoneIncreasDesingCapacity.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.General;


namespace Ebtdaa.Application.ReasoneIncreasDesingCapacity.Mapper
{
    public class ReasoneIncreaseMapper :Profile
    {
        public ReasoneIncreaseMapper() 
        {
            CreateMap<QueryResult<ReasonIncreasCapacity>,QueryResult<ReasoneIncreaseCapacityRequestDto>>();
            CreateMap<QueryResult<ReasoneIncreaseCapacityRequestDto>, QueryResult<ReasonIncreasCapacity>>();
        }
    }

}
