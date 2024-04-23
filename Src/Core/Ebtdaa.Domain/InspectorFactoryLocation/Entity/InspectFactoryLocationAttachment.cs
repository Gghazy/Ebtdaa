using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InspectorFactoryLocation.Entity
{
    public class InspectFactoryLocationAttachment : BaseEntity
    {
        public int Id { get; set; }
        public FactoryLocationAttachmentType Type { get; set; }
        public string Name { get; set; }
        public int AttachmentId { get; set; }
        public int FactoryLocationId { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual FactoryLocation FactoryLocation { get; set; }
    }
}
