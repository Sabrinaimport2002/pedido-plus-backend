using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(string userId);
        Task<IEnumerable<User>> GetAllAsync();
    }
}