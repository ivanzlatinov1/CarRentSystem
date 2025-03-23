using System.ComponentModel.DataAnnotations;

namespace CarRentSystem.Services.Models
{
    public class RentModel
    {
        [Required]
        public int CarId { get; set; }

        public CarModel Car { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public UserModel User { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RentDate { get; set; }

        [DataType(DataType.DateTime)]
        [Compare(nameof(RentDate), ErrorMessage = "Return date must be later than the rent date.")]
        public DateTime? ReturnDate { get; set; }
    }
}
