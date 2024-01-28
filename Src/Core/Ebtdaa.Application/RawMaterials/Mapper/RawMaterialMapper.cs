using AutoMapper;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Application.RawMaterials.Mapper
{
    public class RawMaterialMapper : Profile
        {
            public RawMaterialMapper()
            {
               
            CreateMap<RawMaterial, RawMaterialResultDto>();
            CreateMap<RawMaterialRequestDto, RawMaterial>();


            CreateMap<RawMaterialAttachment,ItemAttachmentsResultDto>();
            CreateMap<ItemAttachmentsRequestDto, RawMaterialAttachment>();
        }


    }
}
