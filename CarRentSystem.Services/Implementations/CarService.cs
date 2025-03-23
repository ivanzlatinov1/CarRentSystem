using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Mappers;
using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Implementations
{
    public class CarService(ICarRepository carRepository) : ICarService
    {
        private readonly ICarRepository _carRepository = carRepository;
        public async Task<int> AddAsync(CarModel carModel)
        {
            var entity = await _carRepository.CreateAsync(carModel.ToEntity());
            return entity.Id;
        }

        public async Task<ICollection<CarModel>?> FindByMake(string make)
        {
            var cars = await _carRepository.GetByFilter(c => c.Make == make);

            return cars.Select(x => x.ToModel()).ToList();
        }

        public async Task<ICollection<CarModel>?> FindByModel(string model)
        {
            var cars = await _carRepository.GetByFilter(c => c.Model == model);

            return cars.Select(x => x.ToModel()).ToList();
        }

        public async Task<ICollection<CarModel>> GetAllAsync()
        {
            var cars = await _carRepository.GetAllAsync();

            return [.. cars.Select(x => x.ToModel())];
        }

        public async Task<CarModel?> GetByIdAsync(int id)
        {
            Car? car = await _carRepository.GetByIdAsync(id);

            if(car == null) return null;

            return car.ToModel();
        }

        public async Task RemoveAsync(int id)
        {
            Car? car = await _carRepository.GetByIdAsync(id);

            if(car != null)
                await _carRepository.DeleteAsync(car);
        }
    }
}
