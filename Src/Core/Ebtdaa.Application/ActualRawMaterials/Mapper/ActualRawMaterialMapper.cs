using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Application.ActualRawMaterials.Mapper
{
    public class ActualRawMaterialMapper : Profile
    {
        public ActualRawMaterialMapper()
        {
            CreateMap<ActualRawMaterial, ActualRawMaterialResultDto>()
                .ForMember(dest => dest.RawMaterialId, opt => opt.MapFrom(src => src.RawMaterial));
            CreateMap<ActualRawMaterialRequestDto, ActualRawMaterial>();

            CreateMap<RawMaterial, RawMaterialResultDto>();


            CreateMap<ActualRawMaterialFile, ActualRawFileResultDto>()
                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path));
            CreateMap<ActualRawFileRequestDto, ActualRawMaterialFile>();
        }
    }
}
