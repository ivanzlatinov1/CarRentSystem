using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarRentSystem.Data.Constants;

namespace CarRentSystem.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(MaxUserNameLength)]
        public string? FirstName { get; set; }

        [MaxLength(MaxUserNameLength)]
        public string? LastName { get; set; }

        [Column(TypeName = "char(10)")]
        public string? EGN {get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public ICollection<Rent> Rents { get; set; } = [];
    }
}
