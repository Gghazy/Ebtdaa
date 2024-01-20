using AutoMapper;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Domain.Factories.Entity;


namespace Ebtdaa.Application.FactoryFinancials.Mapper
{
    public class FactoryFinancialMapper:Profile
    {
        public FactoryFinancialMapper()
        {
            CreateMap<FactoryFinancial, FactoryFinancialResultDto>();
            CreateMap<FactoryFinancialRequestDto,FactoryFinancial > ();
            
            CreateMap<FactoryFinancialAttachment,FactoryFinancialAttachmentResultDto> ()
                                       .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path));

            CreateMap< FactoryFinancialAttachmentRequestDto, FactoryFinancialAttachment>();
        }
    }
}
