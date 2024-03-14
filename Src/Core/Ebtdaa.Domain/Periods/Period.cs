using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Periods
{
    public class Period
    {
        public int Id { get; set; }
        public string PeriodName { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public virtual ICollection<FactoryMonthlyFinancial> FactoryMonthlyFinancials { get; set; }
        public virtual ICollection<ProductPeriodActive> ProductPeriodActives { get; set; }
        public virtual ICollection<FactoryUpdateStatus> FactoryUpdateStatuses { get; set; }

    }
}
