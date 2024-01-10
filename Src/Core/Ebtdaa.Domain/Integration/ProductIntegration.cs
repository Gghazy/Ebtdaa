using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Integration
{
    public class ProductIntegration
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ItemNumber { get; set; }
        public string CR { get; set; }
        public string Status { get; set; }
        public int MeasureUnitID { get; set; }
    }
}
