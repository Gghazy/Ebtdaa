using AutoMapper;
using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Domain.InspectorProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Mapper
{
    public class InspectProductMapper : Profile
    {
        public InspectProductMapper() 
        {
            CreateMap<InspectProductsRequestDto, InspectProductPhoto>();
            CreateMap<InspectProductPhoto, InspectProductsResultDto>();

        }
    }
}
