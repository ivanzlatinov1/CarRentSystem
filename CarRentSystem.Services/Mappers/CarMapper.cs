using CarRentSystem.Data.Entities;
using CarRentSystem.Services.Models;

namespace CarRentSystem.Services.Mappers
{
    public static class CarMapper
    {
        public static CarModel ToModel(this Car entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                Make = entity.Make,
                Model = entity.Model,
                Year = entity.Year,
                Seats = entity.Seats,
                Description = entity.Description,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Rents = firstTime ? entity.Rents.Select(x => x.ToModel(false)).ToHashSet() : null!
            };

        public static Car ToEntity(this CarModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                Seats = model.Seats,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Rents = firstTime ? model.Rents.Select(x => x.ToEntity(false)).ToHashSet() : null!
            };
    }
}
