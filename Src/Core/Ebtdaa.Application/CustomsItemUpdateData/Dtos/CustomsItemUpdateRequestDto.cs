using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItemUpdateData.Dtos
{
    public class CustomsItemUpdateRequestDto
    {
        public int Id {  get; set; }
        public int FactoryId {  get; set; }
        public int ActiveProductsCount { get; set; }
        public Boolean IsActiveProduct { get; set; }
        public int CustomsItem10_Id { get; set; }
        public int CustomsItem12_Id { get; set; }
        public Boolean ValidtyCustomsClassification { get; set; }


    }
}
