using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models.Identity;
using ProjetoAPI.Persistence.Contextos;
using ProjetoAPI.Persistence.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence
{
    public class UserPersist : GeralPersist, IUserPersist
    {
        private readonly ProjetoContext _context;

        public UserPersist(ProjetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName.Contains(userName.ToLower()));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
