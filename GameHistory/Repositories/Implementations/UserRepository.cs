using GameHistory.Models;
using GameHistory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameHistory.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly GamerHistoryContext _context;

        public UserRepository(GamerHistoryContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> PseudoExistsAsync(string pseudo)
        {
            return await _context.Users.AnyAsync(u => u.Pseudo == pseudo);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}