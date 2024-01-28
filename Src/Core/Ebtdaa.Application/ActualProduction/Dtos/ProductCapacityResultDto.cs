using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class ProductCapacityResultDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ActualProductionAndCapacityId { get; set; }
        public int DesignedCapacity { get; set; }
        public int ActualProduction { get; set; }
        public int ActualProductionWeight { get; set; }
        public int ReasoneForIncreaseCapacity { get; set; }
        public string DesignedCapacityUnitName { get; set; }
        public string ActualProductionUintName { get; set; }
        public double? Kilograms_Per_Unit { get; set; }


    }
}
