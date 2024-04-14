using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Dtos
{
    public class InspectProductsRequestDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int ProductPhotoId { get; set; }
        public string ProductId { get; set; }
        public bool IsProductPhotoCorrect {  get; set; }
        public int NewProductPhotoId { get; set; }
        public string Comments { get; set; }


    }
}
