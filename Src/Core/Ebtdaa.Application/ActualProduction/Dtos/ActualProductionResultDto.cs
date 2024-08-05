using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class ActualProductionResultDto
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PeriodId { get; set; }
        public decimal? DesignedCapacity { get; set; }
        public int? DesignedCapacityUnitId { get; set; }
        public double? ActualProduction { get; set; }
        public int ActualProductionUintId { get; set; }
        public double? ActualProductionWeight { get; set; }
        public int MonthId { get; set; }
        public int ReasoneForIncreaseCapacity { get; set; }
        public string DesignedCapacityUnitName { get; set; }
        public string ActualProductionUintName { get; set; }
        public string ProductName { get; set; }
        public string Level12Number { get; set; }
        public string Level12ItemName { get; set; }

    }
}
