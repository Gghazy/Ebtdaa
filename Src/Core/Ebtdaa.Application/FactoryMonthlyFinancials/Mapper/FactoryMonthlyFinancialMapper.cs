using AutoMapper;
using Ebtdaa.Application.FactoryMonthlyFinancials.Dtos;
using Ebtdaa.Domain.Factories.Entity;


namespace Ebtdaa.Application.FactoryMonthlyFinancials.Mapper
{
    internal class FactoryMonthlyFinancialMapper : Profile
    {
        public FactoryMonthlyFinancialMapper()
        {
            CreateMap<FactoryMonthlyFinancial, FactoryMonthlyFinancialResultDto>();
            CreateMap<FactoryMonthlyFinancialRequestDto, FactoryMonthlyFinancial>();


        }
    }
}
