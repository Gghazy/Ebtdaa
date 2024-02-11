using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class IncreaseActualProductionRequestDto
    {
        public int Id { get; set; }
        public MonthsEnum MonthId { get; set; }
        public int FactoryId { get; set; }

        public int ReasonId { get; set; }
    }
}
