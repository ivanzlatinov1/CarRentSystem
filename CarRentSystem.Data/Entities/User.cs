using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarRentSystem.Data.Constants;

namespace CarRentSystem.Data.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(MaxUserNameLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(MaxPasswordLength)]
        [Unicode(false)]
        public string Password { get; set; } = null!;

        [MaxLength(MaxUserNameLength)]
        public string? FirstName { get; set; }

        [MaxLength(MaxUserNameLength)]
        public string? LastName { get; set; }

        [Column("char(10)")]
        public string? EGN {get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }
}
