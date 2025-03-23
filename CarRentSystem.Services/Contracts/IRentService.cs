using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Contracts
{
    public interface IRentService
    {
        public Task<string> RentCarAsync(string userId, int carId);
        public Task<string> ReturnCarAsync(string userId, int carId);
        public Task<ICollection<RentModel>> GetAllAsync();
        public Task<RentModel?> GetByIdAsync(string userId, int carId);
        public Task UpdateAsync(RentModel rentModel);
        public Task DeleteAsync(RentModel rentModel);
    }
}
