using AutoMapper;
using Ebtdaa.Application.CustomsItemUpdateData.Dtos;
using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItemUpdateData.Mapper
{
    public class CustomsItemUpdateMapper :Profile
    {
       
        public CustomsItemUpdateMapper() 
        {
            CreateMap<CustomsItemUpdateResultDto, CustomsItemUpdate>();
            CreateMap<CustomsItemUpdate , CustomsItemUpdateRequestDto>();
        }
    }
}
