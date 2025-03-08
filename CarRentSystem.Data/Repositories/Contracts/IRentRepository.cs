using CarRentSystem.Data.Entities;

namespace CarRentSystem.Data.Repositories.Contracts
{
    public interface IRentRepository
    {
        public Task<string> RentCarAsync(int userId, int carId);
        public Task<string> ReturnCarAsync(int rentId);
        public Task<ICollection<Rent>> GetAllAsync();
        public Task<Rent?> GetByIdAsync(int rentId);
        public Task UpdateAsync(Rent rent);
        public Task DeleteAsync(Rent rent);
    }
}
