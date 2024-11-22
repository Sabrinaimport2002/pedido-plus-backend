using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pedido_plus_backend.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
    }
}