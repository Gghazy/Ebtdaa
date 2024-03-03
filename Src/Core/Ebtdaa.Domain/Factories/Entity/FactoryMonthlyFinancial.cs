using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class FactoryMonthlyFinancial: BaseEntity
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

        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
    }
}
