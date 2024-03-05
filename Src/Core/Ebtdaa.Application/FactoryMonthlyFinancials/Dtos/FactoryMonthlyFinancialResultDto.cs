using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryMonthlyFinancials.Dtos
{
    public class FactoryMonthlyFinancialResultDto
    {
        public int Id { get; set; }
        public decimal WaterExpenses { get; set; }
        public decimal ElectricityExpenses { get; set; }
        public decimal FuelExpenses { get; set; }
        public decimal RawMterialExpenses { get; set; }
        public decimal EmploymentExpenses { get; set; }
        public decimal OtherOperatingExpenses { get; set; }
        public decimal TotalExpenses { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
    }
}
