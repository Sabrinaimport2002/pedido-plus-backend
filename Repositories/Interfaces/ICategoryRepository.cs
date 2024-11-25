using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
    }
}