using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class BasketRepository : IBasketRepository
    {
        private readonly EfContext _context;

        public BasketRepository(EfContext context)
        {
            _context = context;
        }
        public async Task<Product> GetBasketProductsByCategoryId(string userName, int categoryId)
        {
            var productInfo = await _context.Product
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == categoryId);
               return productInfo;
        }
        public async Task SaveAsync(string userName, Basket basket)
        {
            _context.Add(basket);
            await _context.SaveChangesAsync();
        }
    }
}
