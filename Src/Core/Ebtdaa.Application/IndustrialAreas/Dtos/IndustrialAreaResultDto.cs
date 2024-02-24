using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustrialAreas.Dtos
{
    public class IndustrialAreaResultDto
    {
        public int Id { get; set; }
        public int CityCode { get; set; }
        public string CityNameAr { get; set; }
        public int IndustrialZoneTypeID { get; set; }
        public string IndustrialCityName_LandAuthority { get; set; }
    }
}
