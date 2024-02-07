using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.LogIn.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.LogIn.Interfaces
{
   public interface  ILoginService
    {
        Task<BaseResponse<List<FactoryResualtDto>>> GetAll(string ownerIdentity);
        //Task<BaseResponse<List<FactoryResualtDto>>> OnGet();
    }
}
