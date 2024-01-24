using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.CustomsItemUpdateData.Entity
{
    public class CustomsItemUpdate : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int ActiveProductsCount { get; set; }
        public Boolean IsActiveProduct { get; set; }
        public int CustomsItem10_Id { get; set; }
        public int CustomsItem12_Id { get; set; }
        public Boolean ValidtyCustomsClassification { get; set; }

        public virtual Factory Factory { get; set; }




    }
}
