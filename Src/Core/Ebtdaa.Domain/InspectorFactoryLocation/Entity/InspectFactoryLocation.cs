using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InspectorFactoryLocation.Entity
{
    public class InspectFactoryLocation : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int FactoryEntityId { get; set; }
        public int CityId { get; set; }
        public int IndustrialAreaId { get; set; }
        public string WebSite { get; set; }
        public bool IsFactoryEntityCorrect { get; set; }
        public bool IsCityCorrect { get; set; }
        public bool IsIndustrialAreaCorrect { get; set; }
        public bool IsWebSiteCorrect { get; set; }
        public int? NewFactoryEntityId { get; set; }
        public int? NewCityId { get; set; }
        public int? NewIndustrialAreaId { get; set; }
        public string NewWebSite { get; set; }
        public string Comment {  get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
        public virtual City City { get; set; }
        public virtual IndustrialArea Area { get; set; }
        public virtual FactoryEntity Entity { get; set; }
    }
}
