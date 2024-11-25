using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedido_plus_backend.Dtos.Category;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task UpdateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(int id);
    }
}