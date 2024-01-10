using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItem.Dtos
{
    public class CustomsItemLevelRequestDto
    {
        public int Id { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public CustomsItemLevelEnum LevelId { get; set; }
    }
}
