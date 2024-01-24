using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class CustomLevelRequestDto
    {
        public int ProductId { get; set; }
        public List<int> CustomLevelProductIds { get; set; }
    }
}
