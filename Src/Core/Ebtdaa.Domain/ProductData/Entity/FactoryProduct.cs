using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ProductData.Entity
{
    public class FactoryProduct : BaseEntity
    {
        public int Id {  get; set; }
        public int? FactoryId {  get; set; }
        public int? ProductId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
