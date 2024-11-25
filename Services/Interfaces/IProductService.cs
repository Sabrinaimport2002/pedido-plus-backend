using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedido_plus_backend.Dtos.Product;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task CreateProduct(CreateProductDto productDto);
        Task UpdateProduct(CreateProductDto productDto);
        Task DeleteProduct(int id);
    }
}