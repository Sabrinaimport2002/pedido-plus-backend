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
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDb _context;

        public ProductRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetById(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
            .Include(p => p.Categories)
            .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}