using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pedido_plus_backend.Context;
using pedido_plus_backend.Models;
using pedido_plus_backend.Repositories.Interfaces;

namespace pedido_plus_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb _context;

        public UserRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}