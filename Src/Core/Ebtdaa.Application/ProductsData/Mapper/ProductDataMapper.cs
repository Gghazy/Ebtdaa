using AutoMapper;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Mapper
{
    public class ProductDataMapper : Profile
    {
        public ProductDataMapper() 
        {
            CreateMap<ProductRequestDto, Product>();


            CreateMap<Product, ProductResultDto>()
                 .ForMember(d => d.ParentName, opt => opt.MapFrom(src => src.Parent.ProductName))
                 .ForMember(d => d.UnitName, opt => opt.MapFrom(src => src.Unit.Name));
            CreateMap<QueryResult<Product>, QueryResult<ProductResultDto>>();


            CreateMap<ProductAttachmentRequestDto,Product>();
            CreateMap<Product, ProductAttachmentResultDto>();  
        }
    }
}
