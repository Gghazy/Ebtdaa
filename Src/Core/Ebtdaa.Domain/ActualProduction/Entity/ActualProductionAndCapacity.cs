using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
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
        public int CustomItemId_12 { get; set; }
        public int DesignedCapacity { get; set; }
        public int DesignedCapacityUnitId { get; set; }
        public int ActualProduction {  get; set; }
        public int ActualProductionUintId { get; set; }
        public int ActualProductionWeight {  get; set; }
        public MonthsEnum Month { get; set; }
        public int ReasoneForIncreaseCapacity { get; set; }
        public int FactoryId { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public virtual ICollection<ReasonIncreasCapacity> Reasones { get; set; }
    }
}
