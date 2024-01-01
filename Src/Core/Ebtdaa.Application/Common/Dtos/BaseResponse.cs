using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Common.Dtos
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T Data { get; set; }

    }
}
