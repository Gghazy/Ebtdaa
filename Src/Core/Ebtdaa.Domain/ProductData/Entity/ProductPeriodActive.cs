using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ProductData.Entity
{
    public class ProductPeriodActive:BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }
        public virtual Product Product { get; set; }
    }
}
