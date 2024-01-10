﻿using AutoMapper;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Application.RawMaterials.Mapper
{
    public class RawMaterialMapper : Profile
        {
            public RawMaterialMapper()
            {
                CreateMap<RawMaterialResultDto, RawMaterial>();
                CreateMap<RawMaterial, RawMaterialRequestDto>();

              }
        

    }
}
