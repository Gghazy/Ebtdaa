using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class RawMaterialProductDto
    {

        public int Id { get; set; }
        public int RawMaterialId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
