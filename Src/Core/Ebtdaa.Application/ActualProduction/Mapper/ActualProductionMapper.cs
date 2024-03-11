using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Application.ActualProduction.Mapper
{
    public class ActualProductionMapper : Profile
    {
        public ActualProductionMapper() 
        {
            CreateMap<QueryResult<FactoryProduct>, QueryResult<ProductCapacityResultDto>>();

            CreateMap<ActualProductionRequestDto, ActualProductionAndCapacity>();
            CreateMap<ActualProductionAndCapacity, ActualProductionResultDto>()
                                                 .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.FactoryProduct.Product.ProductName));

            CreateMap<FactoryProduct, ProductCapacityResultDto>()
                                 .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                                 .ForMember(d => d.ActualProductionAndCapacityId, opt => opt.MapFrom(src => src.ActualProductionAndCapacities.Count > 0 ? src.ActualProductionAndCapacities.FirstOrDefault().Id : 0))
                                 .ForMember(d => d.DesignedCapacityUnitName, opt => opt.MapFrom(src => src.ActualProductionAndCapacities.Count > 0 ? src.ActualProductionAndCapacities.FirstOrDefault().DesignedCapacityUnit.Name : ""))
                                 .ForMember(d => d.ActualProductionUintName, opt => opt.MapFrom(src => src.ActualProductionAndCapacities.Count > 0 ? src.ActualProductionAndCapacities.FirstOrDefault().ActualProductionUint.Name : ""))
                                 .ForMember(d => d.DesignedCapacity, opt => opt.MapFrom(src => src.ActualProductionAndCapacities.Count > 0 ? src.ActualProductionAndCapacities.FirstOrDefault().DesignedCapacity : 0))
                                 .ForMember(d => d.ActualProduction, opt => opt.MapFrom(src => src.ActualProductionAndCapacities.Count > 0 ? src.ActualProductionAndCapacities.FirstOrDefault().ActualProduction : 0))
                                 .ForMember(d => d.ActualProductionWeight, opt => opt.MapFrom(src => src.ActualProductionAndCapacities.Count > 0 ? src.ActualProductionAndCapacities.FirstOrDefault().ActualProduction * src.Product.Kilograms_Per_Unit : 0));



            CreateMap<ActualProductionAttacRequestDto, ActualProductionAttachment>();

            CreateMap<ActualProductionAttachment, ActualProductionAttacResultDto>()
                                                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path));

        }
    }
}
