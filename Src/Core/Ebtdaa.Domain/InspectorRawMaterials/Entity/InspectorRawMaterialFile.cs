using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.RawMaterials.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InspectorRawMaterials.Entity
{
    public class InspectorRawMaterialFile
    {
        public int Id { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public int AttachmentId { get; set; }
        public string Name { get; set; }
        public virtual Attachment Attachment { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
