using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryLocation.Dtos
{
    public class InspectFactoryLocationReqDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int FactoryEntityId { get; set; }
        public int CityId { get; set; }
        public int IndustrialAreaId { get; set; }
        public string WebSite { get; set; }
        public bool IsFactoryEntityCorrect { get; set; }
        public bool IsCityCorrect { get; set; }
        public bool IsIndustrialAreaCorrect { get; set; }
        public int? NewFactoryEntityId { get; set; }
        public int? NewCityId { get; set; }
        public int? NewIndustrialAreaId { get; set; }
        public string? NewWebSite { get; set; }

    }
}
