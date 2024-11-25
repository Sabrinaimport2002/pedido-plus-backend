using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pedido_plus_backend.Context;
using pedido_plus_backend.Dtos.Product;
using pedido_plus_backend.Models;
using pedido_plus_backend.Repositories.Interfaces;
using pedido_plus_backend.Services.Interfaces;

namespace pedido_plus_backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ContextDb _context;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, ContextDb context, IMapper mapper)
        {
            _productRepository = productRepository;
            _context = context;
            _mapper = mapper;
        }


        public async Task CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (string.IsNullOrEmpty(productDto.Name) || productDto.Name.Length < 3)
                throw new ApplicationException(
                    "Nome do produto inválido. Não deve ser vazio e menor que 3 caracteres."
                    );

            if (_context.Products.Any(c => c.Name == productDto.Name))
                throw new ApplicationException("Um produto com o mesmo nome já existe.");

            // Associar categorias ao produto
            if (productDto.CategoryIds != null && productDto.CategoryIds.Any())
            {
                var categories = await _context.Categories
                    .Where(c => productDto.CategoryIds.Contains(c.Id))
                    .ToListAsync();

                if (categories.Count != productDto.CategoryIds.Count)
                    throw new ApplicationException("Uma ou mais categorias não foram encontradas.");

                product.Categories = categories;
            }

            await _productRepository.Create(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<Product>(product);
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<Product>>(products);
        }

        public async Task UpdateProduct(CreateProductDto productDto)
        {
            var product = await _productRepository.GetById(productDto.Id);

            if (product == null)
                throw new ApplicationException("Produto não encontrado.");

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;

            // Atualizar categorias
            if (productDto.CategoryIds != null && productDto.CategoryIds.Any())
            {
                var categories = await _context.Categories
                    .Where(c => productDto.CategoryIds.Contains(c.Id))
                    .ToListAsync();

                if (categories.Count != productDto.CategoryIds.Count)
                    throw new ApplicationException("Uma ou mais categorias não foram encontradas.");

                product.Categories = categories;
            }

            await _productRepository.Update(product);
        }
    }
}