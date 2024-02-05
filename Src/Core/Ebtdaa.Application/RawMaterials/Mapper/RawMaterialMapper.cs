using AutoMapper;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Application.RawMaterials.Mapper
{
    public class RawMaterialMapper : Profile
        {
            public RawMaterialMapper()
            {

            CreateMap<RawMaterial, RawMaterialResultDto>() ;
            CreateMap<RawMaterialRequestDto, RawMaterial>() ;
            CreateMap<QueryResult<RawMaterial>, QueryResult<RawMaterialResultDto>>();

            CreateMap<RawMaterialProductDto,ProductRawMaterial>();




            CreateMap<ProductRawMaterial, RawMaterialResultDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RawMaterial.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RawMaterial.Name));

            CreateMap<RawMaterial, RawMaterialProductDto>()
                .ForMember(dest => dest.RawMaterialId, opt => opt.MapFrom(src => src.ProductRawMaterials));





            //CreateMap<RawMaterialAttachment,ItemAttachmentsResultDto>();
            //CreateMap<ItemAttachmentsRequestDto, RawMaterialAttachment>();
        }


    }
}
