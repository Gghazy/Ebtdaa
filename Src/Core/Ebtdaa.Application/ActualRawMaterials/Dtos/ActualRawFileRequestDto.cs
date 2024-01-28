using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualRawMaterials.Dtos
{
    public class ActualRawFileRequestDto
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int ActualRawMaterialId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
