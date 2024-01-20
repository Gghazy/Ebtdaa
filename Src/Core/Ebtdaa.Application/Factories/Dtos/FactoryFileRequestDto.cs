using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Dtos
{
    public class FactoryFileRequestDto
    {
        public int Id { get; set; }
        public FactoryFileType Type { get; set; }
        public int AttachmentId { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
    }
}
