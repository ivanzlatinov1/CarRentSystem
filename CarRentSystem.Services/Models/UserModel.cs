﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarRentSystem.Services.Models
{
    public class UserModel
    {
        public string Id { get; set; } = null!;

        [MaxLength(255)]
        public string? Username { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z-]+$", ErrorMessage = "First name must start with an uppercase letter and contain only letters and hyphens.")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z-]+$", ErrorMessage = "Last name must start with an uppercase letter and contain only letters and hyphens.")]
        public string? LastName { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "EGN must be exactly 10 digits.")]
        public string? EGN { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? Image { get; set; }

        public ICollection<RentModel> Rents { get; set; } = [];
    }
}
