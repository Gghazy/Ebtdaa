using AutoMapper;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Application.ReasoneIncreasDesingCapacity.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.CustomsItem.CustomsItemLevel.Entity;
using Ebtdaa.Domain.General;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ReasoneIncreasDesingCapacity.Mapper
{
    public class ReasoneIncreaseMapper :Profile
    {
        public ReasoneIncreaseMapper() 
        {
            CreateMap<QueryResult<ReasonIncreasCapacity>,QueryResult<ReasoneIncreaseCapacityRequestDto>>();
            CreateMap<QueryResult<ReasoneIncreaseCapacityRequestDto>, QueryResult<ReasonIncreasCapacity>>();
        }
    }

}
