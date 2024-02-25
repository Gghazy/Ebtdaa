using AutoMapper;
using Ebtdaa.Application.Cities.Dtos;
using Ebtdaa.Application.CustomItemRawMaterials.Dtos;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Application.CustomItemRawMaterials.Mapper
{
    public class CustomItemRawMaterialMapper : Profile
    {
        public CustomItemRawMaterialMapper()
        {
            CreateMap<CustomItemRawMaterial, CustomItemRawMaterialResultDto>();
            CreateMap<CustomItemRawMaterialRequestDto, CustomItemRawMaterial>();
        }
    }
}
