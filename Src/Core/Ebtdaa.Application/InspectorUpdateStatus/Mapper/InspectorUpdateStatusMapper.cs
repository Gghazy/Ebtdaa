using AutoMapper;
using Ebtdaa.Application.Inspectors.Dtos;
using Ebtdaa.Application.InspectorUpdateStatus.Dtos;
using Ebtdaa.Domain.InspectorUpdateStatus.Entity;

namespace Ebtdaa.Application.InspectorUpdateStatus.Mapper
{
    public class InspectorUpdateStatusMapper : Profile
    {
        public InspectorUpdateStatusMapper()
        {
            CreateMap<InspectorUpdateStatuses, InspectorFactoriesResultDto>();
            CreateMap<InspectorUpdateStatusRequestDto, InspectorUpdateStatuses>();
        }
    }
}
