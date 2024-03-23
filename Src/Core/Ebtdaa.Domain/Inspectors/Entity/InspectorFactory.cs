using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Inspectors.Entity
{
    public class InspectorFactory : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int InspectorId { get; set; }

        public virtual Inspector Inspector { get; set; }
        public virtual Factory Factories { get; set; }
    }
}
