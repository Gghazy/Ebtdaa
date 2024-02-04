using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ActualProduction.Entity
{
    public class Reason
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<IncreaseActualProduction> IncreaseActualProductions { get; set; }
    }
}
