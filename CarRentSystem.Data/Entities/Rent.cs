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
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [Required]
        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
