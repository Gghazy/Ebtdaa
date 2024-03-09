using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Integration
{
    public class UnitIntegration
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
    }
}
