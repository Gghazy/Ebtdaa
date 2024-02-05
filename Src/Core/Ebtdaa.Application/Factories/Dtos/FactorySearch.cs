using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Dtos
{
    public class FactorySearch :SearchCriteria
    {
        public string? OwnerIdentity { get; set; }
    }
}
