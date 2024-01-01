using AutoMapper;
using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryContacts.Mapper
{
    public class FactoryContactMapper :Profile
    {
        public FactoryContactMapper()
        {
            CreateMap<FactoryContact, FactoryContactResultDto>();
            CreateMap<FactoryContactRequestDto, FactoryContact>();
        }
    }
}
