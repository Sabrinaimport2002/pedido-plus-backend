using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Services
{
    public class TokenService
    {
        public string GenerateToken(User? user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("id", user.Id),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0f"));

            var signingCredentials =
                new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}