using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Domain.ActualProduction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Mapper
{
    public class ActualProductionMapper : Profile
    {
        public ActualProductionMapper() 
        {
            CreateMap<ActualProductionRequestDto, ActualProductionAndCapacity>();
            CreateMap<ActualProductionAndCapacity , ActualProductionRequestDto>();

            CreateMap<ActualProductionResultDto, ActualProductionAndCapacity>();
            CreateMap<ActualProductionAndCapacity, ActualProductionResultDto>();

            CreateMap<ActualProductionAttachment,ActualProductionAttacRequestDto>();
            CreateMap<ActualProductionAttacRequestDto, ActualProductionAttachment>();

            CreateMap<ActualProductionAttacResultDto,ActualProductionAttachment>();
            CreateMap<ActualProductionAttachment, ActualProductionAttacResultDto>();
        }
    }
}
