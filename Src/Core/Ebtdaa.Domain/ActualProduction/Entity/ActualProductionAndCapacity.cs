using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ActualProduction.Entity
{
    public class ActualProductionAndCapacity :BaseEntity
    {
        public int Id { get; set; }
        public string AcuProductName { get; set; }
        public double AcuKilograms_Per_Unit { get; set; }
       // public int FactoryId { get; set; }


        public int FactoryProductId { get; set; }
        public decimal? DesignedCapacity { get; set; }
        public int? DesignedCapacityUnitId { get; set; }
        public double? ActualProduction {  get; set; }
        public int? ActualProductionUintId { get; set; }
        public int? ActualProductionWeight {  get; set; }
        public int PeriodId { get; set; }

        public virtual Unit DesignedCapacityUnit { get; set; }
        public virtual Unit ActualProductionUint { get; set; }
        public virtual FactoryProduct FactoryProduct { get; set; }
       // public virtual Factory Factory { get; set; }

    }
}
