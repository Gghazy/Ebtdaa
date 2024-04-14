using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InspectorProductData.Entity
{
    public class InspectProductPhoto : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int ProductPhotoId { get; set; }
        public string ProductId { get; set; }
        public bool IsProductPhotoCorrect { get; set; }
        public int NewProductPhotoId { get; set; }
        public string Comments { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
        public virtual FactoryProduct FactoryProduct { get; set; }
    }
}
