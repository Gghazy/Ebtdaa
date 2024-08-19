using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.SMSs
{
    public class SMSGetWay : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
