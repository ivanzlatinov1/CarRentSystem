using System.ComponentModel.DataAnnotations;

namespace CarRentSystem.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
