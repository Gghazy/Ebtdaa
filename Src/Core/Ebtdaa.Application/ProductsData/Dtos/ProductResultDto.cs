using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class ProductResultDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? CommericalName { get; set; }
        public int? UnitId { get; set; }
        public string? ItemNumber { get; set; }
        public string? Level12Number { get; set; }
        public string? Hs12NameEn { get; set; }
        public string? Hs12NameAr { get; set; }
        public string? Hs12Code { get; set; }

        public string? CR { get; set; }
        public string? Status { get; set; }
        public int? FactoryId { get; set; }
        public string UnitName { get; set; }
        public bool? Review { get; set; }
        public double? Kilograms_Per_Unit { get; set; }
        public int? PeperId { get; set; }
        public int? PhototId { get; set; }
        public bool IsActive { get; set; }


    }
}
