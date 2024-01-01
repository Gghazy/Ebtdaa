using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Attachments.Dtos
{
    public class AttachmentRequestDto
    {
        public IFormFile File { get; set; }
    }
}
