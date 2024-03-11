using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.General
{
    public class City
    {
        public int Id { get; set; }
        public int CityCode { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int FactoryEntityId { get; set; }
        public virtual FactoryEntity FactoryEntity { get; set; }

        public virtual ICollection<FactoryLocation> FactoryLocations { get; set; }
    }
}
