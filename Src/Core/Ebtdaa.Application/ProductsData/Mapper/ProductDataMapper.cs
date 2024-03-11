using AutoMapper;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Application.ProductsData.Mapper
{
    public class ProductDataMapper : Profile
    {
        public ProductDataMapper() 
        {
            CreateMap<ProductRequestDto, Product>();


            CreateMap<FactoryProduct, ProductResultDto>()
                     .ForMember(d => d.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                     .ForMember(d => d.UnitName, opt => opt.MapFrom(src => src.Product.Unit.Name))
                     .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                     .ForMember(d => d.UnitId, opt => opt.MapFrom(src => src.Product.Unit.Id))
                     .ForMember(d => d.ItemNumber, opt => opt.MapFrom(src => src.Product.ItemNumber))
                     .ForMember(d => d.Level12Number, opt => opt.MapFrom(src => src.Product.Level12Number))
                     .ForMember(d => d.CR, opt => opt.MapFrom(src => src.Product.CR))
                     .ForMember(d => d.Status, opt => opt.MapFrom(src => src.Product.Status))
                     .ForMember(d => d.Review, opt => opt.MapFrom(src => src.Product.Review))
                     .ForMember(d => d.Kilograms_Per_Unit, opt => opt.MapFrom(src => src.Product.Kilograms_Per_Unit));





        CreateMap<QueryResult<FactoryProduct>, QueryResult<ProductResultDto>>();

            CreateMap<ProductPeriodActiveRequestDto, ProductPeriodActive>();
            CreateMap<ProductPeriodActive, ProductPeriodActiveResultDto>();

        }
    }
}
