using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InspectorActualProduction.Entity
{
    public class InspectActualProduction : BaseEntity
    {

       


        public int Id {  get; set; }
        public int FactoryProductId { get; set; }
        public decimal? DesignedCapacity { get; set; }
        public double? ActualProduction { get; set; }
        public int DesignedCapacityUnitId { get; set; }
        public int ActualProductionUintId { get; set; }
        public bool IsDesignedCapacityCorrect { get; set; }
        public bool IsActualProductionCorrect { get; set; }
        public decimal? CorrectDesignedCapacity { get; set; }
        public double? CorrectActualProduction { get; set; }
        public int IncreaseReasonId { get; set; }
        public int? IncreaseReasonCorrect { get; set; }
        public bool IsIncreaseReasonCorrect { get; set; }
        public double? ActualProductionWeight { get; set; }
        public string Comments { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId {  get; set; }

        //public virtual Factory Factory {  get; set; }
        public virtual Unit DesignedCapacityUnit { get; set; }
        public virtual Unit ActualProductionUint { get; set; }
        public virtual FactoryProduct FactoryProduct { get; set; }
    }
}
