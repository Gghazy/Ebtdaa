using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class FactoryFinancialAttachment: BaseEntity
    {
        public int Id { get; set; }
        public FactoryFinancialFileType Type { get; set; }
        public int AttachmentId { get; set; }
        public int FactoryFinancialId { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual FactoryFinancial FactoryFinancial { get; set; }
    }
}
