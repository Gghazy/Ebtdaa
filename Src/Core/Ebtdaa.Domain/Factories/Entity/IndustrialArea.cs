using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class IndustrialArea
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}
