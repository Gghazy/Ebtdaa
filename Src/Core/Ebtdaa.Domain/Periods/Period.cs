using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Ebtdaa.Domain.InspectorUpdateStatus.Entity;
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
      

        public virtual ICollection<FactoryMonthlyFinancial> FactoryMonthlyFinancials { get; set; }
        public virtual ICollection<ProductPeriodActive> ProductPeriodActives { get; set; }
        public virtual ICollection<FactoryUpdateStatus> FactoryUpdateStatuses { get; set; }
        public virtual ICollection<InspectorUpdateStatuses> InspectorUpdateStatuses { get; set; }
        public virtual ICollection<ActualRawMaterial> ActualRawMaterials { get; set; }
        public virtual ICollection<InspectorRawMaterial> InspectorRawMaterials { get; set; }
        public virtual ICollection<InspectFactoryLocation> InspectorFactoryLocations { get; set; }


    }
}
