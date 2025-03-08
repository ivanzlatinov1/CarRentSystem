using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;

namespace CarRentSystem.Data.Repositories
{
    public class CarRepository(ApplicationDbContext context) : BaseRepository<Car>(context), ICarRepository
    {
    }
}
