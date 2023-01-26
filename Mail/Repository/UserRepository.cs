using Mail.Context;
using Mail.Context.IContext;
using Mail.Entities;
using Mail.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Mail.Repository
{
    public class UserRepository : IUserRepository
    {
        ITask6Context _context;
        
        public UserRepository(ITask6Context context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public async Task<User> GetUserByName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == username);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }
    }
}
