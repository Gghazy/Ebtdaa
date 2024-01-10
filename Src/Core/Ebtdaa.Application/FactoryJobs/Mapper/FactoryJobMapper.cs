using AutoMapper;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.Integration;

namespace Ebtdaa.Application.FactoryJobs.Mapper
{
    public class FactoryJobMapper:Profile
    {
        public FactoryJobMapper()
        {
            CreateMap<FactoryIntegration, Factory>()
                      .ForMember(d => d.NameAr, opt => opt.MapFrom(src => src.FactoryName_ar))
                      .ForMember(d => d.Id, opt => opt.Ignore())
                      .ForMember(d => d.NameEn, opt => opt.MapFrom(src => src.FactoryName_en));

        }
    }
}
