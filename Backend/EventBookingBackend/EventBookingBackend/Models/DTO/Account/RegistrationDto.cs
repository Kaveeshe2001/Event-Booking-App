using System.ComponentModel.DataAnnotations;

namespace EventBookingBackend.Models.DTO.Account
{
    public class RegistrationDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
