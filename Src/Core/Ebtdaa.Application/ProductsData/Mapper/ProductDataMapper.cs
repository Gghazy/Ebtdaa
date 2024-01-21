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
            CreateMap<Product, ProductRequestDto>();
            CreateMap<QueryResult<Product>, QueryResult<ProductRequestDto>>();


            CreateMap<Product , ProductResultDto>();
            CreateMap<ProductResultDto, Product>();

            CreateMap<Product , ProductResultDto>();
            CreateMap<ProductResultDto, Product>();

            CreateMap<Product ,ProductAttachmentRequestDto>();
            CreateMap<ProductAttachmentResultDto, Product>();  
        }
    }
}
