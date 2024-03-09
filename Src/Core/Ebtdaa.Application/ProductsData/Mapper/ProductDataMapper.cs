﻿using AutoMapper;
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


            CreateMap<Product, ProductResultDto>()
                 .ForMember(d => d.UnitName, opt => opt.MapFrom(src => src.Unit.Name));
            CreateMap<QueryResult<Product>, QueryResult<ProductResultDto>>();

            CreateMap<ProductPeriodActiveRequestDto, ProductPeriodActive>();
            CreateMap<ProductPeriodActive, ProductPeriodActiveResultDto>();

        }
    }
}
