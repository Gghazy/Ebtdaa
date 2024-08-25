using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Dtos
{
    public class InspectActualProductionResultDto
    { 
        public int Id { get; set; }
        public int FactoryProductId { get; set; }
        public string DesignedCapacityUnitName { get; set; }
        public string ActualProductionUintName { get; set; }
        
        public string InspectAcuProductName { get; set; }
        public decimal DesignedCapacity { get; set; }
        public double ActualProduction { get; set; }
        public int DesignedCapacityUnitId { get; set; }
        public int ActualProductionUintId { get; set; }
        public bool IsDesignedCapacityCorrect { get; set; }
        public bool IsActualProductionCorrect { get; set; }
        public decimal? CorrectDesignedCapacity { get; set; }
        public double? CorrectActualProduction { get; set; }
        public int IncreaseReasonId { get; set; }
        public string IncreaseReason { get; set; }
        public int? IncreaseReasonCorrect { get; set; }
        public bool IsIncreaseReasonCorrect { get; set; }
        public double? ActualProductionWeight { get; set; }
        public string Comments { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId { get; set; }
    }
}
