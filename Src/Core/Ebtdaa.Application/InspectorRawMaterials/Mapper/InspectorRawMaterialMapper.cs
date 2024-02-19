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
        }
    }
}
