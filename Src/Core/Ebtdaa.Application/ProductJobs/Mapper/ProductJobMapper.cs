using AutoMapper;
using Ebtdaa.Domain.Integration;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductJobs.Mapper
{
    public class ProductJobMapper:Profile
    {
        public ProductJobMapper()
        {
           CreateMap<ProductIntegration, Product>()
                      .ForMember(d => d.UnitId, opt => opt.MapFrom(src => src.MeasureUnitID))
                      .ForMember(d => d.Id, opt => opt.Ignore()); 
        }
        
    }
}
