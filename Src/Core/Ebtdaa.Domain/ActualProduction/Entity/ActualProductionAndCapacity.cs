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
        public int ProductId { get; set; }
        public int DesignedCapacity { get; set; }
        public int DesignedCapacityUnitId { get; set; }
        public int ActualProduction {  get; set; }
        public int ActualProductionUintId { get; set; }
        public int ActualProductionWeight {  get; set; }
        public MonthsEnum MonthId { get; set; }

        public virtual Unit DesignedCapacityUnit { get; set; }
        public virtual Unit ActualProductionUint { get; set; }
        public virtual Product Product { get; set; }
    }
}
