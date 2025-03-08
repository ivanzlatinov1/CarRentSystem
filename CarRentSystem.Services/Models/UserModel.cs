using CarRentSystem.Data.Entities;

namespace CarRentSystem.Services.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EGN {get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<RentModel> Rents { get; set; } = new HashSet<RentModel>();
    }
}
