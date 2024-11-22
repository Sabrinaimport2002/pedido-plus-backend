using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using pedido_plus_backend.Dtos.User;
using pedido_plus_backend.Models;
using pedido_plus_backend.Repositories.Interfaces;
using pedido_plus_backend.Services.Interfaces;

namespace pedido_plus_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateUser(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            user.UserName = dto.Email;

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Could not register user.");
            }
        }

        public async Task<UserDto> GetUserById(string userId)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}