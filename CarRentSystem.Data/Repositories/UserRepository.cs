using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;

namespace CarRentSystem.Data.Repositories
{
    public class UserRepository(ApplicationDbContext context) : BaseRepository<User>(context), IUserRepository
    {
    }
}
