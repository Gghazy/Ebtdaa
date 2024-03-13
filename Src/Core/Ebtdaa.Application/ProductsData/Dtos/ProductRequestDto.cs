using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class ProductRequestDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int PeriodId { get; set; }
        public string? CommericalName { get; set; }
        public int? UnitId { get; set; }
        public int FactoryId { get; set; }
        public double? Kilograms_Per_Unit { get; set; }
        public int PhototId { get; set; }
        public int PeperId { get; set; }
    }
}
