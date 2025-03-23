using System.ComponentModel.DataAnnotations;

namespace CarRentSystem.Services.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Make must be between 2 and 50 characters.")]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters.")]
        public string Model { get; set; } = null!;

        [Range(1886, 2100, ErrorMessage = "Year must be between 1886 and 2100.")]
        public int? Year { get; set; }

        [Range(1, 100, ErrorMessage = "Seats must be between 1 and 100.")]
        public int? Seats { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? Price { get; set; }

        public ICollection<RentModel> Rents { get; set; } = [];
    }
}
