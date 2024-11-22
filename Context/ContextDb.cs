using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pedido_plus_backend.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> opts) : base(opts) { }
    }
}