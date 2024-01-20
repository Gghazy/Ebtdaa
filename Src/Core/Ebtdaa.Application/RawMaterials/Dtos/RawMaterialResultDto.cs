using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class RawMaterialResultDto
    {
        public int Id { get; set; }
        public string CustomItemName { get; set; }
        public string Name { get; set; }
        public int MaximumMonthlyConsumption { get; set; }
        public int AverageWeightKG { get; set; }
        public int ProductId { get; set; }

        public string Description { get; set; }

        public int FactoryId { get; set; }
        public int AttachmentId { get; set; }
    }
}
