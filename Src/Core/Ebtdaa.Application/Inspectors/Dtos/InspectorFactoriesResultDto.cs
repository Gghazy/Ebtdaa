using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Inspectors.Dtos
{
    public class InspectorFactoriesResultDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int InspectorId { get; set; }
        public string FactoryName { get; set; }
        public string? CommerialNumber { get; set; }
        public string? CityName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? FactoryNumber { get; set; }
    }
}
