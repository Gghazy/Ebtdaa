using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Common.Dtos
{
    public class ExeptionResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string[] Errors { get; set; }
    }
}
