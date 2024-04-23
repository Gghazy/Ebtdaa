using AutoMapper;
using Ebtdaa.Application.ReverseApproval.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ReverseApproval.Mapper
{
    public class ReverseApprovalMapper : Profile
    {
        public ReverseApprovalMapper() 
        {
            CreateMap<FactoryUpdateStatus, ReverseApprovalResultDto>();
            CreateMap<ReverseApprovalRequestDto, FactoryUpdateStatus>();

        }
    }
}
