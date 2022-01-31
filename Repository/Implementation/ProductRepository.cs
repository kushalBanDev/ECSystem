using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfContext _context;

        public ProductRepository(EfContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            List<Product> list = await _context.Product
                .AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(x => new Product
                {
                    Id = x.Id,
                    Category = x.Category,
                    Name = x.Name,
                    Image = string.Concat("https://localhost:44302", x.Image),
                    Price = x.Price
                })
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Product>> SearchProductByCategoryAsync(string categoryId)
        {
            var list =  await _context.Product
               .AsNoTracking()
               .Where(x => x.Category == categoryId)
               .Select(x => new Product
               {
                   Id = x.Id,
                   Category = x.Category,
                   Name = x.Name,
                   Image = string.Concat("https://localhost:44302", x.Image),
                   Price = x.Price
               })
               .ToListAsync();
            return list;
        }
    }
}
