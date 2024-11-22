using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedido_plus_backend.Dtos.Login;
using pedido_plus_backend.Services;

namespace pedido_plus_backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.Login(loginDto);
            return Ok(new { access_token = token });
        }
    }
}