using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Dtos
{
    public class FactoryLocationAttachmentResultDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int AttachmentId { get; set; }
        public int FactoryLocationId { get; set; }
    }
}
