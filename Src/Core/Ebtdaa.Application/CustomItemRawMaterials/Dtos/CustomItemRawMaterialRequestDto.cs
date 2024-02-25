using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomItemRawMaterials.Dtos
{
    public class CustomItemRawMaterialRequestDto
    {
        public int Id { get; set; }
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
    }
}
