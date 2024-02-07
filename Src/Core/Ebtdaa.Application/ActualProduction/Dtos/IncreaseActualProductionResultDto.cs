using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class IncreaseActualProductionResultDto
    {
        public int Id { get; set; }
        public int? MonthId { get; set; }
        public int? ReasonId { get; set; }
    }
}
