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

            CreateMap<RawMaterial, RawMaterialResultDto>()
            .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.ProductRawMaterials.Select(x=>x.Product)));
            CreateMap<RawMaterialRequestDto, RawMaterial>() ;
           
            CreateMap<QueryResult<RawMaterial>, QueryResult<RawMaterialResultDto>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
           
            CreateMap<Product, RawMaterialProductDto>();
             CreateMap<RawMaterialProductDto, ProductRawMaterial>();

            // CreateMap<RawMaterialProductDto, ProductRawMaterial>();




            CreateMap<ProductRawMaterial, RawMaterialResultDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RawMaterial.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RawMaterial.Name));



        }


    }
}
