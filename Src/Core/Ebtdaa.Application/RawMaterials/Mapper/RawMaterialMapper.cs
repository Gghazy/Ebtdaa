using AutoMapper;
using Ebtdaa.Application.ProductsData.Dtos;
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
            CreateMap<RawMaterialRequestDto, RawMaterial>();
            CreateMap<ProductRawMaterial, RawMaterialResultDto>()
                .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.FactoryProductId));
             //   .ForMember(dest => dest.RawMaterialProducts, opt => opt.MapFrom(src => src.ProductRawMaterials))
             //   .ForMember(dest => dest.RawMaterialProducts.Select(x=>x.ProductId), opt => opt.MapFrom(src => src.ProductRawMaterials.Select(x => x.FactoryProductId)));


        
           
            CreateMap<QueryResult<RawMaterial>, QueryResult<RawMaterialResultDto>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<ProductRawMaterial, RawMaterialProductDto>();
            CreateMap<Product, ProductResultDto>();




        }


    }
}
