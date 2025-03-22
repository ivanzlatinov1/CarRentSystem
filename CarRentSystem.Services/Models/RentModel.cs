namespace CarRentSystem.Services.Models
{
    public class RentModel
    {
        public int CarId { get; set; }
        public CarModel Car { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public UserModel User { get; set; } = null!;
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
