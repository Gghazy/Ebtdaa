using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Users.Dtos;
using Ebtdaa.Application.Users.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Users.Handlers
{
    public class UserService : IUserService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public UserService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UserResultDto>> GetOne(string ownerIdentity )
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.OwnerIdentity == ownerIdentity);

            return new BaseResponse<UserResultDto>
            {
                Data = result != null ? _mapper.Map<UserResultDto>(result) : new UserResultDto()
            };
        }
    }
}
