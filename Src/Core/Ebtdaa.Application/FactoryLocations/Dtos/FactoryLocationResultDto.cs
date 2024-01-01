using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Dtos
{
    public class FactoryLocationResultDto
    {
        public int Id { get; set; }
        public int FactoryEntityId { get; set; }
        public int CityId { get; set; }
        public int IndustrialAreaId { get; set; }
        public string WebSite { get; set; }
        public int FactoryId { get; set; }
    }
}
