using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedido_plus_backend.Dtos.User;
using pedido_plus_backend.Models;
using pedido_plus_backend.Services;
using pedido_plus_backend.Services.Interfaces;

namespace pedido_plus_backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> RegisterUser(CreateUserDto dto)
        {
            await _userService.CreateUser(dto);
            return Ok("Successfully registered!");
        }

        [HttpGet("Profile")]
        public async Task<ActionResult<IEnumerable<User>>> Profile()
        {
            var userId = User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid user");
            }

            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
        [HttpGet("Profiles")]
        public async Task<ActionResult<IEnumerable<User>>> Profiles()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound("Users not found");
            }
            return Ok(users);
        }
    }
}