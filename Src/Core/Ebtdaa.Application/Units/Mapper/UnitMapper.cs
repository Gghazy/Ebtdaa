using AutoMapper;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Domain.General;


namespace Ebtdaa.Application.Units.Mapper
{
    public class UnitMapper : Profile
    {
        public UnitMapper()
        {
            CreateMap<UnitRequestDto,Unit>();
            CreateMap<Unit,UnitResultDto>();
        }

    }
}
