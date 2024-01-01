﻿using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.General
{
    public class Attachment : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public virtual ICollection<FactoryFile> FactoryFiles { get; set; }
        public virtual ICollection<FactoryFinancialAttachment> FactoryFinancialAttachments { get; set; }
        public virtual ICollection<FactoryLocationAttachment> FactoryLocationAttachments { get; set; }

    }
}

