using Ebtdaa.Common.Dtos;
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
        public int MonthId { get; set; }
    }
}
