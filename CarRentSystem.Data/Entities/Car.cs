using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarRentSystem.Data.Constants;

namespace CarRentSystem.Data.Entities
{
    [Table("Cars")]
    public class Car : BaseEntity
    {
        [Required]
        [MaxLength(MaxCarNameLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarNameLength)]
        public string Model { get; set; } = null!;

        public int? Year { get; set; }

        public int? Seats { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string? Description { get; set; }

        [Comment("The price of the car for a day")]
        public decimal? Price { get; set; }

        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }
}
