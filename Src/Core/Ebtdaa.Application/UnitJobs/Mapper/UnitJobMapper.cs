using AutoMapper;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.UnitJobs.Mapper
{
    public class UnitJobMapper:Profile
    {
        public UnitJobMapper()
        {
            CreateMap<UnitIntegration, Unit>()
                     .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
