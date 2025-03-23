using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Contracts
{
    public interface ICarService
    {
        Task<ICollection<CarModel>> GetAllAsync();
        Task<CarModel?> GetByIdAsync(int id);
        Task<int> AddAsync(CarModel carModel);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id);
        Task<ICollection<CarModel>?> FindByMake(string make);
        Task<ICollection<CarModel>?> FindByModel(string model);
    }
}
