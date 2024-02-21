using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class IndustrialArea
    {
        public int Id { get; set; }
        public int CityCode { get; set; }
        public string CityNameAr { get; set; }
        public int IndustrialZoneTypeID { get; set; }
        public string IndustrialCityName_LandAuthority { get; set; }
        public virtual IndustiryalZoneType IndustrialZoneType { get; set; }
    }
}
