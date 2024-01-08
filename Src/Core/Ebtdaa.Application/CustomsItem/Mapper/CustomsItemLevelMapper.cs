using AutoMapper;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.CustomsItem.CustomsItemLevel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItem.Mapper
{
    public class CustomsItemLevelMapper : Profile
    {
        public CustomsItemLevelMapper() 
        {
            CreateMap<QueryResult<CustomsItemLevel>, QueryResult<CustomsItemLevelRequestDto>>();
        }
    }
}
