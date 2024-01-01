using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class FactoryLocation: BaseEntity
    {
        public int Id { get; set; }
        public int FactoryEntityId { get; set; }
        public int CityId { get; set; }
        public int IndustrialAreaId { get; set; }
        public string WebSite { get; set; }
        public int FactoryId { get; set; }




        public virtual FactoryEntity FactoryEntity { get; set; }
        public virtual City City { get; set; }
        public virtual IndustrialArea  IndustrialArea { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual ICollection<FactoryLocationAttachment> FactoryLocationAttachments { get; set; }


    }
}
