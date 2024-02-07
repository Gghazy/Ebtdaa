using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.General
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int conversionToKG { get; set; }
        public string Sign { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ActualProductionAndCapacity> ActualProductionUints { get; set; }
        public ICollection<ActualProductionAndCapacity> DesignedCapacityUnits { get; set; }
    }
}
