using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ActualProduction.Entity
{
    public class ActualProductionAttachment : BaseEntity
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int ActualProduvtionId { get; set; }
        public ActualProductionFileType Type { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual ActualProductionAndCapacity ActualProduction { get; set; }
    }
}
