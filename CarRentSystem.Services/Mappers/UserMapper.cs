using CarRentSystem.Data.Entities;
using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToModel(this User entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                Username = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                EGN = entity.EGN,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                ImageUrl = entity.ImageUrl,
                Image = entity.Image,
                Rents = firstTime ? entity.Rents.Select(r => r.ToModel()).ToList() : null!
            };

        public static User ToEntity(this UserModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                ImageUrl = model.ImageUrl,
                Image = model.Image,
                Rents = firstTime ? model.Rents.Select(r => r.ToEntity()).ToList() : null!
            };
    }
}
