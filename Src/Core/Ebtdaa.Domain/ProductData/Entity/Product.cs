using Ebtdaa.Domain.CustomsItem.CustomsItemLevel.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ProductData.Entity
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ItemNumber { get; set; }
        public string CR  { get; set; }
        public string Status { get; set; }
        public int? CustomItemId_12 { get; set; }
        public string? CommericalName { get; set; }
        public int? UnitId { get; set; }
        public int? WiegthInKgm { get; set; }
        public int FactoryId { get; set; }


        public virtual Factory Factory { get; set; }

        public virtual ICollection<CustomsItemLevel> CustomsItems { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
