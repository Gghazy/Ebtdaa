using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.SMSsGetWay.Dtos
{
    public class SMSGetWayResultDto
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string SendTime { get; set; }
        public string SendStatus { get; set; }
        public string Attachment { get; set; }
        public bool AllFactories { get; set; }
    }
}
