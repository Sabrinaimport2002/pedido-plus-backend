using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pedido_plus_backend.Context;
using pedido_plus_backend.Dtos.Category;
using pedido_plus_backend.Models;
using pedido_plus_backend.Repositories.Interfaces;
using pedido_plus_backend.Services.Interfaces;

namespace pedido_plus_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ContextDb _context;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, ContextDb context, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            if (string.IsNullOrEmpty(categoryDto.Name) || categoryDto.Name.Length < 3)
                throw new ApplicationException(
                    "Nome da categoria inválida. Não deve ser vazio e menor que 3 caracteres."
                    );

            if (_context.Categories.Any(c => c.Name == categoryDto.Name && c.Id != categoryDto.Id))
                throw new ApplicationException("Uma categoria com o mesmo nome já existe.");

            await _categoryRepository.Create(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<Category>>(categories);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map<Category>(category);
        }

        public async Task UpdateCategory(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            if (string.IsNullOrEmpty(categoryDto.Name) || categoryDto.Name.Length < 3)
                throw new ApplicationException(
                    "Nome da categoria inválida. Não deve ser vazio e menor que 3 caracteres."
                    );

            if (_context.Categories.Any(c => c.Name == categoryDto.Name && c.Id != categoryDto.Id))
                throw new ApplicationException("Uma categoria com o mesmo nome já existe.");

            await _categoryRepository.Update(category);
        }
    }
}