using AutoMapper;
using Ebtdaa.Application.Users.Dtos;
using Ebtdaa.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Users.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<User, UserResultDto>();
            CreateMap<UserRequestDto, User>();
        }
    }
}
