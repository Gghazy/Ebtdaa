using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.CustomsItem.CustomsItemLevel.Entity
{
    public class CustomsItemLevel 
    {
        public int Id { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public CustomsItemLevelEnum LevelId { get; set; }




    }
}
