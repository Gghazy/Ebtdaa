using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class ProductSearch:SearchCriteria
    {
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public bool IsActive { get; set; }
    }
}
