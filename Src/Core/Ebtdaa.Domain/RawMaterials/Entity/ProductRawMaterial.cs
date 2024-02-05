using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class ProductRawMaterial
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; }
        public int rawMaterialId { get; set; }
        public  RawMaterial RawMaterial { get; set; }
    }
}
