using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace pedido_plus_backend.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string Position { get; set; }
        public User() : base() { }
    }
}