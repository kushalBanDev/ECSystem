using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBasketRepository
    {
        Task<Product> GetBasketProductsByCategoryId(string userName,int categoryId);
        Task SaveAsync(string userName, Basket basket);

    }
}
