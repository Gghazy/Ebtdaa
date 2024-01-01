using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Attachments.Dtos
{
    public class AttachmentResultDto
    {
        public string Name { get; set; }
        public string Extention { get; set; }
        public byte[] File { get; set; }
    }
}
