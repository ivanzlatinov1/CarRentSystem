using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Mappers;
using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Implementations
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<ICollection<UserModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return [.. users.Select(x => x.ToModel())];
        }

        public async Task<string> AddAsync(UserModel userModel)
        {
            var entity = await _userRepository.CreateAsync(userModel.ToEntity());
            return entity.Id;
        }

        public async Task<ICollection<UserModel>?> FindByUsername(string userName)
        {
            var users = await _userRepository.GetByUsernameAsync(userName);

            return users.Select(x => x.ToModel()).ToList();
        }


        public async Task<UserModel?> GetByIdAsync(string id)
        {
            User? user = await _userRepository.GetByIdAsync(id);

            if(user == null) return null;

            return user.ToModel();
        }

        public async Task RemoveAsync(string id)
        {
            User? user = await _userRepository.GetByIdAsync(id);

            if(user != null)
                await _userRepository.DeleteAsync(user);
        }
    }
}
