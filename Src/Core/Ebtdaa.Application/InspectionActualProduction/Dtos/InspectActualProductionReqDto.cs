using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Dtos
{
    public class InspectActualProductionReqDto
    {
        public int Id { get; set; }
        public int FactoryProductId { get; set; }
        public int DesignedCapacity { get; set; }
        public int ActualProduction { get; set; }
        public int DesignedCapacityUnitId { get; set; }
        public int ActualProductionUintId { get; set; }
        public bool IsDesignedCapacityCorrect { get; set; }
        public bool IsActualProductionCorrect { get; set; }
        public int? CorrectDesignedCapacity { get; set; }
        public int? CorrectActualProduction { get; set; }
        public string Comments { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId { get; set; }
    }
}
