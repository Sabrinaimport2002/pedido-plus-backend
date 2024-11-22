using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pedido_plus_backend.Dtos.User;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}