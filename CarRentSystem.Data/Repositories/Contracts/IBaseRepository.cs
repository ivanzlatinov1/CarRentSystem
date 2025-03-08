using CarRentSystem.Data.Entities;
using System.Linq.Expressions;

namespace CarRentSystem.Data.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetByFilter(Expression<Predicate<string>> filter);
    }
}
