using System.ComponentModel.DataAnnotations;

namespace CarRentSystem.Services.Models
{
    public class UserModel
    {
        public string Id { get; set; } = null!;

        public string? Username { get; set; }

        [Required]
        public string Password { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Length(10, 10)]
        public string? EGN {get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
