using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            var product = _mapper.Map<Product>(productDto);

            if (string.IsNullOrEmpty(productDto.Name) || productDto.Name.Length < 3)
                throw new ApplicationException(
                    "Nome do produto inválido. Não deve ser vazio e menor que 3 caracteres."
                    );

            if (_context.Products.Any(c => c.Name == productDto.Name && c.Id != productDto.Id))
                throw new ApplicationException("Um produto com o mesmo nome já existe.");

            await _productRepository.Update(product);
        }
    }
}