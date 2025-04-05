using CarRentSystem.Data.Repositories.Contracts;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Mappers;
using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Implementations
{
    public class RentService(IRentRepository rentRepository) : IRentService
    {
        private readonly IRentRepository _rentRepository = rentRepository;

        public async Task<ICollection<RentModel>> GetAllAsync()
        {
            var rents = await _rentRepository.GetAllAsync();

            return [.. rents.Select(x => x.ToModel())];
        }

        public async Task<RentModel?> GetByIdAsync(string userId, int carId)
        {
            var rent = await _rentRepository.GetByIdAsync(userId, carId);

            if (rent == null) return null;

            return rent.ToModel();
        }

        public async Task<string> RentCarAsync(string userId, int carId)
        {
            string result = await _rentRepository.RentCarAsync(userId, carId);

            return result;
        }

        public async Task<string> ReturnCarAsync(string userId, int carId)
        {
            string result = await _rentRepository.ReturnCarAsync(userId, carId);

            return result;
        }

        public async Task UpdateAsync(RentModel rentModel)
        {
            await _rentRepository.UpdateAsync(rentModel.ToEntity());
        }
    }
}
