﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.IndustrialAreas.Dtos
{
    public class IndustrialAreaRequestDto
    {
        public int Id { get; set; }
        public int CityCode { get; set; }
        public string NameAr { get; set; }
        public int IndustrialZoneTypeID { get; set; }
        public string IndustrialCityName_LandAuthority { get; set; }
    }
}
