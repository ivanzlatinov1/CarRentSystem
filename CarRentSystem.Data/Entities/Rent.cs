using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentSystem.Data.Entities
{
    [Table("Rents")]
    public class Rent
    {
        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        // The date when the car was rented
        [Required]
        public DateTime RentDate { get; set; }

        // The date when the car should be returned (or has already been returned)
        public DateTime? ReturnDate { get; set; }
    }
}
