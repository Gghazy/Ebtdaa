﻿using AutoMapper;
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
            CreateMap<RawMaterial, RawMaterialResultDto>()
             .ForMember(dest => dest.FactoryProductId, opt => opt.MapFrom(src => src.ProductRawMaterials.Select(prm => prm.FactoryProductId)));



            CreateMap<QueryResult<RawMaterial>, QueryResult<RawMaterialResultDto>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));




        }


    }
}
