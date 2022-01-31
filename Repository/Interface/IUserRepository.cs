using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        Task SaveAsync(User user);
        Task<User> GetByUserNameAsync(string userName, string password);
    }
}
