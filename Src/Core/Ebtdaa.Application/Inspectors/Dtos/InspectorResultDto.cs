using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Inspectors.Dtos
{
    public class InspectorResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string OwnerIdentity { get; set; }
        public int IndustrialAreaId { get; set; }
        public InspectorStatusEnum Status { get; set; }
    }
}
