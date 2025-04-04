using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Contracts
{
    public interface IUserService
    {
        Task<ICollection<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(string id);
        Task<string> AddAsync(UserModel userModel, string password);
        Task RemoveAsync(string id);
        Task<ICollection<UserModel>?> FindByUsername(string userName);
    }
}
