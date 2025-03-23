using CarRentSystem.Data.Entities;
using System.Linq.Expressions;

namespace CarRentSystem.Data.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<ICollection<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<ICollection<T>> GetByFilter(Expression<Func<T, bool>> filter);
    }
}