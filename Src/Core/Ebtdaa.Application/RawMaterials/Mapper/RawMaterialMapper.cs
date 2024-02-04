using AutoMapper;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Application.RawMaterials.Mapper
{
    public class RawMaterialMapper : Profile
        {
            public RawMaterialMapper()
            {
               
            CreateMap<RawMaterial, RawMaterialResultDto>();
            CreateMap<RawMaterialRequestDto, RawMaterial>();
            CreateMap<QueryResult<RawMaterial>, QueryResult<RawMaterialResultDto>>();



          //  CreateMap<List<ProductRawMaterial>, List< RawMaterialProductDto>>();
          //  CreateMap<RawMaterialProductDto, ProductRawMaterial>();

            CreateMap<RawMaterialAttachment,ItemAttachmentsResultDto>();
            CreateMap<ItemAttachmentsRequestDto, RawMaterialAttachment>();
        }


    }
}
