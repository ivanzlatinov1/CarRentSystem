using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRentSystem.Data.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> CreateAsync(User userEntity)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }

        public async Task DeleteAsync(User userEntity)
        {
            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ICollection<User>> GetByUsernameAsync(string userName)
        {
            return await _context.Users.Where(u => u.UserName == userName).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User userEntity)
        {
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
        }
    }
}
