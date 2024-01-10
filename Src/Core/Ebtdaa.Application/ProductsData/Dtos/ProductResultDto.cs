using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class ProductResultDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CustomItemId_12 { get; set; }
        public string CommericalName { get; set; }
        public int UnitId { get; set; }
        public int WiegthInKgm { get; set; }
        public int ProductCount { get; set; }
        public bool AnyNewProducts { get; set; }
        public int FactoryId { get; set; }
    }
}
