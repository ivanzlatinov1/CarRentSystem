using CarRentSystem.Data.Entities;

namespace CarRentSystem.Data.Repositories.Contracts
{
    public interface IRentRepository
    {
        public Task<string> RentCarAsync(int userId, int carId);
        public Task<string> ReturnCarAsync(int rentId);
        public Task<Rent> GetByIdAsync(int rentId);
        public Task UpdateAsync(int rentId);
        public Task DeleteAsync(int rentId);
        public Task<ICollection<Rent>> GetAllAsync();
    }
}
