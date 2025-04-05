using CarRentSystem.Data.Entities;

namespace CarRentSystem.Data.Repositories.Contracts
{
    public interface IRentRepository
    {
        public Task<string> RentCarAsync(string userId, int carId);
        public Task<string> ReturnCarAsync(string userId, int carId);
        public Task<ICollection<Rent>> GetAllAsync();
        public Task<Rent?> GetByIdAsync(string userId, int carId);
        public Task UpdateAsync(Rent rent);
    }
}
