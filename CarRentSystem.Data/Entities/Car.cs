using Microsoft.AspNetCore.Http;
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

        // The year the car was manufactured
        public int? Year { get; set; }

        // The number of seats in the car
        public int? Seats { get; set; }

        // Optional description of the car
        [MaxLength(MaxDescriptionLength)]
        public string? Description { get; set; }

        [Comment("The price of the car for a day")]
        public decimal? Price { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public virtual ICollection<Rent> Rents { get; set; } = [];
    }
}
