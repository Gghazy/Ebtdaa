using AutoMapper;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Domain.ActualRawMaterials.Entity;

namespace Ebtdaa.Application.ActualRawMaterials.Mapper
{
    public class ActualRawMaterialMapper : Profile
    {
        public ActualRawMaterialMapper()
        {
            CreateMap<ActualRawMaterial, ActualRawMaterialResultDto>();
            CreateMap<ActualRawMaterialRequestDto, ActualRawMaterial>();



            CreateMap<ActualRawMaterialFile, ActualRawFileResultDto>();
            CreateMap<ActualRawFileRequestDto, ActualRawMaterialFile>();
        }
    }
}
