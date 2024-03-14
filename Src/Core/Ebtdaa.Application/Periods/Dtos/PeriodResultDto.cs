using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Periods.Dtos
{
    public class PeriodResultDto
    {
        public int Id { get; set; }
        public string PeriodName { get; set; }
        public string PeriodStartDate { get; set; }
        public string PeriodEndDate { get; set; }
        public bool Status { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

    }
}
