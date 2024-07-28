using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<UserResultDto>> GetOne(string ownerIdentity);
        Task<BaseResponse<UserResultDto>> AddAsync(UserRequestDto req);
    }
}
