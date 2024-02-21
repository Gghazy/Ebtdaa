using AutoMapper;
using Ebtdaa.Application.IndustiryalZone.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustiryalZone.Mapper
{
    public class IndustiryalZoneTypeMapper : Profile
    {
        public IndustiryalZoneTypeMapper() 
        {
            CreateMap<IndustiryalZoneType, IndustiryalZoneTypeResultDto>();
            CreateMap<IndustiryalZoneTypeRequestDto, IndustiryalZoneType>();
        }  
    }
}
