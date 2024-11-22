using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedido_plus_backend.Dtos.User;

namespace pedido_plus_backend.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserDto dto);
        Task<UserDto> GetUserById(string userId);
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}