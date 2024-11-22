using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using pedido_plus_backend.Dtos.Login;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Services
{
    public class AuthService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var user = _signInManager
                 .UserManager
                 .Users
                 .FirstOrDefault(user => user.NormalizedEmail == dto.Email.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}