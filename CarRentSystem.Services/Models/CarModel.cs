namespace CarRentSystem.Services.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int? Year { get; set; }

        public int? Seats { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public ICollection<RentModel> Rents { get; set; } = new HashSet<RentModel>();
    }
}
