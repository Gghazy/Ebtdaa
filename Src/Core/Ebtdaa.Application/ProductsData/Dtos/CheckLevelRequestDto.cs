using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class CheckLevelRequestDto
    {
        public int ParentId { get; set; }
        public int OldProductId { get; set; }
        public int NewProductId { get; set; }
    }
}
