using AutoMapper;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryLocation.Mapper
{
    public class InspectFactoryLocationMapper : Profile
    {
        public InspectFactoryLocationMapper() 
        {
            CreateMap<InspectFactoryLocation,InspectFactoryLocationResDto>();
            CreateMap<InspectFactoryLocationReqDto, InspectFactoryLocation>();

            CreateMap<InspectFactoryLocationAttachment, InspectFactoryLocationAttachResDto>()
                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path))
                .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.Attachment.Extension));
            CreateMap<InspectFactoryLocationAttachReqDto, InspectFactoryLocationAttachment>();
        }
    }
}
