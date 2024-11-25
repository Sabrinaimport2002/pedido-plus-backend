using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Context
{
    public class ContextDb : IdentityDbContext<User>
    {
        public ContextDb(DbContextOptions<ContextDb> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}