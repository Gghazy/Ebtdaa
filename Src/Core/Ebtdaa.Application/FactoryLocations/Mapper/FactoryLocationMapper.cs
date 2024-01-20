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
            CreateMap<FactoryLocation,FactoryLocationResultDto>();
            CreateMap<FactoryLocationRequestDto,FactoryLocation>();
            
            CreateMap<FactoryLocationAttachment, FactoryLocationAttachmentResultDto>();
            CreateMap<FactoryLocationAttachmentRequestDto, FactoryLocationAttachment>();
        }
    }
}
