using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class FactoryFile
    {
        public int Id { get; set; }
        public FactoryFileType Type { get; set; }
        public int AttachmentId { get; set; }
        public string Name { get; set; }
        

        public virtual Attachment Attachment { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
