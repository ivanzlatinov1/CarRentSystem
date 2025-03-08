using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRentSystem.Data.Repositories
{
    public class BaseRepository<T>(ApplicationDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _set = context.Set<T>();
        public async Task CreateAsync(T entity)
        {
            await _set.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
            => await _set.ToArrayAsync();

        public ICollection<T> GetByFilter(Expression<Func<T, bool>> filter)
            => [.. _set.Where(filter)];

        public async Task<T?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
