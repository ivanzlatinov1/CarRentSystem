using Microsoft.AspNetCore.Identity;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Mappers;
using CarRentSystem.Services.Models;
using CarRentSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentSystem.Services.Implementations
{
    public class UserService(UserManager<User> userManager) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;

        public async Task<ICollection<UserModel>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(x => x.ToModel()).ToList();
        }

        public async Task<string> AddAsync(UserModel userModel)
        {
            var user = userModel.ToEntity();
            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            return user.Id;
        }

        public async Task<ICollection<UserModel>?> FindByUsername(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user != null ? new List<UserModel> { user.ToModel() } : new List<UserModel>();
        }

        public async Task<UserModel?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user?.ToModel();
        }

        public async Task RemoveAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }
}