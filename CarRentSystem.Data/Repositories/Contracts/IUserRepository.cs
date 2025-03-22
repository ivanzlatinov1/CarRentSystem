using CarRentSystem.Data.Entities;
using System.Linq.Expressions;

namespace CarRentSystem.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<User> CreateAsync(User userEntity);
        public Task UpdateAsync(User userEntity);
        public Task DeleteAsync(User userEntity);
        public Task<ICollection<User>> GetAllAsync();
        public Task<User?> GetByIdAsync(string id);
        public Task<ICollection<User>> GetByUsernameAsync(string userName);
    }
}
