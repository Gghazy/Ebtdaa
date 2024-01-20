using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Dtos
{
    public class FactoryLocationAttachmentRequestDto
    {
        public int Id { get; set; }
        public FactoryLocationAttachmentType Type { get; set; }
        public string Name { get; set; }
        public int AttachmentId { get; set; }
        public int FactoryLocationId { get; set; }
    }
}
