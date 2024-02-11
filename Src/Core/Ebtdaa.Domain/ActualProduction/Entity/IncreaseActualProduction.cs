using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ActualProduction.Entity
{
    public class IncreaseActualProduction
    {
        public int Id { get; set; }
        public MonthsEnum MonthId { get; set; }
        public int ReasonId { get; set; }
        public int FactoryId { get; set; }
        public Reason Reason { get; set; }
        public Factory Factory { get; set; }
    }
}
