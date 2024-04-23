using AutoMapper;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using Ebtdaa.Domain.InspectorProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Mapper
{
    public class InspectProductMapper : Profile
    {
        public InspectProductMapper() 
        {
            CreateMap<InspectProductsRequestDto, InspectProductPhoto>();
            CreateMap<InspectProductPhoto, InspectProductsResultDto>();

            CreateMap<InspectProductDataAttachment, InspectProductAttachResDto>()
                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path))
                .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.Attachment.Extension));
            CreateMap<InspectProductAttachReqDto, InspectProductDataAttachment>();

        }
    }
}
