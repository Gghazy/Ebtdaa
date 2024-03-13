using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class ProductsNotInFactorySearch:SearchCriteria
    {
        public int FactoryId { get; set; }
        public string? TxtSearch { get; set; }
    }
}
