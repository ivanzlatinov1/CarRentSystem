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
                Username = entity.Username,
                Password = entity.Password,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                EGN = entity.EGN,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Rents = firstTime ? entity.Rents.Select(x => x.ToModel()).ToHashSet() : null!
            };

        public static User ToEntity(this UserModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Rents = firstTime ? model.Rents.Select(x => x.ToEntity()).ToHashSet() : null!
            };
    }
}
