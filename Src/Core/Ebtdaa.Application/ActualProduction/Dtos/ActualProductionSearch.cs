using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class ActualProductionSearch:SearchCriteria
    {
        public int FactoryId { get; set; }
        public MonthsEnum MonthId { get; set; }
    }
}
