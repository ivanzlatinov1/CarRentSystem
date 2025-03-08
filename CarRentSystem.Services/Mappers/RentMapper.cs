using CarRentSystem.Data.Entities;
using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Mappers
{
    public static class RentMapper
    {
        public static RentModel ToModel(this Rent entity, bool firstTime = true)
            => new()
            {
                CarId = entity.CarId,
                Car = firstTime ? entity.Car.ToModel(false) : null!,
                UserId = entity.UserId,
                User = firstTime ? entity.User.ToModel(false) : null!,
                RentDate = entity.RentDate,
                ReturnDate = entity.ReturnDate
            };

        public static Rent ToEntity(this RentModel model, bool firstTime = true)
            => new()
            {
                CarId = model.CarId,
                Car = firstTime ? model.Car.ToEntity(false) : null!,
                UserId = model.UserId,
                User = firstTime ? model.User.ToEntity(false) : null!,
                RentDate = model.RentDate,
                ReturnDate = model.ReturnDate
            };
    }
}
