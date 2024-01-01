using AutoMapper;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Domain.Factories.Entity;


namespace Ebtdaa.Application.FactoryLocations.Mapper
{
    public class FactoryLocationMapper:Profile
    {
        public FactoryLocationMapper()
        {
            CreateMap<FactoryLocationResultDto, FactoryLocation>();
            CreateMap<FactoryLocation, FactoryLocationRequestDto>();
            
            CreateMap<FactoryLocationAttachmentResultDto, FactoryLocationAttachment>();
            CreateMap<FactoryLocationAttachment, FactoryLocationAttachmentRequestDto>();
        }
    }
}
