using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Dtos;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.InspectorActualProduction.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Mapper
{
    public class InspectActualProductionMapper : Profile
    {
        public InspectActualProductionMapper() 
        {
           
            CreateMap<InspectActualProductionReqDto, InspectActualProduction>();
            CreateMap<InspectActualProduction, InspectActualProductionResultDto>()
                                                 .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.FactoryProduct.Product.ProductName));

            CreateMap<FactoryProduct, InspectActualProductionResultDto>();
                               

            CreateMap<InspectActualProductionAttachReqDto, InspectActualProductionAttachment>();

            CreateMap<InspectActualProductionAttachment, InspectActualProductionAttachResDto>()
                                                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Attachment.Path))
                                                .ForMember(d => d.Extention, opt => opt.MapFrom(src => src.Attachment.Extension));
        }
    }
}
