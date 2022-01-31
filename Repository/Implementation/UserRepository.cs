using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly EfContext _context;

        public UserRepository(EfContext context)
        {
            _context = context;
        }
        public async Task<User> GetByUserNameAsync(string userName, string password)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Username == userName && x.Password == password && x.Status == StatusOption.Active);
        }
        public async Task SaveAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
