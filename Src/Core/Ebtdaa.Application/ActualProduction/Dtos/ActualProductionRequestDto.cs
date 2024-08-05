using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class ActualProductionRequestDto
    {

        public int Id { get; set; }
        public int FactoryProductId { get; set; }
        public decimal? DesignedCapacity { get; set; }
        public int DesignedCapacityUnitId { get; set; }
        public double? ActualProduction { get; set; }
        public int ActualProductionUintId { get; set; }
        public double? ActualProductionWeight { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId { get; set; }
        public int? ReasoneForIncreaseCapacity { get; set; }
    }
}
