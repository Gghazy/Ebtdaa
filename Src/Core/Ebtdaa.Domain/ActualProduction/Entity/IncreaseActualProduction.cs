using Ebtdaa.Common.Enums;
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
        public MonthsEnum Month { get; set; }
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}
