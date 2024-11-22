using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProducRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product Product)
        {
            _context.Add(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _context.Products.Include(c=>c.Category)
                .SingleOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<Product> RemoveAsync(Product Product)
        {
            _context.Remove(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> UpdateAsync(Product Product)
        {
            _context.Update(Product);
            await _context.SaveChangesAsync();
            return Product;
        }
    }
}
