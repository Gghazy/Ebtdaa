using Ebtdaa.Common.Enums;
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
        public DateTime EnterDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime DateApprove { get; set; }
        public DataStatus DataStatus { get; set; }

        public virtual ICollection<FactoryMonthlyFinancial> FactoryMonthlyFinancials { get; set; }
        public virtual ICollection<ProductPeriodActive> ProductPeriodActives { get; set; }
        public virtual ICollection<FactoryUpdateStatus> FactoryUpdateStatuses { get; set; }

    }
}
