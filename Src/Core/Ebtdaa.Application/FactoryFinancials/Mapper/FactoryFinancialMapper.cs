using AutoMapper;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Domain.Factories.Entity;


namespace Ebtdaa.Application.FactoryFinancials.Mapper
{
    public class FactoryFinancialMapper:Profile
    {
        public FactoryFinancialMapper()
        {
            CreateMap<FactoryFinancialResultDto, FactoryFinancial>();
            CreateMap<FactoryFinancial, FactoryFinancialRequestDto>();
            
            CreateMap<FactoryFinancialAttachmentResultDto, FactoryFinancialAttachment>();
            CreateMap<FactoryFinancialAttachment, FactoryFinancialAttachmentRequestDto>();
        }
    }
}
