using AutoMapper;
using Ebtdaa.Application.InspectorRawMaterials.Dtos;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;

namespace Ebtdaa.Application.InspectorRawMaterials.Mapper
{
    public class InspectorRawMaterialMapper: Profile
    {
            public InspectorRawMaterialMapper()
        {

            CreateMap<InspectorRawMaterial, InspectorRawMaterialResultDto>();
            CreateMap<InspectorRawMaterialRequestDto, InspectorRawMaterial>();



            CreateMap<InspectorRawMaterialFile, InspectorRawMaterialFileResultDto>()
                       .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path))
                       .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.Attachment.Extension))
                       .ForMember(d => d.RawMaterialName, opt => opt.MapFrom(src => src.RawMaterial.Name));

            CreateMap<InspectorRawMaterialFileRequestDto, InspectorRawMaterialFile>();

        }
    }
}
