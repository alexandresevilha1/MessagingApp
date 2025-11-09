using MessagingApp.Domain.Entities;
using MessagingApp.Domain.Interfaces;
using MessagingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MessagingApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var userEntry = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return userEntry.Entity;
        }
    }
}